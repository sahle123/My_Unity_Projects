using UnityEngine;
using System.Collections;

public class ScytheSwing : MonoBehaviour {
	
	public AudioClip SoundFx; 	// SFX for the scythe swing.
	public GameObject BlueSoul; // The object the current object will transform into when the scythe connects with the target.
	public int ArraySize;		// Array size for all the different sound clips.
	public AudioClip[] RedSoulDeath; // The different death SFX for destroyed object.

	private int RedSoulSFXCount = 0;	// Count for which death SFX to use.
	private BoxCollider BoxComponent; 	// For caching GetComponent.


	// Caching all the GetComponent<T> calls
	void Start()
	{
		BoxComponent = gameObject.GetComponent<BoxCollider> (); 
	}

	// Handler for killing Angry Souls
	void OnTriggerEnter(Collider theTrigger)
	{
		if((theTrigger.gameObject.tag == "Angry_Soul"))
		{
			Destroy (theTrigger.gameObject);
			Instantiate (BlueSoul, theTrigger.transform.position, Quaternion.identity);

			// To play different sound effects for soul upon death.
			GetComponent<AudioSource>().PlayOneShot (RedSoulDeath[RedSoulSFXCount], 1f);
			RedSoulSFXCount = (RedSoulSFXCount + 1) % ArraySize;
			//Debug.Log ("I played: " + RedSoulDeath[RedSoulSFXCount].name);
		}

		// Special case: Angry Souls that are triggers
		if (theTrigger.gameObject.tag == "Angry_Soul_Trigger")
		{
			// Can be found in ActivateSwitchPlatform.cs
			ActivateSwitchPlatform.isAngrySoulDead = true;

			Destroy (theTrigger.gameObject);
			Instantiate (BlueSoul, theTrigger.transform.position, Quaternion.identity);

			// To play different sound effects for soul upon death.
			GetComponent<AudioSource>().PlayOneShot (RedSoulDeath[RedSoulSFXCount], 1f);
			RedSoulSFXCount = (RedSoulSFXCount + 1) % ArraySize;
		}
	}

	// Scythe Swing animation and triggers
	void Update()
	{
		if((Input.GetMouseButtonDown (0)) || (Input.GetKeyDown (KeyCode.V)))
		{
			if(!GetComponent<Animation>().isPlaying)
			{
				GetComponent<Animation>().Play("Scythe_Animation 3");
				GetComponent<AudioSource>().PlayOneShot(SoundFx, 0.5f);
				//gameObject.GetComponent<BoxCollider>().enabled = true;
				BoxComponent.enabled = true;
			}
		}
		else if(!GetComponent<Animation>().isPlaying)
		{
			BoxComponent.enabled = false;
			//gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}


}
