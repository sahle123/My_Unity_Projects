using UnityEngine;
using System.Collections;

// This code is very sloppy. I was exhausted when I wrote this.
// Be sure to fix it up later...
public class TrapTrigger : MonoBehaviour {

	private bool isDropGate = false;
	private bool allDone = true;
	private float Dist = 1f;
	private float etime = 0f;
	private float etimeLimit = 1.5f;
	private float movementdir = 0f;

	void OnTriggerEnter(Collider theTrigger)
	{
		if(theTrigger.gameObject.tag == "Ball")
			isDropGate = true;
	}

	void FixedUpdate()
	{
		if((isDropGate)&&(allDone))
		{
			if(etime >= etimeLimit)
				allDone = false;
			else
			{
				etime = etime + Time.fixedDeltaTime;
				movementdir = Time.fixedDeltaTime * Dist;
				transform.parent.Translate(new Vector3(0, -movementdir, 0));
			}
		}
	}
}