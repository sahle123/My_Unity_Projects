using UnityEngine;
using System.Collections;

// Basic handler for player when he/she runs into an object that causes isDead to be true;
public class DeathHandler : MonoBehaviour {

	public AudioClip DeathFx;

	private float sWidth;
	private float sHeight;

	void Start()
	{
		GetComponent<AudioSource>().PlayOneShot(DeathFx, 0.23f);
		sWidth = (Screen.width / 2);
		sHeight = (Screen.height / 2);
	}
	void OnGUI()
	{
		// If player dies
		if(GUI_Finished.isDead)
		{
			GUI.Label (new Rect (sWidth - 15, sHeight - 100, 180, 100 ), "You died");
			//Time.timeScale = 0;

			if(GUI.Button (new Rect (sWidth - 50, sHeight - 55, 120, 60), "Retry?"))
			{
				Time.timeScale = 1;
				GUI_Finished.isDead = false;
				Application.LoadLevel (Application.loadedLevel);
			}
			if(GUI.Button (new Rect (sWidth - 50, sHeight, 120, 60), "Quit?"))
			{
				Debug.Log ("Quitting Game...");
				GUI_Finished.isDead = false;
				Application.LoadLevel ("Title Screen");

			}
		}
	}
}
