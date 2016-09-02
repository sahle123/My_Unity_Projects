using UnityEngine;
using System.Collections;

public class ProcTextures : MonoBehaviour {

	private Texture2D tex;
	private int anisoLevel = 1;

	void Start()
	{
		tex = new Texture2D (128, 128);
		Color[] color = new Color[128*128];

		for(int i = 0; i < color.Length; ++i)
		{
			color[i] = new Color (Random.value, Random.value, Random.value, Random.value);
		}

		tex.SetPixels (color);
		tex.Apply ();

		GetComponent<Renderer>().material.mainTexture = tex;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			++anisoLevel;
			tex.anisoLevel = anisoLevel;
		}
	}
}
