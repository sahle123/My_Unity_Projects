using UnityEngine;
using System.Collections;

public class Applied_Force2_C : MonoBehaviour {
	
	// Need to add f at the end of floats to state they are floats and NOT doubles.
	public float Power = 500.0f; 
	public float Jump = 250.0f;
	public int Jump_number = 0;
	
	void Start () 
	{
		rigidbody.AddForce (new Vector3(-Power, 0, 0));		
	}

	void OnCollisionEnter(Collision myCollision)
	{
		if(Jump_number < 3)
		{
			if(myCollision.gameObject.name == "Floor")
			{
				rigidbody.AddForce (new Vector3(0, Jump, 0));
				Jump_number++;
			}
		}
	}
}
