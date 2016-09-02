using UnityEngine;
using System.Collections;

public class MainMenu_Controller : MonoBehaviour {
	
	public AudioClip SoundFx;
	public float timeLimit = 2.5f;

	private float etime = 0f;
	private bool startTimeCount = false;

	public void StartGame()
	{
		if(!startTimeCount)
		{
			GetComponent<AudioSource>().PlayOneShot (SoundFx, 0.5f);
			startTimeCount = true;
		}
	}
	public void QuitGame () 
	{
		//Debug.Log ("Success!");
		Application.Quit();	
	}

	void Update()
	{
		if(startTimeCount)
		{
			etime = etime + Time.deltaTime;
		}
		if(etime >= timeLimit)
		{
			Application.LoadLevel ("First Level");
		}
	}
}