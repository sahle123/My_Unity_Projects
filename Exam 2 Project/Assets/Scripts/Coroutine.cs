using UnityEngine;
using System.Collections;

public class Coroutine : MonoBehaviour {

	public float waitTime = 2f;

	IEnumerator Start()
	{
		StartCoroutine ("waitAndPrint");
		yield return new WaitForSeconds(waitTime);
		//StopCoroutine ("waitAndPrint");
	}

	IEnumerator waitAndPrint() 
	{
		while(true)
		{
			print ("Hello World");
			yield return new WaitForSeconds(waitTime);
		}
	}
}
