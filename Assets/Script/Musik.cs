using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musik : MonoBehaviour
{
    private static Musik instance = null;
    private AudioSource audioSource;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float initialVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Mengecek apakah objek instance sudah ada
        if (instance != null)
        {
            // Jika instance sudah ada, hancurkan objek yang baru
            Destroy(gameObject);
        }
        else
        {
            // Jika instance belum ada, jadikan objek ini instance
            instance = this;

            DontDestroyOnLoad(gameObject);

            // Mendapatkan komponen AudioSource
            audioSource = GetComponent<AudioSource>();

            // Mengecek apakah audio sedang diputar
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Menetapkan nama objek
            gameObject.name = "Musik";

            // Mengatur volume dari PlayerPrefs atau nilai awal yang diatur di Inspector Unity
            float savedVolume = PlayerPrefs.GetFloat("volume", initialVolume);
            audioSource.volume = savedVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Memperbarui volume sesuai preferensi
        audioSource.volume = PlayerPrefs.GetFloat("volume", initialVolume);
    }
}
