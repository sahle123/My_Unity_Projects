using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour 
{
	private string targetLayerName = "Target";
	private Vector3 origin = new Vector3 (0f, 0f, -5f);
	private Vector3 direction = new Vector3(0f, 0f, 1f);
	private int bitmask;

	void Start()
	{
		bitmask = 1 << LayerMask.NameToLayer (targetLayerName);
	}
	void Update()
	{
		Ray myRay = Camera.main.ScreenPointToRay (new Vector3 (Screen.width/2f, Screen.height/2f));
		RaycastHit theHit;

		//Here is where you should do your raycasting
		if(Physics.Raycast (myRay, out theHit, 100f, bitmask))
		{
			Debug.Log ("We hit the " + theHit.transform.name);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine (origin, origin + direction * 100f);
	}
}