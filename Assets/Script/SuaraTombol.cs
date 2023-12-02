using UnityEngine;
using UnityEngine.UI; // Jika tombol menggunakan komponen UI

public class SuaraTombol : MonoBehaviour
{
    public AudioClip suaraKlik; // Asumsikan ada variabel untuk menyimpan suara klik

    private void Start()
    {
        // Mendapatkan komponen Button (sesuaikan dengan jenis komponen UI yang digunakan)
        Button tombol = GetComponent<Button>();

        // Mengecek jika tombol ada dan audio clip telah diatur
        if (tombol != null && suaraKlik != null)
        {
            // Menambahkan fungsi untuk memainkan suara saat tombol diklik
            tombol.onClick.AddListener(PutarSuaraKlik);
        }
    }

    private void PutarSuaraKlik()
    {
        // Memainkan suara klik
        AudioSource.PlayClipAtPoint(suaraKlik, Camera.main.transform.position);
    }
}
