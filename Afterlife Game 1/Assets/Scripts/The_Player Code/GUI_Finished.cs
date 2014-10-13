using UnityEngine;
using System.Collections;


/*
 * Code for handling the player controller.
 * GUI screen, pause screen, pause event, 
 * collecting and despawning souls, gathering
 * points, and trigger with victory pot
 * is found in here.
 */

public class GUI_Finished : MonoBehaviour {

	static public bool isDead = false;

	public int score = 0;
	public int IncrementRate = 5;
	public int DecrementRate = 10;
	public int MegaSoulRate = 25;
	public int SoulQuotaForLevel = 10;

	public bool StartWithScythe = false;
	
	public Texture2D BlueSoulIcon;
	public Texture2D ScytheIcon;
	public AudioClip BlueSoulSoundFx;
	public AudioClip AngrySoulSoundFx;
	public AudioClip ScytheSoundFX;
	public GUIStyle MyStyle;

	private int AcquiredSouls = 0;
	private bool playerWon = false;

	// All the GetComponents local variables (For performance boost)
	private ScytheSwing isScythe; 	// Will be used in conjunction with .enabled. i.e. isScythe.enabled = true;
	private MouseLook isMouseLook;	// Same principle as isScythe.
	private MouseLook isChildMouseLook; // Ibid.
	
	// Make sure the Camera is working
	// Do we start with Scythe?
	// Cache all GetComponent calls.
	void Start()
	{
		// Caching GetComponent calls
		isScythe = transform.FindChild ("Scythe_Blade_Origin").GetComponent<ScytheSwing>();
		isMouseLook = gameObject.GetComponent<MouseLook>();
		isChildMouseLook = transform.FindChild ("Main Camera").GetComponent<MouseLook>();


		// Make Sure we have cameras working and player can move
		isMouseLook.enabled = true;
		isChildMouseLook.enabled = true;
		gameObject.GetComponent<CharacterMotor>().enabled = true;

		// Start with Scythe?
		if(!StartWithScythe)
			isScythe.enabled = false;
		else
			isScythe.enabled = true;
	}

	//--------------------------------------------------------------
	// GUI
	//--------------------------------------------------------------
	// Pause Screen; Game Over Screen; In-game GUI
	void OnGUI()
	{
		// Score Counter
		GUI.Box (new Rect (10, 10, 100, 20), "Score: " + score);

		// The Soul Icon
		GUI.Box (new Rect (15, 35, 40, 60), BlueSoulIcon);

		// The Soul Counter
		GUI.Box (new Rect (60, 45, 40, 40), AcquiredSouls+"/"+SoulQuotaForLevel, MyStyle);

		// Display Scythe Icon?
		if(StartWithScythe)
			GUI.Box (new Rect (15, 100, 40, 60), ScytheIcon);

		// Pause Screen GUI
		if((Time.timeScale == 0) && (!isDead))
		{
			if(GUI.Button( new Rect (Screen.width/2 - 50, Screen.height/2 - 55, 100, 50), "Resume"))
			{
				Debug.Log ("Resuming Game...");
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;
			}
			if(GUI.Button( new Rect (Screen.width/2 - 50, Screen.height/2, 100, 50), "Exit"))
			{
				Debug.Log ("Quitting Game...");
				Application.LoadLevel ("Title Screen");
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;
			}
		}

		// If player dies
		if(isDead)
		{
			transform.FindChild("DeathHandler").GetComponent<DeathHandler>().enabled = true;
			isMouseLook.enabled = false;
			isChildMouseLook.enabled = false;
			gameObject.SendMessage ("KeepRed"); // Accesses KeepRed() in RedScreenFlash.js 

			// Camera pan effect.
			transform.FindChild ("Main Camera").Rotate (Vector3.right * -Time.deltaTime);
			// Disable player movement
			gameObject.GetComponent<CharacterMotor>().enabled = false;

		}

		// If the player has reached the victory pot.
		if(playerWon)
		{
			GUI.Label (new Rect (Screen.width/2 - 35, Screen.height/2 - 55, 120, 60), "You won!!!");

			if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2, 100, 50), "Next Level"))
			{
				Debug.Log ("Going to next level...");
				playerWon = false;
			}
		}
	}

	//--------------------------------------------------------------
	// Update
	//--------------------------------------------------------------
	// Checks if the pause button was pressed. (ESC key)
	void Update()
	{
		// Pause function
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;
			}
			else
			{
				Time.timeScale = 0;
				isMouseLook.enabled = false;
				isChildMouseLook.enabled = false;
			}
		}
	}

	//--------------------------------------------------------------
	// Triggers
	//--------------------------------------------------------------
	// Trigger for despawning souls and giving points.
	// Trigger for finishing level.
	// Trigger for grabbing scythe.
	void OnTriggerEnter (Collider theTrigger)
	{
		// Collecting normal blue soul
		if((theTrigger.gameObject.name == "Collectable_Soul")||
		   (theTrigger.gameObject.name == "Collectable_Soul2(Clone)"))
		{
			score = score + IncrementRate;
			Destroy (theTrigger.gameObject);
			++AcquiredSouls;
			
			AudioSource.PlayClipAtPoint(BlueSoulSoundFx, theTrigger.transform.position, 0.5f);
		}
		
		// Negative soul handler
		else if ((theTrigger.gameObject.name == "Negative_Soul")||
		         (theTrigger.gameObject.name == "Angry_Soul"))
		{
			score = score - DecrementRate;
			
			Destroy (theTrigger.gameObject);
			
			AudioSource.PlayClipAtPoint (AngrySoulSoundFx, theTrigger.transform.position, 0.5f);
		}
		
		// Mega soul handler
		else if (theTrigger.gameObject.name == "Mega_Soul")
		{
			score = score + MegaSoulRate;
			Destroy (theTrigger.gameObject);
			++AcquiredSouls;
			
			AudioSource.PlayClipAtPoint (BlueSoulSoundFx, theTrigger.transform.position, 1f);
		}

		// Enable Scythe Handler
		if (theTrigger.gameObject.name == "Scythe_PowerUp")
		{
			audio.PlayOneShot (ScytheSoundFX, 0.8f);
			isScythe.enabled = true;
			StartWithScythe = true;
		}

		// Did we reach the victory pot? i.e. beat the level.
		if(theTrigger.gameObject.name == "Victory_Pot")
			playerWon = true;
	}
}
