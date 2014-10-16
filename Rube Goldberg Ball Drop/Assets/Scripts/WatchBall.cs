using UnityEngine;
using System.Collections;

public class WatchBall : MonoBehaviour {

	public Transform WhatIsWatched;
	public enum AAQuality : int {Off = 0, Low = 2, Med = 4, High = 8};
	public AAQuality AntiAliasing = AAQuality.Low;
	public int SpeedOfTime = 1;
	
	void Start()
	{ 
		//int theValue = (int)AntiAliasing;
		//Debug.Log (theValue);
		QualitySettings.antiAliasing = (int)AntiAliasing;
		Time.timeScale = SpeedOfTime;
	}
	void Update()
	{
		transform.LookAt (WhatIsWatched);
	}
}
