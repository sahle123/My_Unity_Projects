using UnityEngine;
using System.Collections;

public class Example_script : MonoBehaviour {

	// This is called when the script is loaded
	// Should treat this as a constructor
	void Awake () 
	{
		Debug.Log ("Awake Method.");
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("This is the Start method.");
	}
	
	// Update is called once per frame
	// This will happen as fast as possible
	void Update () 
	{
		//Debug.Log ("Update time: " + Time.time);
		//Debug.Log ("Update log: " + Time.deltaTime);
	}

	// Happens at a user-defined rate.
	void FixedUpdate()
	{
		//Debug.Log ("Fixed Update Log: " + Time.fixedDeltaTime);
	}
}
