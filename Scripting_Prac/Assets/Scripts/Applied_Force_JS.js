#pragma strict

public var Power : float = 500.0;
function Start () 
{
	rigidbody.AddForce(new Vector3(-Power,0,0));
}
