using UnityEngine;

public class Pelinggih : MonoBehaviour
{
    [SerializeField] private string nama;
    [SerializeField] [TextArea] private string deskripsi;
    [SerializeField] private AudioClip audioDeskripsi; 
    [SerializeField] private int pelinggihIndex;

    public int GetIndex()
    {
      return pelinggihIndex;
    }
    
    public string GetNama()
    {
        return nama;
    }

    public string GetDeskripsi()
    {
        return deskripsi;
    }

    public AudioClip GetAudioDeskripsi()
    {
        return audioDeskripsi;
    }
}
