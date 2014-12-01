using UnityEngine;
using System.Collections;

public class SpongeScript : MonoBehaviour {

	public float StartSpeed = 2f;
	public float LifeSpan = 5f;

	private float etime = 0f;

	void Start () 
	{
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -StartSpeed);
		etime = 0f;
	}

	void FixedUpdate () 
	{
		etime = etime + Time.fixedDeltaTime;

		if(etime >= LifeSpan)
		{
			Destroy(gameObject);
		}
	}
}
