using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {

	public void btnPressed ()
	{

	}

	public void btnContinuedPressed ()
	{

	}

	public void btnPressed (MyButtonData buttonData)
	{
		Debug.Log ("Button data is: " + buttonData.buttonAction);
	}
}
