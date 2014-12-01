// ShowNormals.cs

// Written by Julien Lynge at Grey Hour Games, 2012
// Note that this simple version doesn't work with parenting or scaling of meshes, though support for those is easy to add

// Edited by Sahle Alturaigi. Novemeber 30th, 2014
using UnityEngine;
using System.Collections;

public class ShowNormals : MonoBehaviour {

	public bool ViewNormals = true;

	[Range(0,1)]
	public float LineLength = 0.3f;

	[Range(0,1)]
	public float ColorIntensity = 0.5f;
	
	void OnDrawGizmos () 
	{
		if(ViewNormals)
		{
			Mesh leMesh = gameObject.GetComponent<MeshFilter> ().sharedMesh;

			Vector3[] normals = leMesh.normals;
			Vector3[] verts = leMesh.vertices;

			for(int i = 0; i < normals.Length; ++i)
			{
				// Store a single normal (x,y,z) point
				Vector3 leNormalPoint = normals[i];

				// Assign colors for the gizmo.
				Gizmos.color = new Color(ColorIntensity + leNormalPoint.x * 0.5f, 
				                         ColorIntensity + leNormalPoint.y * 0.5f, 
				                         ColorIntensity + leNormalPoint.z * 0.5f);

				Gizmos.DrawRay(transform.position + verts[i], leNormalPoint * LineLength);
			}
		}
	}
}
