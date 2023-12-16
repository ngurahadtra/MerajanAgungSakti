using System.Collections;
using UnityEngine;

public class Musik : MonoBehaviour
{
    private static Musik instance = null;
    private AudioSource audioSource;

    private bool isPlaying = false;

    private float normalVolume; // Volume normal musik utama
    private bool isMusicPlaying = false; // Menandakan apakah musik utama sedang diputar

    private float targetVolume; // Volume yang ingin dicapai
    private Coroutine volumeChangeCoroutine;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Dipanggil sebelum frame pertama
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("isMusicPlaying", 0) == 1)
        {
            PlayPauseMusic();
        }
        else
        {
            PlayPauseMusic();
        }

        gameObject.name = "Musik";

        normalVolume = audioSource.volume;
        targetVolume = normalVolume;
    }

    // Dipanggil setiap frame
    void Update()
    {
        isMusicPlaying = audioSource.isPlaying;
    }

    // Fungsi untuk memainkan atau memberhentikan musik
    public void PlayPauseMusic()
    {
        if (isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }

        isPlaying = !isPlaying;

        PlayerPrefs.SetInt("isMusicPlaying", isPlaying ? 1 : 0);
    }

    // Fungsi untuk mengatur volume ke nilai normal
    public void NormalVolume()
    {
        if (!isMusicPlaying)
        {
            targetVolume = normalVolume;
            StartCoroutine(ChangeVolumeOverTime(audioSource.volume, targetVolume));
        }
    }

    // Fungsi untuk mengatur volume ke nilai yang lebih rendah (0.7f)
    public void TurunVolume()
    {
        if (!isMusicPlaying)
        {
            targetVolume = 0.7f; // Atur nilai sesuai kebutuhan
            StartCoroutine(ChangeVolumeOverTime(audioSource.volume, targetVolume));
        }
    }

    // Coroutine untuk mengubah volume secara perlahan
    private IEnumerator ChangeVolumeOverTime(float startVolume, float targetVolume, float duration = 1.0f)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            // Menghitung progress perubahan volume
            float progress = elapsedTime / duration;

            // Mengubah volume secara perlahan
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, progress);

            // Menunggu satu frame
            yield return null;

            elapsedTime += Time.deltaTime;
        }

        // Pastikan volume mencapai nilai target
        audioSource.volume = targetVolume;

        // Reset coroutine menjadi null untuk memungkinkan coroutine baru dimulai
        volumeChangeCoroutine = null;
    }
}