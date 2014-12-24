using UnityEngine;
using System.Collections;

public class InstantiateObject : MonoBehaviour 
{
	public GameObject CubePrefab;
	public GameObject ButtonPrefab;

	void OnCollisionEnter(Collision theCollision)
	{
		if(theCollision.gameObject.tag == "leCube")
		{
			Instantiate (CubePrefab, transform.localPosition + new Vector3(2, 0, 0), Quaternion.identity);
			Instantiate (ButtonPrefab, transform.localPosition + new Vector3(2, -4, 0), Quaternion.identity);
		}
	}
}
