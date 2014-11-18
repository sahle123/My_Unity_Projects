/*
 * 	Julien Lynge (Copied by Sahle Alturaigi)
 * 		11/16/14
 * 
 * 	A simple script that will create add the mesh filter and mesh renderer components to 
 * 	an assigned game object. Very basic.
 */

using UnityEngine;
using System.Collections;

public class SimplePlane : MonoBehaviour {
	
	public Mesh leMesh;

	void Start () 
	{
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
	}
}
