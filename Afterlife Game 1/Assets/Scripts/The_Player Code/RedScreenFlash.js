#pragma strict

// Code take from http://answers.unity3d.com/questions/63300/solid-color-flash-entire-screen.html
// This code is modified to fit my game's needs.
// Thank you, Peter G from UnityAnswers.

public var flashColor : Color;
public var pauseColor : Color;
public var FlashDuration : float = 0.3f;
private var flash : GUITexture;

function Start () {

	var tex : Texture2D = new Texture2D ( 1 , 1);
	tex.SetPixel( 0 , 0 , Color.white );
	tex.Apply();

	var storageGB = new GameObject("Flash");
	storageGB.transform.localScale = new Vector3(1 , 1 , 0);

	flash = storageGB.AddComponent(GUITexture);
	flash.pixelInset = new Rect(0 , 0 , Screen.width , Screen.height );
	flash.color = flashColor;
	flash.texture = tex;
	flash.enabled = false;
}

function Flash (duration : float) 
{
	flash.color = flashColor;
	flash.enabled = true;
	Invoke("Cancel", duration);
}

function KeepRed()
{
	flash.color = flashColor;
	flash.enabled = true;
}

function Pause()
{
	flash.color = pauseColor;
	flash.enabled = true;
}

function Cancel () 
{
	flash.enabled = false;
}

function OnTriggerEnter (theTrigger : Collider)
{
	if((theTrigger.gameObject.name == "Angry_Soul") || (theTrigger.gameObject.name == "Angry_Soul_2"))
	{
		Flash(FlashDuration);
	}
}