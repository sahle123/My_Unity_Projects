using UnityEngine;
using System.Collections;

// Using Collider library in UnityEngine Classes
public class Basic_triggers_C : MonoBehaviour {

	void OnTriggerEnter(Collider myTrigger)
	{
		if (myTrigger.gameObject.name == "Trigger_box")
		{
			Debug.Log ("Box went through");
		}
	}
}
