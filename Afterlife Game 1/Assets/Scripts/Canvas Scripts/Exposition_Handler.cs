using UnityEngine;
using System.Collections;

public class Exposition_Handler : MonoBehaviour {

	void Start()
	{
		transform.parent.GetComponent<Canvas> ().enabled = true;
	}
	
	public void CloseExpoWindow()
	{
		transform.parent.GetComponent<Canvas> ().enabled = false;
		//gameObject.SetActive (false);
	}
}
