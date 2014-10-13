using UnityEngine;
using System.Collections;

public class RotatingPlatform : MonoBehaviour {
			
	public float rotationSpeed = 30f;
		
	void FixedUpdate()
	{
		float t_time = Time.fixedDeltaTime;
			
		transform.Rotate(Vector3.up, rotationSpeed * t_time);
	}
}
