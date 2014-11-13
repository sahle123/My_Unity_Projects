using UnityEngine;
using System.Collections;
using System.Collections.Generic;	// This namespace is required for using lists and dictionaries.

/*
 * Notes:
 * 	Lists are generic, so that means they can store any type.
 * 	
 */

public class Lists : MonoBehaviour {

	void Start () 
	{
		// We made a list for storing all of our badguys
		List<HelperClass> badguys = new List<HelperClass>();

		// Populating the list with Add method
		badguys.Add (new HelperClass ("Nappa", 2500));
		badguys.Add (new HelperClass ("Vegeta", 4600));
		badguys.Add (new HelperClass ("Raditz", 1200));

		Debug.Log ("There are " + badguys.Count + " badguys");

		// Sorting section.
		badguys.Sort ();

		foreach (HelperClass guy in badguys)
		{
			Debug.Log (guy.Name + " " + guy.Power);
		}
		
		// Vegeta kills Nappa for his failure
		badguys.RemoveAt (0);
		
		Debug.Log ("There are " + badguys.Count + " badguys");

		// Clear the list
		badguys.Clear ();
		Debug.Log ("There are " + badguys.Count + " badguys");
	}
}
