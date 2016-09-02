using UnityEngine;
using System.Collections;

public class ActivateSwitch : MonoBehaviour {

	public AudioClip SoundFx;
	public ManualMovingGate gateScript;
	
	private bool is_opening = false;
	
	void OnTriggerEnter(Collider theTrigger)
	{
		if((theTrigger.gameObject.tag == "The_Player") && !(is_opening))
		{
			is_opening = true;
			GetComponent<AudioSource>().PlayOneShot(SoundFx, 1f);

			if(is_opening)
			{
				gateScript.enabled = true;
				transform.FindChild ("Rotation_Point").GetComponent<RotatingHandle>().enabled = true;
			}
		}
	}
}
