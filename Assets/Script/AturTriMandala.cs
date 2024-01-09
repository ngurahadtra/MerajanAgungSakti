using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AturTriMandala : MonoBehaviour
{
    public static AturTriMandala instance;
    public int ID;
    public GameObject[] TempatSpawn;
    public GameObject[] Pelinggih;

    // Tambahkan array untuk menyimpan skala khusus untuk setiap objek
    public Vector3[] customScales;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (ID >= 0 && ID < Pelinggih.Length && TempatSpawn.Length > 0)
        {
            GameObject benda = Instantiate(Pelinggih[ID]);
            GameObject tempat = TempatSpawn[0];

            // Periksa apakah customScales memiliki ukuran yang sesuai dengan jumlah objek
            if (customScales.Length == Pelinggih.Length)
            {
                // Set skala sesuai dengan nilai customScales yang sesuai dengan ID objek
                benda.transform.localScale = customScales[ID];
            }
            else
            {
                Debug.LogError("Jumlah skala khusus tidak sesuai dengan jumlah objek.");
                return;
            }

            benda.transform.SetParent(tempat.transform, false);
            benda.transform.localPosition = new Vector3(0, 0, 0);
            benda.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        }
        else
        {
            Debug.LogError("ID diluar rentang atau array TempatSpawn kosong.");
        }
    }
}
