using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsound : MonoBehaviour
{
    private static backsound instance = null;

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

            // Mengecek apakah audio sedang diputar
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            // Menetapkan nama objek
            gameObject.name = "backsound on";

            // Mengatur volume dari PlayerPrefs
            PlayerPrefs.SetFloat("volume", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Memperbarui volume sesuai preferensi
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }
}
