using UnityEngine;
using System.Collections;

public class InsideOut : MonoBehaviour {

	void Start()
	{
		Mesh leMesh = GetComponent<MeshFilter> ().mesh;
		int[] triangles = leMesh.triangles;
	
		// Turn sphere inside out.
		for(int i = 0; i < triangles.Length; i += 3)
		{
			int temp = triangles[i];
			triangles[i] = triangles[i + 2];
			triangles[i + 2] = temp;
		}
		leMesh.triangles = triangles;

		// Flip normals.
		Vector3[] leNormals = leMesh.normals;
		for(int i = 0; i < leNormals.Length; ++i)
		{
			leNormals[i] = -leNormals[i];
		}
		leMesh.normals = leNormals;
	}
}
