//
// 	Script to keep object stuck to terrain.
//	
//	03/03/15
//	Nomad

using UnityEngine;

public class MoveAndStick : MonoBehaviour 
{	
	public Terrain leTerrain;
	public float magnitude = 5f;
	
	void Update () 
	{
		Vector3 lePosition = transform.position;
		
		// Move according to user input
		lePosition += new Vector3 (Input.GetAxis ("Horizontal") * magnitude, 0f, Input.GetAxis ("Vertical") * magnitude);
		
		// Set out height to the terrain
		lePosition.y = leTerrain.SampleHeight (transform.position) + magnitude;
		
		// Update the position of the object
		transform.position = lePosition;
	}
}
