using UnityEngine;
using System.Collections;

public class BreakJointHelper : MonoBehaviour {
	
	void OnCollisionEnter(Collision theTrigger)
	{
		if(theTrigger.gameObject.tag == "Ball")
		{
			//Debug.Log("Hit");
			BreakJoint.WasHit = true;
		}
	}
}
