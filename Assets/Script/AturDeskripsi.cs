using UnityEngine;
using UnityEngine.UI;

public class AturDeskripsi : MonoBehaviour
{
    private bool[] isMarker;
    private GameObject pelinggih;
    private int hitungMarker;
    private AudioSource audioSource; // Tambahkan AudioSource
    [SerializeField] int jmlMarker;
    [SerializeField] private Text txNama, txDesk;

    private void Start()
    {
        isMarker = new bool[jmlMarker];
        audioSource = gameObject.AddComponent<AudioSource>(); // Tambahkan AudioSource ke GameObject saat ini

        // Opsional: Konfigurasi pengaturan AudioSource
        audioSource.playOnAwake = false; // Nonaktifkan playOnAwake agar tidak diputar secara otomatis
        audioSource.volume = 1.0f; // Sesuaikan volume sesuai kebutuhan
        audioSource.loop = false; // Setel ke true jika ingin audio diputar berulang
    }

    public void SetMarkerOn(int indexMarker)
    {
        if (!isMarker[indexMarker])
        {
            isMarker[indexMarker] = true;
            hitungMarker++;

            // Memutar AudioClip dari Pelinggih saat marker terdeteksi
            if (pelinggih != null)
            {
                AudioClip audioClip = pelinggih.GetComponent<Pelinggih>().GetAudioDeskripsi();
                if (audioClip != null)
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                }
            }
        }
    }

    public void SetMarkerOff(int indexMarker)
    {
        if (isMarker[indexMarker])
        {
            isMarker[indexMarker] = false;
            hitungMarker--;

            // Menghentikan pemutaran AudioClip saat marker tidak terdeteksi
            audioSource.Stop();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (hitungMarker == 0)
        {
            SetUI(false);
            return;
        }

        if (pelinggih != null)
        {
            SetUI(true);

            // Mengambil nilai hanya jika ada marker aktif
            txNama.text = pelinggih.GetComponent<Pelinggih>().GetNama();
            txDesk.text = pelinggih.GetComponent<Pelinggih>().GetDeskripsi();
        }
    }
}
