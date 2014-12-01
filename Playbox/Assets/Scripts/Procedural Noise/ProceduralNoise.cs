using UnityEngine;
using System.Collections;

using LibNoise; // This is the Assets folder

public class ProceduralNoise : MonoBehaviour {

	public bool isVoronoi = false;
	private Texture2D leTexture;
	private Voronoi voronoiNoise;
	private Perlin perlinNoise;
	
	void Start()
	{
		// Create the texture
		leTexture = new Texture2D (64, 64);
		leTexture.wrapMode = TextureWrapMode.Clamp;

		// Create the voronoi noise
		voronoiNoise = new Voronoi ();

		// Create some perlin noise and set the seed
		perlinNoise = new Perlin ();
		perlinNoise.Seed = 1001;

		StartCoroutine (UpdateImage ());
	}

	// Continuously create new images from the noise
	private IEnumerator UpdateImage()
	{
		float timeToCreateNoise;
		float timeToSetPixels;
		float timeToApplyImage;

		int width = leTexture.width;
		int height = leTexture.height;
		int pixels = width * height;
		Color[] colors = new Color[pixels];

		while(true)
		{
			System.Diagnostics.Stopwatch leTimer = new System.Diagnostics.Stopwatch ();
			leTimer.Start ();

			float depth = Time.time / 2f;

			// Noise is generated here.
			for(int i = 0; i < pixels; ++i)
			{
				float value;

				if(isVoronoi)
					value = (float)voronoiNoise.GetValue ((float)(i % width)/width*4f, depth, i/width/(float)width*4f);
				else // Perlin
					value = (float)perlinNoise.GetValue((float)(i % width)/width*4f, depth, i/width/(float)width*4f);

				colors[i] = new Color(value, value, value);
			}

			// Diagnostics and applying texture.
			timeToCreateNoise = leTimer.ElapsedMilliseconds;

			leTexture.SetPixels (colors);
			timeToSetPixels = leTimer.ElapsedMilliseconds - timeToCreateNoise;

			leTexture.Apply ();
			timeToApplyImage = leTimer.ElapsedMilliseconds - (timeToSetPixels + timeToCreateNoise);

			Debug.Log ("Updating image took: Create noise: " + timeToCreateNoise + ", set pixels: " + timeToSetPixels
			           + ", apply: " + timeToApplyImage);

			leTimer.Stop ();

			yield return null;

		}
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (Screen.width / 2f - Screen.height / 2f, 0f, Screen.height, Screen.height), leTexture);
	}
}
