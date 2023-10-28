using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiTombol : MonoBehaviour
{
	public void Animasi()
	{
		GetComponent<Animation>().Play("Tombol");
	}
}
