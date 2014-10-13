using UnityEngine;
using System.Collections;

// Scythe powerup pickup script. This goes script works hand-in-hand with GUI_Finished.cs
public class ScythePowerUp : MonoBehaviour {

	// Watch the Player
	void Update () 
	{
		transform.LookAt (Camera.main.transform.position, Vector3.up);
	}

	// Despawn on Player touch. Code for enabling scythe in the player object.
	void OnTriggerEnter(Collider theTrigger)
	{
		if(theTrigger.gameObject.tag == "The_Player")
		{
			Destroy(gameObject);
		}
	}
}
