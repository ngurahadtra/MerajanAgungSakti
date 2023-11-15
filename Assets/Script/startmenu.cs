using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmenu : MonoBehaviour
{
    public void exit(){
        Application.Quit();
    }

    public void sound_volume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

}
