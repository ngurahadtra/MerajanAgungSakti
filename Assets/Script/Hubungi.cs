using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hubungi : MonoBehaviour
{
    public void BukaEmail(string email)
    {
        Application.OpenURL("mailto:" + email);
    }

    public void KirimWhatsapp(string nomor)
    {
        Application.OpenURL("https://wa.me/" + nomor);
    }

    public void BukaInstagram(string username)
    {
        Application.OpenURL("https://www.instagram.com/" + username);
    }

    public void BukaTikTok(string username)
    {
        Application.OpenURL("https://www.tiktok.com/@" + username);
    }

    public void BukaTelegram(string username)
    {
        Application.OpenURL("https://t.me/" + username);
    }

    public void BukaFacebook(string username)
    {
        Application.OpenURL("https://www.facebook.com/" + username);
    }

        public void BukaLine(string lineID)
    {
        Application.OpenURL("line://ti/p/~" + lineID);
    }

    public void BukaGoogleMaps(string googleMapsUrl)
    {
        Application.OpenURL(googleMapsUrl);
    }
}
