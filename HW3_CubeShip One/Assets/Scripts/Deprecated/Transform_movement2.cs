using UnityEngine;
using System.Collections;

public class Transform_movement2 : MonoBehaviour {
	
	public float strength = 0.2f; // How strong the movement will be. Very sensitive!!
	private float height = 0.8f;
	
	// These are the x and z starting positions of the Player.
	public float zDirection = 0;
	public float rotationDirection = 0;
	
	
	void FixedUpdate()
	{
		rigidbody.angularDrag = 20;
		
		// Get the button press
		float zAxis_Button_press = Input.GetAxis ("Vertical");
		float rotationAxis_Button_press = Input.GetAxis ("Horizontal");
		
		// Update position value
		zDirection = zDirection + zAxis_Button_press * strength;

		rotationDirection = rotationDirection + rotationAxis_Button_press;
		Quaternion rotation = Quaternion.Euler (new Vector3(0, rotationDirection, 0));

		// Update position
		rigidbody.MovePosition (new Vector3(0, height, zDirection));
		//transform.TransformDirection(new Vector3 (0, height, zDirection));
		//transform.InverseTransformPoint (new Vector3(0, height, zDirection));
		//transform.position = transform.InverseTransformDirection(new Vector3(0, height, zDirection));
		rigidbody.MoveRotation (rotation);
	}
}
