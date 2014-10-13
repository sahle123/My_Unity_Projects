using UnityEngine;
using System.Collections;

// Basic script for having a sprite (or any object) constantly stare at the player.
public class WatchPlayer : MonoBehaviour {

	void Update()
	{
		transform.LookAt (Camera.main.transform.position, Vector3.up);
	}
}