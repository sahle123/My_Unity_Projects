using UnityEngine;
using System.Collections;

public class LayersAndTags : MonoBehaviour {
	
	void Start () 
	{
		int layer = gameObject.layer;
		string layerName = LayerMask.LayerToName (layer); // layerMask is essentially used for getting layer names and vice versa.

		Debug.Log ("Object has Layer: " + layer + ", with Layer name: " + layerName);

		string tag = gameObject.tag;

		Debug.Log ("Object has tag name: " + tag);
	}

}
