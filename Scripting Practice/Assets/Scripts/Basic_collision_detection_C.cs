using UnityEngine;
using System.Collections;

public class Basic_collision_detection_C : MonoBehaviour {

	void OnCollisionEnter(Collision theCollision)
	{
		if(theCollision.gameObject.name == "Floor")
		{
			Debug.Log ("Hit the Floor!");
		}
	}

	void OnCollisionStay(Collision theCollision)
	{
		// Code
	}

	void OnCollisionExit(Collision theCollision)
	{
		// Code
	}
}
