using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float Dist = 3f;
	public float Speed = 1f;

	private float platform_dir = 0f;

	void FixedUpdate()
	{
		platform_dir = Time.deltaTime * Dist * Speed;
			
		transform.Translate (new Vector3 (platform_dir, 0, 0));
	}
}
