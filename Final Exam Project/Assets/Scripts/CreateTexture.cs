// This one was really hard. 

using UnityEngine;
using System.Collections;

public class CreateTexture : MonoBehaviour 
{
	private Texture2D tex;
	private float timeLimit = 2f;
	//private float eTime = 0f;

	void Start()
	{
		tex = new Texture2D (128, 128);
		Color[] theColor = new Color[128*128];
		
		for(int i = 0; i < theColor.Length; ++i)
		{
			theColor[i] = new Color (Random.value, Random.value, Random.value, Random.value);
		}
		
		tex.SetPixels (theColor);
		tex.Apply ();
		
		renderer.material.mainTexture = tex;

		StartCoroutine(changeColor ());
	}

	private IEnumerator changeColor()
	{
		while(true)
		{
			yield return new WaitForSeconds(timeLimit);

			Color[] theColor = new Color[128*128];
			
			for(int i = 0; i < theColor.Length; ++i)
			{
				theColor[i] = new Color (Random.value, Random.value, Random.value, Random.value);
			}

			tex.SetPixels (theColor);
			tex.Apply ();
			
			renderer.material.mainTexture = tex;
		}
	}
}
