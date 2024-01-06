using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AturDeskripsi : MonoBehaviour
{
    private bool[] isMarker;
    private GameObject pelinggih;
    private int hitungMarker;
    [SerializeField] private Text txNama, txDesk;

    public void SetMarkerOn(int indexMarker)
    {
        if (!isMarker[indexMarker])
        {
            isMarker[indexMarker] = true;
            hitungMarker++;
        }
    }

    public void SetMarkerOff(int indexMarker)
    {
        if (isMarker[indexMarker])
        {
            isMarker[indexMarker] = false;
            hitungMarker--;
        }
    }

    public void SetPelinggih(GameObject pelinggih)
    {
        this.pelinggih = pelinggih;
    }

    private void SetUI(bool b)
    {
        txNama.transform.parent.gameObject.SetActive(b);
        txDesk.transform.parent.gameObject.SetActive(b);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitungMarker == 0)
        {
            SetUI(false);
            return;
        }

        if(pelinggih != null)
        {
            SetUI(true);

            for(int i=0; i < isMarker.Length; i++)
            {
                txNama.text = pelinggih.GetComponent<Pelinggih>().GetNama();
                txDesk.text = pelinggih.GetComponent<Pelinggih>().GetDeskripsi();
            }
        }
    }
}
