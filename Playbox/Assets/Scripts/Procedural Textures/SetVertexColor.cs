/*	SetVertexColor.cs
 * 
 * 	Taken from Julien Lynge's Fall 2014 lectures. Attach this to an object you want to paint.
 * 	Sahle Alturaigi
 * 		Novemeber 30th, 2014
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]	// These are C# attributes if you're wondering.
[RequireComponent(typeof(MeshFilter))]
public class SetVertexColor : MonoBehaviour {

	public float charRadius = 0.1f;
	private Mesh leMesh;

	void Start()
	{
		leMesh = GetComponent<MeshFilter> ().mesh;
	}

	void Update()
	{
		if(Input.GetMouseButton (0)) // Left click
		{
			Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayHit;
			if(GetComponent<Collider>().Raycast (myRay, out rayHit, Camera.main.farClipPlane))
			{
				Vector3 hitPoint = rayHit.point;

				// Make the points local to the sphere; vertex position are in local space.
				hitPoint = transform.InverseTransformPoint (hitPoint);

				// Go through the vertices of the mesh and 'char' as appropriate
				Vector3[] leVertices = leMesh.vertices;
				Color[] vertColors = leMesh.colors;
				float leDistance;

				for(int i = 0; i < leVertices.Length; ++i)
				{
					leDistance = Vector3.Distance (leVertices[i], hitPoint);

					if(leDistance < charRadius)
					{
						vertColors[i] *=  0.5f + (0.5f * leDistance / charRadius);
					}
				}
				leMesh.colors = vertColors;
			}
		}
	}
}
