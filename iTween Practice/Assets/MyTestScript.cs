using UnityEngine;
using System.Collections;

public class MyTestScript : MonoBehaviour {

	void Start()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("ThePath1")));
	}
}
