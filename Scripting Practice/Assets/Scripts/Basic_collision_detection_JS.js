#pragma strict

// Runs when the object first collides with a rigidbody
function OnCollisionEnter(theCollision : Collision)
{
	if(theCollision.gameObject.name == "Wall")
	{
		Debug.Log("Ouch!");
	}
}

/*
// This will run as long as the object is touching a rigidbody
function OnCollisionStay(theCollision : Collision)
{
	if(theCollision.gameObject.name == "Floor")
	{
		Debug.Log("I am staying on the floor.");
	}
}
*/


// This will run when the object is no longer coliding with any rigidbody
function OnCollisionExit(theCollision : Collision)
{
	// Code
}