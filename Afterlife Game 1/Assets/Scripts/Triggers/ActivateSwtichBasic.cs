using UnityEngine;
using System.Collections;

public class ActivateSwtichBasic : MonoBehaviour {

	public AudioClip SoundFx;
	
	private bool is_opening = false; // A bool to make sure the animation will only run once.
	
	void OnTriggerEnter(Collider theTrigger)
	{
		if((theTrigger.gameObject.tag == "The_Player") && !(is_opening))
		{
			is_opening = true;
			GetComponent<AudioSource>().PlayOneShot(SoundFx, 1f);

			if(is_opening)
				transform.FindChild ("Rotation_Point").GetComponent<RotatingHandle>().enabled = true;
		}
	}
}
