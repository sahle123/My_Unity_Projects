using UnityEngine;
using System.Collections;

// Attach to camera. This will get the raycast of
// the camera and determine if there was a hit
// on any object.
public class Raycast : MonoBehaviour {

	void Update () 
	{
		Ray myRay = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit; // Get information back from the ray hit.
		float hitDistance = 0f;

		if(Physics.Raycast (myRay, out hit))
		{
			Debug.Log ("I hit something in frame: " + Time.frameCount);
			hitDistance = hit.distance;
		}

		// This will draw a debug line.
		Debug.DrawRay (myRay.origin, myRay.direction * hitDistance);
	}
}
