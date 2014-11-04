using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	public GameObject EmittedObject;
	public float Frequency = 1f;

	private float etime;

	void Start()
	{
		etime = 0f;
	}

	void FixedUpdate () 
	{
		etime = etime + Time.fixedDeltaTime;

		if(etime >= Frequency)
		{
			Instantiate(EmittedObject, transform.position, Quaternion.identity);
			etime = 0f;
		}
	}
}
