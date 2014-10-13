using UnityEngine;
using System.Collections;

public class MovingGate : MonoBehaviour {
	
	public float dist = 2.0f; // This will be a multiple of the transform distance limit. Sort of...
	public AudioClip SoundFx;

	private float etime = 0f;
	private float etime_limit = 3f;
	private float moving_parts = 0f;

	private bool is_opening = false;
	
	void OnTriggerEnter (Collider theTrigger)
	{
		if((theTrigger.gameObject.tag == "The_Player") && !(is_opening))
		{
			is_opening = true;
			audio.PlayOneShot (SoundFx, 1f);
		}
	}
	
	void FixedUpdate()
	{
		if(is_opening)
		{
			if(etime <= etime_limit)
			{
				moving_parts = Time.fixedDeltaTime * dist;
				transform.Translate( new Vector3 (0, moving_parts ,0));
				etime = etime + Time.fixedDeltaTime;
			}
		}
	}
}
