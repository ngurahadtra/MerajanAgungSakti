using UnityEngine;
using UnityEngine.UI;

public class AturDeskripsi : MonoBehaviour
{
    private bool[] isMarker;
    private GameObject pelinggih;
    private int hitungMarker;
    [SerializeField] int jmlMarker;
    [SerializeField] private Text txNo, txNama, txDesk, txNamaInfo;
    public AudioSource audioSource;

    public GameObject penanda;
    public GameObject Denah_AR;
    public GameObject ImgNomor;
    public GameObject InfoPelinggih;
    public GameObject sound_Off;
    public GameObject PopUpInfo;
    public GameObject sound_On;
    public Button infoPelinggih;
    public Button tutupInfo;
    public Button soundOff;
    public Button soundOn;
    public Button denahAR;
    public AudioSource audioSourceMusik;

    private void Start()
    {
        isMarker = new bool[jmlMarker];
        infoPelinggih.onClick.AddListener(InfoPelinggihOnClick);
        tutupInfo.onClick.AddListener(TutupInfoOnClick);
        soundOff.onClick.AddListener(soundOffOnClick);
        soundOn.onClick.AddListener(soundOnOnClick);
        denahAR.onClick.AddListener(DenahAROnClick);
        audioSourceMusik = GameObject.Find("Musik").GetComponent<AudioSource>();
    }

    private void InfoPelinggihOnClick()
    {
        if (pelinggih != null)
        {
            AudioClip audioClip = pelinggih.GetComponent<Pelinggih>().GetAudioDeskripsi();
            if (audioClip != null && audioSourceMusik != null)
            {
                audioSourceMusik.volume = 0.3f;

                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }

    private void DenahAROnClick()
    {
        if (pelinggih != null)
        {
            LoadSceneBasedOnIndex(pelinggih.GetComponent<Pelinggih>().GetIndex());
        }
    }

    private void TutupInfoOnClick()
    {
        if (pelinggih != null)
        {
            AudioClip audioClip = pelinggih.GetComponent<Pelinggih>().GetAudioDeskripsi();
            if (audioClip != null && audioSourceMusik != null)
            {
             // Mengembalikan volume pada objek "Musik" ke 1
                audioSourceMusik.volume = 1.0f;

                audioSource.clip = audioClip;
                audioSource.Stop();
            }
        }
    }

    private void soundOnOnClick()
    {
        if (pelinggih != null)
        {
            AudioClip audioClip = pelinggih.GetComponent<Pelinggih>().GetAudioDeskripsi();
            if (audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Pause();
                sound_Off.SetActive(true);
                sound_On.SetActive(false);
            }
        }
    }

    private void soundOffOnClick()
    {
        if (pelinggih != null)
        {
            AudioClip audioClip = pelinggih.GetComponent<Pelinggih>().GetAudioDeskripsi();
            if (audioClip != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                sound_Off.SetActive(false);
                sound_On.SetActive(true);
            }
        }
    }

    public void SetMarkerOn(int indexMarker)
    {
        if (!isMarker[indexMarker])
        {
            isMarker[indexMarker] = true;
            hitungMarker++;
        }
    }

    public void SetMarkerOff(int indexMarker)
    {
        if (isMarker[indexMarker])
        {
            isMarker[indexMarker] = false;
            hitungMarker--;
        }
    }

    public void SetPelinggih(GameObject pelinggih)
    {
        this.pelinggih = pelinggih;
    }

    private void SetUI(bool b)
    {
        txNama.transform.parent.gameObject.SetActive(b);
        txDesk.transform.parent.gameObject.SetActive(b);
        txNamaInfo.transform.parent.gameObject.SetActive(b);
    }

    private void LoadSceneBasedOnIndex(int index)
    {
        string sceneName = "";

        if (index >= 1 && index <= 20)
        {
           sceneName = "DenahUtama";
        }
        else if (index >= 21 && index <= 27)
        {
            sceneName = "DenahMadya";
        }
        else if (index >= 28 && index <= 31)
        {
            sceneName = "DenahNista";
        }

        if (!string.IsNullOrEmpty(sceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }

    void Update()
    {
        if (hitungMarker == 0)
        {
            Denah_AR.SetActive(false);
            ImgNomor.SetActive(false);
            InfoPelinggih.SetActive(false);
            SetUI(false);
            penanda.SetActive(true);

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                PopUpInfo.SetActive(false);
            }
            return;
        }


        if (pelinggih != null)
        {
            Denah_AR.SetActive(true);
            ImgNomor.SetActive(true);
            InfoPelinggih.SetActive(true);
            SetUI(true);
            penanda.SetActive(false);

            txNama.text = pelinggih.GetComponent<Pelinggih>().GetNama();
            txDesk.text = pelinggih.GetComponent<Pelinggih>().GetDeskripsi();
            txNamaInfo.text = pelinggih.GetComponent<Pelinggih>().GetNama();
            txNo.text = pelinggih.GetComponent<Pelinggih>().GetIndex().ToString();
        }
    }

    

}