using UnityEngine;
using System.Collections;

public class MovingPlatformSimple : MonoBehaviour {
	
	public float Dist = 3f;
	public float Speed = 1f;
	public float SwitchAfterTime = 3f;
	public bool Offset = false;
	
	private float etime = 0f;
	private float change_dir = 1f;
	private float platform_dir = 0f;
	
	void Start()
	{
		if(Offset)
			change_dir = -change_dir;
	}
	
	void FixedUpdate()
	{
		if(etime > SwitchAfterTime)
		{
			change_dir = -change_dir;
			etime = 0f;
		}

		else
		{
			etime = etime + 0.02f;
			
			platform_dir = change_dir * Time.deltaTime * Dist * Speed;
			
			transform.Translate (new Vector3 (platform_dir, 0, 0));
		}
	}
}
