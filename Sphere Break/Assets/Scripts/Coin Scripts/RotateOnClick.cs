using UnityEngine;
using System.Collections;

public class RotateOnClick : MonoBehaviour {

	bool SELECTED = false; 
	bool STOPPED = true; 	// For efficiency 
	int MV_SPEED = 3; 		// Make sure it is divisble by 360

	void Start()
	{
		Debug.Log ("RotateOnClick.cs is running.");
		SELECTED = false;
		STOPPED = true;
		MV_SPEED = 3;
	}

	void OnMouseUp()
	{
		SELECTED = !SELECTED;
	}

	void Update()
	{
		// Start Rotation
		if (SELECTED)
		{
			transform.Rotate (Vector3.forward, MV_SPEED);
			STOPPED = false;
		}
		// Stop rotation (Should only run one frame)
		else if (!SELECTED && !STOPPED)
		{
			Debug.Log("Ping");
			transform.rotation = Quaternion.Euler (270, 0, 0);
			STOPPED = true; 
		}
	}
}
