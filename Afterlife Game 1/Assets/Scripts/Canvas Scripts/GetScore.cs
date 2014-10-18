using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

	private int playerScore = 0;
	private Text textScore;

	void Start()
	{
		textScore = GetComponent<Text> ();
	}
	void Update()
	{
		if(playerScore != GUI_Finished.score)
		{
			playerScore = GUI_Finished.score;
			textScore.text = playerScore.ToString();
		}
	}

}