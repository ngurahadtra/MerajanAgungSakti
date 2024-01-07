using UnityEngine;

public class InfoPelinggih : MonoBehaviour
{
    public AturDeskripsi aturDeskripsi; // Seret dan lepaskan objek AturDeskripsi ke sini melalui Inspector

    private void OnMouseDown()
    {
        // Panggil fungsi atau metode di AturDeskripsi untuk mengaktifkan atau memulai audio deskripsi
        aturDeskripsi.SetPelinggih(gameObject);
    }
}
