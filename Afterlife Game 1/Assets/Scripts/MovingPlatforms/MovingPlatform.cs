using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float Dist = 3f;
	public bool Offset = false;
	public float delayTime = 0f;

	private float etime = 0f;
	private float change_dir = 1f;
	private float platform_dir = 0f;
	private float delay_movement = 0f;

	void Start()
	{
		if(Offset)
			change_dir = -change_dir;
	}

	void FixedUpdate()
	{
		if(etime > 3)
		{
			change_dir = -change_dir;
			etime = 0f;
			delay_movement = delayTime;
		}

		if (delay_movement > 0)
		{
			delay_movement = delay_movement - Time.fixedDeltaTime;
		}
		else
		{
			etime = etime + 0.02f;
			
			platform_dir = change_dir * Time.deltaTime * Dist;
			
			//Debug.Log (etime);
			
			transform.Translate (new Vector3 (platform_dir, 0, 0));
		}

		// I can't remember what this section was for...
		//PlatformEven.transform.Translate (new Vector3 (0, 0, platform_dir));
		//PlatformOdd.transform.Translate (new Vector3 (0, 0, -platform_dir));
	}
}
