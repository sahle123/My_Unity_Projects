using UnityEngine;
using System.Collections;

public class RotatingHandle : MonoBehaviour {

	private float etime = 0f;
	private float etime_limit = 4.2f;
	private float switchRotationSpeed = 20f;

	// The handle rotates
	void FixedUpdate()
	{
		float dTime = Time.fixedDeltaTime;

		if(etime <= etime_limit)
		{
			transform.Rotate(Vector3.forward, switchRotationSpeed * dTime);
			etime = etime + dTime;
		}
	}
}
