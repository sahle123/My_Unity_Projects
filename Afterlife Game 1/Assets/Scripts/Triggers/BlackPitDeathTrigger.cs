using UnityEngine;
using System.Collections;

public class BlackPitDeathTrigger : MonoBehaviour {
	
	void OnTriggerEnter (Collider theTrigger)
	{
		if(theTrigger.gameObject.tag == "The_Player")
		{
			//Debug.Log("Nooo!!! I fell into the pit!");
			GUI_Finished.isDead = true;
		}
	}
	
}