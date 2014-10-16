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

	static public bool isDead;		// Is the player still alive?
	static public bool reachedPot;	// Has the player reached the victory pot?
	static public bool metQuota;	// Has the player gathered enough souls?

	public int score = 0;
	public int IncrementRate = 5;
	public int DecrementRate = 10;
	public int MegaSoulRate = 25;
	public int SoulQuotaForLevel = 10;
	public int Health = 3;

	public bool StartWithScythe = false;
	
	public Texture2D BlueSoulIcon;
	public Texture2D ScytheIcon;
	public Texture2D HeartIcon;
	public AudioClip BlueSoulSoundFx;
	public AudioClip AngrySoulSoundFx;
	public AudioClip ScytheSoundFX;
	public GUIStyle MyStyle;

	private int AcquiredSouls = 0;

	// All the GetComponents local variables (For performance boost)
	private ScytheSwing isScythe; 	// Will be used in conjunction with .enabled. i.e. isScythe.enabled = true;
	private MouseLook isMouseLook;	// Same principle as isScythe.
	private MouseLook isChildMouseLook; 	// Ibid.
	private MeshRenderer isRenderScythe; 	// Ibid.

	// Initialize all public statics
	// Make sure the Camera is working
	// Do we start with Scythe?
	// Cache all GetComponent calls.
	void Start()
	{
		// Initialize public statics
		metQuota = false;
		isDead = false;
		reachedPot = false;

		// Caching GetComponent calls
		isScythe = transform.FindChild ("Scythe_Blade_Origin").GetComponent<ScytheSwing>();
		isMouseLook = gameObject.GetComponent<MouseLook>();
		isChildMouseLook = transform.FindChild ("Main Camera").GetComponent<MouseLook>();
		isRenderScythe = transform.FindChild ("Scythe_Blade_Origin").FindChild ("Scythe_Blade").FindChild ("default").GetComponent<MeshRenderer> ();


		// Make Sure we have cameras working and player can move
		isMouseLook.enabled = true;
		isChildMouseLook.enabled = true;
		gameObject.GetComponent<CharacterMotor>().enabled = true;

		// Start with Scythe?
		if(!StartWithScythe)
		{
			isScythe.enabled = false;
			isRenderScythe.enabled = false;
		}
		else
		{
			isScythe.enabled = true;
			isRenderScythe.enabled = true;
		}
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

		// Display remaining hearts
		int health_icon_offset = 45;
		int offset = 120;
		for(int i = 0; i < Health; ++i)
		{
			GUI.Box ( new Rect (offset, 10, 40, 30), HeartIcon);
			offset += health_icon_offset;
		}

		// Pause Screen GUI
		if((Time.timeScale == 0) && (!isDead))
		{
			gameObject.SendMessage ("Pause");// Accesses Pause() in RedScreenFlash.js

			if(GUI.Button( new Rect (Screen.width/2 - 50, Screen.height/2 - 55, 100, 50), "Resume"))
			{
				Debug.Log ("Resuming Game...");
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;

				gameObject.SendMessage ("Cancel"); // Accesses Cancel() in RedScreenFlash.js
			}
			if(GUI.Button( new Rect (Screen.width/2 - 50, Screen.height/2, 100, 50), "Exit"))
			{
				Debug.Log ("Quitting Game...");
				Application.LoadLevel ("Title Screen");
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;

				gameObject.SendMessage ("Cancel"); // Accesses Cancel() in RedScreenFlash.js
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

		// If the player has reached the victory pot and has enough souls.
		if((metQuota)&&(reachedPot))
		{
			GUI.Label (new Rect (Screen.width/2 - 35, Screen.height/2 - 55, 120, 60), "You won!!!");

			if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2, 100, 50), "Title Screen"))
			{
				Debug.Log ("Going to next level...");
				AcquiredSouls = 0;
				Application.LoadLevel ("Title Screen");
			}
		}
	}

	//--------------------------------------------------------------
	// Update
	//--------------------------------------------------------------
	// Checks if the pause button was pressed. (ESC key)
	// Checks if player has acquired enough souls.
	void Update()
	{
		// Pause function
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				isMouseLook.enabled = false;
				isChildMouseLook.enabled = false;
			}

			// Unpause with ESC key.
			/*else
			{
				Time.timeScale = 1;
				isMouseLook.enabled = true;
				isChildMouseLook.enabled = true;
			}*/
		}
		if(AcquiredSouls == SoulQuotaForLevel)
			metQuota = true;
	}

	//--------------------------------------------------------------
	// Triggers
	//--------------------------------------------------------------
	// Trigger for despawning souls and giving points.
	// Trigger for taking damage from angry souls
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

		// Angry Soul that damages player
		else if (theTrigger.gameObject.name == "Angry_Soul_2")
		{
			score = score - DecrementRate;

			AudioSource.PlayClipAtPoint (AngrySoulSoundFx, theTrigger.transform.position, 0.5f);

			--Health;

			if(Health <= 0)
				isDead = true;
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
			isRenderScythe.enabled = true;
		}

		/*
		// Did we reach the victory pot? i.e. beat the level.
		if(theTrigger.gameObject.name == "Victory_Pot")
			playerWon = true;
		*/
	}
}
