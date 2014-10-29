using UnityEngine;
using System.Collections;

// I guess we cannot put global vars here.

public class Applied_Force_C : MonoBehaviour {

	// Need to add f at the end of floats to state they are floats and NOT doubles.
	public float Power = 500.0f; 

	void Start () 
	{
		rigidbody.AddForce (new Vector3(-Power, 0, 0));		
	}
}
