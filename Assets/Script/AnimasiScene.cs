using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimasiScene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animasiAwal = "Tombol";
    [SerializeField] private string animasiKlik = "Klik";

    private bool isAnimating = false;
    private bool isFirstTime = true;
    private bool exitButtonClicked = false; // Tambahkan variabel untuk menandakan apakah tombol keluar diklik

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null && !string.IsNullOrEmpty(animasiAwal))
        {
            if (isFirstTime)
            {
                // Memainkan animasi awal hanya saat pertama kali memulai scene
                animator.Play(animasiAwal);
                isFirstTime = false;
            }
        }
    }

    public void AnimasiDanPindah(string scene_name)
    {
        if (!isAnimating)
        {
            exitButtonClicked = false; // Reset variabel exitButtonClicked
            AnimasiKlik();
            StartCoroutine(PindahSceneSetelahAnimasiSelesai(scene_name));
        }
    }

    public void KeluarAplikasi()
    {
        exitButtonClicked = true; // Set variabel exitButtonClicked menjadi true saat tombol keluar diklik
        if (!isAnimating)
        {
            AnimasiKlik();
            StartCoroutine(ExitApplicationAfterAnimation());
        }
    }

    private void AnimasiKlik()
    {
        if (animator != null && !string.IsNullOrEmpty(animasiKlik))
        {
            isAnimating = true;
            animator.Play(animasiKlik);
            // Memanggil fungsi yang akan mengatur ulang animator setelah animasi selesai
            StartCoroutine(ResetAnimasiSetelahSelesai());
        }
    }

    private IEnumerator PindahSceneSetelahAnimasiSelesai(string scene_name)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Setelah animasi selesai, pindah scene
        SceneManager.LoadScene(scene_name);
    }

    private IEnumerator ResetAnimasiSetelahSelesai()
    {
        // Menunggu durasi animasi selesai (sesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Setelah animasi selesai, kembalikan ke animasi awal tanpa menjalankannya lagi
        if (!string.IsNullOrEmpty(animasiAwal))
        {
            animator.Play(animasiAwal, 0, 1.0f); // Set progress ke akhir animasi
        }

        // Atur status animating kembali ke false
        isAnimating = false;

        // Jika tombol keluar diklik, keluar dari aplikasi setelah animasi tombol selesai
        if (exitButtonClicked)
        {
            StartCoroutine(ExitApplicationAfterAnimation());
        }
    }

    private IEnumerator ExitApplicationAfterAnimation()
    {
        // Menunggu durasi animasi selesai (sesuaikan dengan durasi animasi Anda)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
