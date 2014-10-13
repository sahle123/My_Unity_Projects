using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	public void Awake()
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
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
	}

	
	/*
	void Start()
	{

		// This script will save the object that it is associated with
		// between levels. 
		DontDestroyOnLoad (gameObject); 
	}*/

}
