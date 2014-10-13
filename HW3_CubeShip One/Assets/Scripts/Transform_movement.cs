using UnityEngine;
using System.Collections;

public class Transform_movement : MonoBehaviour {

	public float strength = 1.5f; // How strong the movement will be. Very sensitive!!
	public int health = 100;
	public float drag = 3f;
	
	// These are the x and z starting positions of the Player.
	private float xDirection = 0;
	private float zDirection = 0;
	private float height = 0.8f;

	void FixedUpdate()
	{

		// Get the button press
		float xAxis_Button_press = Input.GetAxis ("Horizontal");
		float zAxis_Button_press = Input.GetAxis ("Vertical");

		// Update position value
		xDirection = xAxis_Button_press * strength;
		zDirection = zAxis_Button_press * strength;

		if((Input.GetButton("Horizontal")) || (Input.GetButton("Vertical")))
			rigidbody.drag = 0;
		else
			rigidbody.drag = drag;

		// Update position
		rigidbody.AddForce (xDirection, height, zDirection);
	

		// Reset to start if health hits zero.
		if(health <= 0)
			health = 100;
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 20), "Heatlh: " + health);
	}

	void OnCollisionEnter(Collision theObstacle)
	{
		if(theObstacle.gameObject.name == "Obst_block")
			health = health - 10;
	}
	/*
	void OnTriggerEnter(Collider myTrigger)
	{
		if(myTrigger.gameObject.name == "Obst_block")
			health = health - 10;		
	}*/
	
}
