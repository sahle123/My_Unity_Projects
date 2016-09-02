using UnityEngine;
using System.Collections;

public class Bitmasks : MonoBehaviour {
	
	void Start () 
	{
		// Getting the bitmask of the layer "Box 1"
		int bitmask = 1 << LayerMask.NameToLayer ("Box 1");
		// int bitmask = 1 << LayerMask.NameToLayer ("Box 1") + 1; // This will get the next layer after Box 1.

		Ray myRay = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2f, Screen.height / 2f));
		RaycastHit theHit;

		if(Physics.Raycast (myRay, out theHit, 100f, bitmask))
		{
			Debug.Log ("Hit " + theHit.transform.name);
		}


		// Camera culling. This will cull all objects in layer 8 (Box 1 layer).
		GetComponent<Camera>().cullingMask = GetComponent<Camera>().cullingMask & ~(1 << LayerMask.NameToLayer ("Box 1"));
	}
}
