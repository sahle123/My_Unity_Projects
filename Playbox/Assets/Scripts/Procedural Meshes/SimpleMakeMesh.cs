/*
 * 	Julien Lynge (Copied by Sahle Alturaigi)
 * 		11/16/14
 * 
 * 	Basic code to show you how to make meshes procedurally. 
 * 	Be sure to checkout Unity's Mesh class for more details.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic; // For using lists

public class SimpleMakeMesh : MonoBehaviour {

	public Mesh leMesh;
	
	void Start () 
	{
		// Create a null mesh.
		leMesh = new Mesh ();

		// Create the mesh filter
		MeshFilter myFilter = gameObject.AddComponent (typeof(MeshFilter)) as MeshFilter;
		// Assign the mesh filter the mesh we passed in as a public var.
		myFilter.mesh = leMesh;
		
		// Create the mesh renderer.
		MeshRenderer myRenderer = gameObject.AddComponent (typeof(MeshRenderer)) as MeshRenderer;
		// Create a material. Most of the default materials are in a hidden folder. 
		// Look up online how to find more...
		Material myMaterial = new Material(Shader.Find ("Unlit/Texture"));
		// Assign this material we created above.
		myRenderer.material = myMaterial;

		// Create a plane with 4 vertices. Working in X, Z plane. With Arrays.
		Vector3[] verts = new Vector3[4];
		verts [0] = new Vector3 (0, 0, 0);
		verts [1] = new Vector3 (0, 0, 1);
		verts [2] = new Vector3 (1, 0, 0);
		verts [3] = new Vector3 (1, 0, 1);

		// Create a plane with 4 vertices. Working in X, Z plane. With a list.
		// Especially handy if we don't know how many verts we need till runtime.
		/*
		List<Vector3> verts2 = new List<Vector3> ();
		verts2.Add (Vector3.zero);
			// ...
			// ...
			// ... Keep adding until we're done.
		// We need to convert it to an array at the end to assign to mesh.
		verts2.ToArray ();
		*/

		// Assign the vertices.
		leMesh.vertices = verts;

		// Creating triangle. These numbers are from the video.
		int[] triangles = new int[6] { 0, 1, 2, 1, 3, 2 };
		//int [] triangles = new int[6] {2, 1, 0, 2, 3, 1}; // Backwards example

		// Assign triangles to mesh.
		leMesh.triangles = triangles;

		// Recalculate the bounds. For culling.
		leMesh.RecalculateBounds ();


	}
}
