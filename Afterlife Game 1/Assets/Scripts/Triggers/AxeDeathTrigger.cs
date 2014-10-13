using UnityEngine;
using System.Collections;

public class AxeDeathTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider theTrigger)
	{
		if(theTrigger.gameObject.tag == "The_Player")
		{
			//Debug.Log ("Ouch! I was hit!");
			GUI_Finished.isDead = true;
		}
	}
}
