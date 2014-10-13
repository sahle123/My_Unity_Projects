using UnityEngine;
using System.Collections;

public class LoadedLevel : MonoBehaviour {

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
			Debug.Log (Application.loadedLevelName);
	}
}
