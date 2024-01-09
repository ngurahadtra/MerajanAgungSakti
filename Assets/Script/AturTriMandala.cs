using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AturTriMandala : MonoBehaviour
{
    public static AturTriMandala instance;
    public int ID;
    public GameObject[] TempatSpawn;
    public GameObject[] Pelinggih;

    // Tambahkan array untuk menyimpan skala khusus untuk setiap objek
    public Vector3[] customScales;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ID = 0;
        SetAllPelinggihTags(); // Panggil metode ini untuk mengatur tag pada semua objek Pelinggih
        SpawnObject();
    }

    // Metode untuk mengatur tag pada semua objek Pelinggih
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

    public void SpawnObject()
    {
        if (ID >= 0 && ID < Pelinggih.Length && TempatSpawn.Length > 0)
        {
            GameObject benda = Instantiate(Pelinggih[ID]);
            GameObject tempat = TempatSpawn[0];

            // Periksa apakah customScales memiliki ukuran yang sesuai dengan jumlah objek
            if (customScales.Length == Pelinggih.Length)
            {
                // Set skala sesuai dengan nilai customScales yang sesuai dengan ID objek
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

            // Pengecekan apakah objek adalah elemen nomor 27 atau 28
            if (ID == 27 || ID == 28)
            {
                // Jika ya, atur rotasi sesuai kebutuhan
                benda.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // Jika tidak, atur rotasi standar
                benda.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            }

            // Hancurkan semua objek dengan tag "ObyekPelinggih" kecuali yang baru saja dibuat
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GantiPelinggih(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GantiPelinggih(false);
        }
    }

    public void GantiPelinggih(bool Kanan)
    {
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
        SpawnObject();
    }
}
