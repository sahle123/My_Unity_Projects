using UnityEngine;
using System.Collections;

public class Transform_movement3 : MonoBehaviour {

	public float strength = 1.5f; // How strong the movement will be. Very sensitive!!
	private float height = 0.8f;
	
	// These are the x and z starting positions of the Player.
	public float xDirection = 0;
	public float zDirection = -41;

	public float health = 25;

	void FixedUpdate()
	{
		
		// Get the button press
		float xAxis_Button_press = Input.GetAxis ("Horizontal");
		float zAxis_Button_press = Input.GetAxis ("Vertical");
		
		// Update position value
		xDirection = xDirection + xAxis_Button_press * strength;
		zDirection = zDirection + zAxis_Button_press * strength;

		
		// Update position
		rigidbody.MovePosition (new Vector3(xDirection, height, zDirection));

		// For keeping cube inside barriers (I had so much trouble implementing collisiond detection...
		if((zDirection < -49) ||(zDirection > 49))
		{
			zDirection = -41;
		}
		else if((xDirection < -49) || (xDirection > 49))
		{
			xDirection = 0;
		}

		// Reset to start if health hits zero.
		if(health <= 0)
		{
			health = 25;
			zDirection = -41;
			xDirection = 0;
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 20), "Heatlh: " + health);
	}

	void OnTriggerEnter(Collider myTrigger)
	{
		if(myTrigger.gameObject.name == "Obst_block")
		{
			health = health - 10;		
		}
		
	}
}
