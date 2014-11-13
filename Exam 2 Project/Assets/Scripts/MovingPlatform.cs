using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	public float Speed = 1f;
	private float platform_dir = 0f;

	void FixedUpdate()
	{
		platform_dir = platform_dir + Speed * Time.deltaTime;
		rigidbody.MovePosition(new Vector3 (platform_dir, 0, 0));
	}
}