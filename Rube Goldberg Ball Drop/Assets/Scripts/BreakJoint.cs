using UnityEngine;
using System.Collections;

public class BreakJoint : MonoBehaviour {

	public Joint theJoint;
	public static bool WasHit = false;

	void FixedUpdate()
	{
		if(WasHit)
		{
			//Debug.Log("Here");
			theJoint.breakForce = 1f;
			WasHit = false;
			//hingeJoint.breakForce = 1f;
			//hingeJoint.connectedBody = null;
		}
	}
}
