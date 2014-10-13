using UnityEngine;
using System.Collections;

public class Trigger_fireworks : MonoBehaviour {

	public GameObject inst_prefab;
	public Transform trigger;

	private Quaternion correction_rotation = new Quaternion (90, 0, 0, 0);

	void OnTriggerEnter(Collider theTrigger)
	{

		if(theTrigger.gameObject.name == "Player")
		{
			//Debug.Log ("Ta-da");
			Instantiate (inst_prefab, trigger.position, correction_rotation);
		}
	}
}
