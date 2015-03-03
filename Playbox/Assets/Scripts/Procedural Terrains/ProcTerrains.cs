//
// Adds noise to the terrain to procedurally modify it. Courtesy of Julien Lynge
// **Learn details of this code
//	
//	03/03/15
//	Nomad
using UnityEngine;
using LibNoise;
using System.Collections;

[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(TerrainCollider))]
public class ProcTerrains : MonoBehaviour 
{
	private Terrain leTerrain;
	private TerrainData leData;

	private Perlin perlinNoise;

	void Start()
	{
		// Get terrain data
		leTerrain = GetComponent<Terrain> ();
		leData = leTerrain.terrainData;

		// Make some noise
		perlinNoise = new Perlin ();
		perlinNoise.Seed = 1002;

		StartCoroutine (UpdateTerrain ());
	}

	// Continuously create new images from noise
	private IEnumerator UpdateTerrain()
	{
		// Get all height information for this terrain
		float[,] theHeights = leData.GetHeights (0, 0, leData.heightmapWidth, leData.heightmapHeight); //<-- 2-D array
		float leWidth = leData.heightmapWidth;
		float leHeight = leData.heightmapHeight;
		// **refactor above code to make it more efficient

		Debug.Log ("Width and height of map are: " + leWidth + ", " + leHeight + ", conversion multiplier from the heightmap" +
						"to world coordinates is " + leData.heightmapScale + ", size of terrain overall is " + leData.size);

		while (true) 
		{
			float depth = Time.time / 4f;

			for(int i = 0; i < leWidth; ++i)
			{
				for(int j = 0; j < leHeight; ++j)
				{
					theHeights[i,j] = (float)perlinNoise.GetValue ((float)i / leWidth, depth, (float)j / leHeight);
				}
			}

			leData.SetHeights (0, 0, theHeights);

			yield return null;
		}
	}
}
