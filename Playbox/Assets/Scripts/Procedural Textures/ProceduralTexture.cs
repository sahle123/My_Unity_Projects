using UnityEngine;
using System.Collections;

public class ProceduralTexture : MonoBehaviour {

	public Texture2D theTexture;

	void Start()
	{
		int thePixels = 32 * 32; 
		Color[] myColors = new Color[thePixels];

		// Create the 32x32 texture
		theTexture = new Texture2D (32, 32); 

		// Clamp the texture so that it does not repeat on a mesh.
		theTexture.wrapMode = TextureWrapMode.Clamp; 

		for (int i = 0; i < thePixels; ++i)
		{
			// Red blue gradient
			myColors[i] = new Color((float)i / thePixels, 0f, (float)(i % 32) / 32);

			// Gray scale
			//myColors[i] = new Color((float)i / thePixels, (float)i / thePixels, (float)i / thePixels);
		}

		// Push to memory
		theTexture.SetPixels (myColors);

		// Apply changes to GPU
		theTexture.Apply ();
	}

	// Render the texture
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0f, 0f, Screen.width, Screen.height), theTexture);
	}
}
