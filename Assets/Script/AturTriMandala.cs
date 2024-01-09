using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AturTriMandala : MonoBehaviour
{
    public static AturTriMandala instance;
    public int ID;
    public GameObject[] TempatSpawn;
    public GameObject[] Pelinggih;
    public GameObject penanda;
    public GameObject board;
    public Button tombolKanan;
    public Button tombolKiri;

    public Vector3[] customScales;

    [SerializeField] int jmlMarker;
    [SerializeField] private string[] namaObjek;
    [SerializeField] private AudioClip[] audioObjek;
    [SerializeField] private Text txNama;

    private AudioSource audioSource; // Menyimpan komponen AudioSource
    private GameObject benda; // Menyimpan objek yang dibuat
    private bool[] isMarker;
    private int hitungMarker;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ID = 0;
        isMarker = new bool[jmlMarker];
        audioSource = GetComponent<AudioSource>();
        SetAllPelinggihTags();

        // Tambahkan listener untuk tombol kanan
        if (tombolKanan != null)
        {
            tombolKanan.onClick.AddListener(() => GantiPelinggih(true));
        }

        // Tambahkan listener untuk tombol kiri
        if (tombolKiri != null)
        {
            tombolKiri.onClick.AddListener(() => GantiPelinggih(false));
        }

    }
    
    private void SetUI(bool isActive)
    {
        tombolKanan.gameObject.SetActive(isActive);
        tombolKiri.gameObject.SetActive(isActive);
        board.gameObject.SetActive(isActive);
    }

    private void SetAllPelinggihTags()
    {
        foreach (GameObject pelinggihObj in Pelinggih)
        {
            if (pelinggihObj != null)
            {
                pelinggihObj.tag = "ObyekPelinggih";
            }
        }
    }

    public void TidakAdaMarker()
    {
            SetUI(false);
            penanda.SetActive(true);

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            GameObject[] BendaSebelumnyaArray = GameObject.FindGameObjectsWithTag("ObyekPelinggih");
            foreach (GameObject bendaSebelumnya in BendaSebelumnyaArray)
            {
                if (bendaSebelumnya != benda)
                {
                    Destroy(bendaSebelumnya);
                }
            }
            return;                    
    }

    public void AdaMarker()
    {
        SpawnObject();
        SetUI(true);
        penanda.SetActive(false);
        // Ambil atau tambahkan AudioSource pada objek
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    public void SpawnObject()
    {
        SetUI(true);
        penanda.SetActive(false);
        if (ID >= 0 && ID < Pelinggih.Length && TempatSpawn.Length > 0)
        {
            benda = Instantiate(Pelinggih[ID]);
            GameObject tempat = TempatSpawn[0];

            if (customScales.Length == Pelinggih.Length)
            {
                benda.transform.localScale = customScales[ID];
            }
            else
            {
                Debug.LogError("Jumlah skala khusus tidak sesuai dengan jumlah objek.");
                return;
            }

            benda.tag = "ObyekPelinggih";

            benda.transform.SetParent(tempat.transform, false);
            benda.transform.localPosition = new Vector3(0, 0, 0);

            if (ID == 27 || ID == 28)
            {
                benda.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                benda.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            }

            GameObject[] BendaSebelumnyaArray = GameObject.FindGameObjectsWithTag("ObyekPelinggih");
            foreach (GameObject bendaSebelumnya in BendaSebelumnyaArray)
            {
                if (bendaSebelumnya != benda)
                {
                    Destroy(bendaSebelumnya);
                }
            }
        }
        else
        {
            Debug.LogError("ID diluar rentang atau array TempatSpawn kosong.");
        }
    }

       public void GantiPelinggih(bool Kanan)
    {
        // Hentikan audio sebelumnya
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Dapatkan nama dan audio sebelum objek dihancurkan
        string namaSebelumnya = namaObjek[ID];
        AudioClip audioSebelumnya = audioObjek[ID];

        if (Kanan)
        {
            if (ID >= Pelinggih.Length - 1)
            {
                ID = 0;
            }
            else
            {
                ID++;
            }
        }
        else
        {
            if (ID <= 0)
            {
                ID = Pelinggih.Length - 1;
            }
            else
            {
                ID--;
            }
        }

        // Hancurkan objek sebelumnya
        GameObject[] BendaSebelumnyaArray = GameObject.FindGameObjectsWithTag("ObyekPelinggih");
        foreach (GameObject bendaSebelumnya in BendaSebelumnyaArray)
        {
            Destroy(bendaSebelumnya);
        }

        SpawnObject();

        // Set nama dan audio pada AudioSource
        benda.name = namaObjek[ID];
        audioSource.clip = audioObjek[ID];

        // Mainkan audio baru
        audioSource.Play();

        // Set nilai pada UI Text txNama
        txNama.text = namaObjek[ID];
    }

     private void Update()
    {       
        if (tombolKanan != null && tombolKanan.interactable && Input.GetButtonDown("kanan btn"))
        {
            GantiPelinggih(true);
        }

        if (tombolKiri != null && tombolKiri.interactable && Input.GetButtonDown("kiri btn"))
        {
            GantiPelinggih(false);
        }
    }
}
