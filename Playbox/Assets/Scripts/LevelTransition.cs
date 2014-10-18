using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	public int myValue = 30;

	public void Awake()
	{

		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
			//Debug.Log ("My value is now: " + myValue);
		}
	}

	// This works with DontDestroyOnLoad
	void OnLevelWasLoaded(int level)
	{
		Debug.Log ("We loaded the " + level + " level");
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(Application.loadedLevelName == "Scene 1")
			{
				Application.LoadLevel ("Scene 2");
			}
			else if (Application.loadedLevelName == "Scene 2")
			{
				Application.LoadLevel ("Scene 1");
			}
			else
			{
				Debug.Log ("I think something went wrong...");
			}
		}
		// When users presses the A key.
		if(Input.GetKeyUp(KeyCode.A))
		{
			myValue = 50;
			Debug.Log ("My value is set to: " + myValue);
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			Debug.Log ("My value is now: " + myValue);
		}
	}

	
	/*
	void Start()
	{

		// This script will save the object that it is associated with
		// between levels. 
		DontDestroyOnLoad (gameObject); 
	}*/

}
