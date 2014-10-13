using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public AudioClip myClip;
	
	void Start () {
		audio.PlayOneShot (myClip);
	}
}
