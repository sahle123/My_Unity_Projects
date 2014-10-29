using UnityEngine;
using System.Collections;

public class Health_Bar : MonoBehaviour {

	public float health = 25;
	public Rigidbody Player_Prefab;

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 20), "Heatlh: " + health);
	}
	void OnTriggerEnter(Collider myTrigger)
	{
		if(myTrigger.gameObject.name == "Obst_block")
		{
			health = health - 10;		
		}
	
	}
	void Update()
	{
		if(health <= 0)
		{
			health = 25;
			rigidbody.MovePosition (new Vector3(0,0,0));
		}
	}
}