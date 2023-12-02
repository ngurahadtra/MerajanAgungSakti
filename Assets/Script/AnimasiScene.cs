using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimasiScene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animasiAwal = "Tombol"; // Sesuaikan dengan nama animasi awal tombol Mulai
    [SerializeField] private string animasiKlik = "Klik";

    private void Awake()
    {
        // Dapatkan komponen Animator pada objek ini
        animator = GetComponent<Animator>();
        
        // Memulai animasi awal saat scene dimulai
        if (animator != null && !string.IsNullOrEmpty(animasiAwal))
        {
            animator.Play(animasiAwal);
        }
    }

    public void AnimasiDanPindah(string scene_name)
    {
        // Memanggil fungsi animasi klik
        AnimasiKlik();

        // Pindah scene setelah animasi klik selesai
        StartCoroutine(PindahSceneSetelahAnimasiSelesai(scene_name));
    }

    private void AnimasiKlik()
    {
        // Memanggil fungsi animasi klik
        if (animator != null && !string.IsNullOrEmpty(animasiKlik))
        {
            animator.Play(animasiKlik);
        }
    }

    private IEnumerator PindahSceneSetelahAnimasiSelesai(string scene_name)
    {
        // Menunggu durasi animasi selesai (sesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Pindah scene setelah animasi selesai
        SceneManager.LoadScene(scene_name);
    }
}
