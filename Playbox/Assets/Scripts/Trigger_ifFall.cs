using UnityEngine;
using System.Collections;

public class Trigger_ifFall : MonoBehaviour {

	public float x_start = 0f;
	public float y_start = 0f;
	public float z_start = 0f;

	void OnTriggerEnter(Collider theTrigger)
	{
		if(theTrigger.gameObject.name == "Trigger_fall")
			transform.position = new Vector3(x_start, y_start, z_start);
	}
}
