using UnityEngine;
using System.Collections;

public class VictoryPotHandler2 : MonoBehaviour {

	public AudioClip SoundFX;
	
	private float timerOffset = 15f; // This is so the SoundFX doesn't keep playing when player interacts.
	private float elapsedTime = 0f;
	private bool waitOnSound = false;
	
	void OnTriggerEnter(Collider theTrigger)
	{
		if(GUI_Finished.metQuota == true)
		{
			GUI_Finished.reachedPot = true;
		}
		else if ((theTrigger.gameObject.tag == "The_Player")&&(!waitOnSound))
		{
			waitOnSound = true;
			audio.PlayOneShot (SoundFX, 0.4f);
		}
	}
	
	void Update()
	{
		if(elapsedTime < timerOffset)
		{
			elapsedTime += Time.deltaTime;
		}
		else
		{
			elapsedTime = 0;
			waitOnSound = false;
		}
	}
}
