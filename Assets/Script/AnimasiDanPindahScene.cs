using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimasiDanPindahScene : MonoBehaviour
{
    public void AnimasiDanPindah(string scene_name)
    {
        // Memanggil fungsi animasi
        Animasi();

        // Pindah scene setelah animasi selesai (gunakan Invoke jika Anda tahu durasi animasi)
        StartCoroutine(PindahSceneSetelahAnimasiSelesai(scene_name));
    }

    private void Animasi()
    {
        // Ganti "Tombol" dengan nama animasi yang ingin Anda mainkan
        GetComponent<Animation>().Play("Tombol");
    }

    private IEnumerator PindahSceneSetelahAnimasiSelesai(string scene_name)
    {
        // Menunggu durasi animasi selesai (sesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(GetComponent<Animation>().clip.length);

        // Pindah scene setelah animasi selesai
        SceneManager.LoadScene(scene_name);
    }
}
