using UnityEngine;
using System.Collections;

public class ProceduralTextureAssign : MonoBehaviour {

	
	public Texture2D theTexture;
	public Mesh leMesh;
	
	void Start()
	{
		MeshFilter myFilter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
		myFilter.mesh = leMesh;
		
		MeshRenderer myRenderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		
		//----
		
		int thePixels = 32*32;
		Color[] myColors = new Color[thePixels];
		
		
		theTexture = new Texture2D(32, 32);
		
		theTexture.wrapMode = TextureWrapMode.Clamp;
		
		for(int i = 0; i < thePixels; ++i)
		{
			myColors[i] = new Color((float) i / thePixels, 0f, (float)(i%32)/ 32);
			
		}
		
		theTexture.SetPixels(myColors);
		theTexture.Apply();
		
		myRenderer.material.mainTexture = theTexture;
	}
}
