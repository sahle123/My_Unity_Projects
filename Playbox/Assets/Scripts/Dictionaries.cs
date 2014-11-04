using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Needed in both lists and dictionaries

public class Dictionaries : MonoBehaviour {

	void Start()
	{
		Dictionary<string, HelperClass> goodguys = new Dictionary<string, HelperClass> ();

		HelperClass gg1 = new HelperClass ("Goku", 9999);
		HelperClass gg2 = new HelperClass ("Krillin", 120);

		// Adding keys to gg1 and gg2 in the dictionary.
		goodguys.Add ("Saiyan", gg1);
		goodguys.Add ("Human", gg2);

		// Adding a key to vegeta. If "Saiyan" didn't exist, then this will throw back an exception.
		//HelperClass vegeta = goodguys ["Saiyan"];
	}

}
