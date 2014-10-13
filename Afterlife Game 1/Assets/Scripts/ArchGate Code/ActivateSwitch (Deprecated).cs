using UnityEngine;
using System.Collections;

// There are some good examples in here to learn from. Do NOT delete this code.
public class ActivateSwitchDeprecated : MonoBehaviour {
	
	public AudioClip SoundFx;

	private bool is_opening = false;
	
	void OnTriggerEnter(Collider theTrigger)
	{
		if((theTrigger.gameObject.tag == "The_Player") && !(is_opening))
		{
			is_opening = true;
			audio.PlayOneShot(SoundFx, 1f);

			/*** Code for activating child script ***/
			if(is_opening)
			{
				// This part took FOREVER!!! The Unity community doesn't have any good examples for this.
				// Looks for children and enables their specific scripts. Oneshot type.
				transform.FindChild ("Gate_Origin_Point").GetComponent<ManualMovingGate>().enabled = true;
				transform.FindChild ("Rotation_Point").GetComponent<RotatingHandle>().enabled = true;
			}
		}
	}
}


// Broken code
		/*
		 * transform.FindChild("Gate_Origin_Point").GetComponent<ManualMovingGate>().enabled = true;
		 * GameObject.Find("Gate_Origin_Point").GetComponent<ManualMovingGate>().enabled = true;
		 */

		/* 
		 * theGate = GameObject.Find ("Gate_Origin_Point");
		 * theScript = theGate.GetComponent<ManualMovingGate>();
		 * theScript.enabled = true;
 		 */