#pragma strict

function OnTriggerEnter(myTrigger : Collider)
{
	if(myTrigger.gameObject.name == "Trigger_box")
	{
		Debug.Log("Box went through!");
	}
}