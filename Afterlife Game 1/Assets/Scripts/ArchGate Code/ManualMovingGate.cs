using UnityEngine;
using System.Collections;

public class ManualMovingGate : MonoBehaviour {

	public float dist = 2.0f;
	public AudioClip SoundFx;

	private float etime = 0f;
	private float etime_limit = 3f;
	private float moving_parts = 0f;


	void Start()
	{
		audio.PlayOneShot (SoundFx, 1f);
	}

	void FixedUpdate()
	{
		if(etime <= etime_limit)
		{
			moving_parts = Time.fixedDeltaTime * dist;
			transform.Translate( new Vector3 (0, moving_parts ,0));
			etime = etime + Time.fixedDeltaTime;
		}
	}

	/*public float dist = 1.8f;
	
	public static bool is_switch_activated = false;

	private float etime = 0f;
	private float etime_limit = 3f;
	private float moving_parts = 0f;
	
	void FixedUpdate()
	{
		if(is_switch_activated)
		{
			if(etime <= etime_limit)
			{
				moving_parts = Time.fixedDeltaTime * dist;
				transform.Translate( new Vector3 (0, moving_parts ,0));
				etime = etime + Time.fixedDeltaTime;
			}
		}
	}*/
}
