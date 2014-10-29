using UnityEngine;
using System.Collections;

public class Translate_rotate_example : MonoBehaviour {

	public float moveSpeed = 10f;
	public float turnSpeed = 50f;

	void Update()
	{
		float movement = Input.GetAxis ("Vertical") * moveSpeed;
		float rotation = Input.GetAxis ("Horizontal") * turnSpeed;
		float t_time = Time.deltaTime;

		// Update positions
		transform.Translate (Vector3.forward * movement * t_time);
		transform.Rotate (Vector3.up, rotation * t_time);
	}

}
