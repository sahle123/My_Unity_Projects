using UnityEngine;
using System.Collections;

// Note that this script will only work for one instance of
// the object in the game. If multiple objects that use
// this script are in the game, the objects won't
// function properly. (Using a public static. Refactor later...)
public class ActivateSwitchPlatform : MonoBehaviour {

	public static bool isAngrySoulDead; // Skip trigger if angry soul is not dead.

	public AudioClip SoundFx;
	public MovingVerticalPlatformUnique MovingPlatScript; // Script for moving platform.
	
	private bool is_opening = false; // A bool to make sure the animation will only run once.


	// Initialize the movingplatform script as false so it doesn't move.
	void Start()
	{
		MovingPlatScript.enabled = false;
	}

	// Run animation once and actiave platform script.
	void OnTriggerEnter(Collider theTrigger)
	{
		if(!isAngrySoulDead)
			return;

		if((theTrigger.gameObject.tag == "The_Player") && !(is_opening))
		{
			is_opening = true;
			audio.PlayOneShot(SoundFx, 1f);

			// Animate hinge and activate platform script.
			if(is_opening)
			{
				transform.FindChild ("Rotation_Point").GetComponent<RotatingHandle>().enabled = true;
				MovingPlatScript.enabled = true;
			}
		}
	}
}
