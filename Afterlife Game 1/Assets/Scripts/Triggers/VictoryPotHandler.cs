using UnityEngine;
using System.Collections;

public class VictoryPotHandler : MonoBehaviour {

	public AudioClip SoundFX;
	public AudioClip Milfanito;

	private float timerOffset = 6f; // This is so the SoundFX doesn't keep playing when player interacts.
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
			GetComponent<AudioSource>().PlayOneShot (SoundFX, 0.4f);
			waitOnSound = true;
		}
	}

	void Update()
	{
		if(!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = Milfanito;
			GetComponent<AudioSource>().Play ();
		}
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
