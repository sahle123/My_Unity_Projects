using UnityEngine;
using System.Collections;

public class GUI_Simple : MonoBehaviour {

	public int score = 0;
	public int IncrementRate = 5;
	public int DecrementRate = 10;
	public int MegaSoulRate = 25;
	public AudioClip SoundFx;

	void OnGUI()
	{
		GUI.Label (new Rect (30, 40, 120, 20), "Souls: ");
	}

	// Trigger for despawning souls and giving points.
	void OnTriggerEnter (Collider theTrigger)
	{
		//Debug.Log ("Trigger!");
		//Debug.Log ("Wahhhh~~~");
		if((theTrigger.gameObject.name == "Collectable_Soul")||
		   (theTrigger.gameObject.name == "Collectable_Soul2(Clone)"))
		{
			//Debug.Log ("OnTriggerEnter if statement ran");
			score = score + IncrementRate;
			Destroy (theTrigger.gameObject);

			AudioSource.PlayClipAtPoint(SoundFx, theTrigger.transform.position, 0.5f); // This seems to work, but I am not sure about it...
			//audio.PlayOneShot(SoundFx, 0.6f);

			//theTrigger.audio.clip = SoundFx;
			//theTrigger.audio.Play ();
		}

		// Negative soul handler
		else if ((theTrigger.gameObject.name == "Negative_Soul")||
		         (theTrigger.gameObject.name == "Angry_Soul"))
		{
			score = score - DecrementRate;

			Destroy (theTrigger.gameObject);

			AudioSource.PlayClipAtPoint (SoundFx, theTrigger.transform.position, 0.5f);
		}

		// Mega soul handler
		else if (theTrigger.gameObject.name == "Mega_Soul")
		{
			score = score + MegaSoulRate;
			
			Destroy (theTrigger.gameObject);
			
			AudioSource.PlayClipAtPoint (SoundFx, theTrigger.transform.position, 1f);
		}
	}
}
