using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour 
{
	private string targetLayerName = "Target";
	private Vector3 origin = new Vector3 (0f, 0f, -5f);
	private Vector3 direction = new Vector3(0f, 0f, 1f);

	void Update()
	{
		//Here is where you should do your raycasting
		/*if(Physics.Raycast ())
		{

		}*/
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine (origin, origin + direction * 100f);
	}
}