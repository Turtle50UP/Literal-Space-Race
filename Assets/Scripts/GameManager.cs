using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	/*
	 *Which keys are in use:
	 *StartMenu:
	 *JoinGame: I,X
	 *
	 *Gameplay:
	 *USSR Controls: W,A,S,D
	 *US Controls: Left,Right,Up,Down
	 *
	 *Endgame:
	 *Reset Controls: U,Z
	 *
	 *Debug:
	 *Speed Up/Down: B/N
	 *ShowKeyTip: M
	 *
	 *AvailableButtons:
	 *Controller: Left,Right,Up,Down,Select,Start,B,A
	 *USTransposed: Left,Right,Up,Down,U,I,O,P
	 *USSRTransposed: A,D,W,S,Z,X,C,V
	 *
	 */

	//* * * * * * * * * * * * * * * * GUI * * * * * * * * * * * * * * * * *

	/*
	 * Objects in the GUI on start menu
	 */
	public Image USSRIntroImage;
	public Image USIntroImage;
	public Text USSRTutorialName;
	public Text USSRGreeting;
	public Text USSRStartMessage;
	public Text USTutorialName;
	public Text USGreeting;
	public Text USStartMessage;
	public Text USReStartMessage;
	public Text USSRReStartMessage;

	/*
	 * Tutorial UI Elements
	 */
	public Text USTutorialTitle;
	public Text USSRTutorialTitle;
	public Text USTutorialPupIcons;
	public Text USSRTutorialPupIcons;
	public Text USTutorialMessagePup;
	public Text USSRTutorialMessagePup;
	public Image USHam1;
	public Image USSRHam1;
	public Image USHam2;
	public Image USSRHam2;
	public Image USProp;
	public Image USSRProp;
	public Text USSRTutorialMessage; //moon
	public Text USTutorialMessage; //moon
	public Text USTutorialMessageMove;
	public Text USSRTutorialMessageMove;
	public Text USTutorialFaster;
	public Text USSRTutorialFaster;
	public Text USTutorialSlower;
	public Text USSRTutorialSlower;
	public Text USTutorialRep;
	public Text USSRTutorialRep;
	public Text USContinueMessage;
	public Text USSRContinueMessage;


	/*
	 * Objects in the GUI during gameplay
	 */
	public Text USSRTime;
	public Text USTime;
	public Text USSRText;
	public Text USText;
	public Text USHandicap;
	public Text USSRHandicap;
	public Text SMAG;
	public Text MAG;

	/*
	 * Objects in the GUI in Win State
	 */
	public Text USWinText;
	public Text USSRWinText;

	/*
	 * Objects in the GUI in Coutdown
	 */
	public Text USSRCountdown;
	public Text USCountdown;

	//* * * * * * * * * * * * * * * * Permenant Scene Objects * * * * * * * * * * * * * * * * *

	/*
	 * Spawners
	 */
	Spawner USWinSpawner;
	Spawner USSRWinSpawner;
	Spawner USSRPlayerSpawner;
	Spawner USPlayerSpawner;
	ObstacleSpawner USAsterSpawner;
	ObstacleSpawner USSRAsterSpawner;
	public BoostSpawner USToolSpawner;
	public BoostSpawner USSRToolSpawner;
	public PropSpawner USPropSpawner;
	public PropSpawner USSRPropSpawner;
	Spawner USToolImages;
	Spawner USSRToolImages;
	Spawner USPropImages;
	Spawner USSRPropImages;

	/*
	 * Player Representations
	 */
	public GameObject USRep;
	public GameObject USSRRep;

	/*
	 * Other
	 */
	public GameObject Moon; 
	public GameObject USLGirder;
	public GameObject USRGirder;
	
	//* * * * * * * * * * * * * * * * Spawned Scene Items * * * * * * * * * * * * * * * * *

	/*
	 * Movable Player Objects
	 */
	public GameObject USPlayerMovable;
	public GameObject USSRPlayerMovable;

	//* * * * * * * * * * * * * * * * Event Booleans * * * * * * * * * * * * * * * * *

	/*
	 * Main Event Booleans
	 */
	public bool started 	= false;			//If true, in playable game
	public bool landed 		= false;			//If true, a player has landed and game is in the post playable state
	public bool displayed 	= false;			//If true, win state is currently displayed
	public bool resetable 	= false;			//If true, game can now be reset

	/*
	 * Minor Event Booleans
	 */
	public bool USPlayerJoined 		= false;	//If true, US has joined the game at the start
	public bool USSRPlayerJoined 	= false;	//If true, USSR has joined the game at the start
	public bool countdownstart 		= false;	//If true, in countdown
	public bool MoonFallen 			= false;	//If true, game is in win state post moon falling
	public bool showStats 			= false;	//If true, game can show stats
	bool tutorial1					= false;
	bool tutorial2					= false;
	bool tutorial					= false;
	bool startmenu					= false;

	/*
	 * Other Booleans
	 */
	public bool USAsterHit			= false;	//If true, US was hit by asteroid
	public bool USSRAsterHit		= false;	//If true, USSR was hit by asteroid
	public bool USSRWon				= false;
	public bool USWon				= false;
	public bool USSRReset			= false;
	public bool USReset				= false;
	public bool TimeGet				= false;
	public bool USToolLaunched		= false;
	public bool USSRToolLaunched	= false;
	bool updated					= false;
	bool USstartable				= false;
	bool USSRstartable				= false;
	bool timebool					= false;

	/*
	 * Debug Bools
	 */
	public bool doHit = true;

	//* * * * * * * * * * * * * * * * Constants * * * * * * * * * * * * * * * * *

	int initfontsize = 80;

	//* * * * * * * * * * * * * * * * Other Variables * * * * * * * * * * * * * * * * *
	float inittime;
	float inity;
	float fintime;
	float countdowntime = 0f;
	public float leftmost;
	public float rightmost;
	float deltime = 1.1f;
	public int toolcount;
	public int propcount;
	int UStc;
	int USSRtc;
	int USpc;
	int USSRpc;
	float newitemthresh;
	float temptimer;
	public float smag;
	public float mag;
	KeyCode usu = KeyCode.UpArrow;
	KeyCode usd = KeyCode.DownArrow;
	KeyCode usl = KeyCode.LeftArrow;
	KeyCode usr = KeyCode.RightArrow;
	KeyCode usse = KeyCode.U;
	KeyCode usst = KeyCode.I;
	KeyCode usb = KeyCode.O;
	KeyCode usa = KeyCode.P;
	KeyCode ussru = KeyCode.W;
	KeyCode ussrd = KeyCode.S;
	KeyCode ussrl = KeyCode.A;
	KeyCode ussrr = KeyCode.D;
	KeyCode ussrse = KeyCode.Z;
	KeyCode ussrst = KeyCode.X;
	KeyCode ussrb = KeyCode.C;
	KeyCode ussra = KeyCode.V;

	void Awake (){
		Screen.SetResolution(1920,1080,true);
		Cursor.visible = false;
		AudioStarter.started = started;
		smag = 0.0f;
		mag = 0.0f;
		Moon 				= GameObject.Find("MegaMoon");
		USSRPlayerSpawner 	= GameObject.Find("USSRPlayerSpawner").GetComponent<Spawner>();
		USPlayerSpawner 	= GameObject.Find("USPlayerSpawner").GetComponent<Spawner>();
		USSRWinSpawner	 	= GameObject.Find("USSRWinSpawner").GetComponent<Spawner>();
		USWinSpawner 		= GameObject.Find("USWinSpawner").GetComponent<Spawner>();
		USSRToolImages		= GameObject.Find("USSRToolImages").GetComponent<Spawner>();
		USToolImages		= GameObject.Find("USToolImages").GetComponent<Spawner>();
		USSRPropImages		= GameObject.Find("USSRPropImages").GetComponent<Spawner>();
		USPropImages		= GameObject.Find("USPropImages").GetComponent<Spawner>();
		USSRAsterSpawner 	= GameObject.Find("USSRAsterSpawner").GetComponent<ObstacleSpawner>();
		USAsterSpawner		= GameObject.Find("USAsterSpawner").GetComponent<ObstacleSpawner>();
		USToolSpawner		= GameObject.Find("USToolSpawner").GetComponent<BoostSpawner>();
		USSRToolSpawner		= GameObject.Find("USSRToolSpawner").GetComponent<BoostSpawner>();
		USPropSpawner		= GameObject.Find("USPropSpawner").GetComponent<PropSpawner>();
		USSRPropSpawner		= GameObject.Find("USSRPropSpawner").GetComponent<PropSpawner>();
		toolcount = 3;
		newitemthresh = 15f;
		USToolSpawner.count = toolcount;
		USSRToolSpawner.count = toolcount;
		USPropSpawner.count = toolcount;
		USSRPropSpawner.count = toolcount;
		UStc = USToolSpawner.count;
		USSRtc = USSRToolSpawner.count;
		USpc = USPropSpawner.count;
		USSRpc = USSRPropSpawner.count;
		leftmost = USLGirder.transform.position.x+0.3f;
		rightmost = USRGirder.transform.position.x-0.3f;
	}

	void startmenuvis(int alpha){
		USSRTutorialName.canvasRenderer.SetAlpha(alpha);
		USTutorialName.canvasRenderer.SetAlpha(alpha);
		USSRGreeting.canvasRenderer.SetAlpha(alpha);
		USGreeting.canvasRenderer.SetAlpha(alpha);
		if(!USSRPlayerJoined)
			USSRStartMessage.canvasRenderer.SetAlpha(alpha);
		if(!USPlayerJoined)
			USStartMessage.canvasRenderer.SetAlpha(alpha);
	}
	
	void tut1vis(int alpha){
		USSRTutorialMessage.canvasRenderer.SetAlpha(alpha);
		USTutorialMessage.canvasRenderer.SetAlpha(alpha);
		USSRTutorialMessageMove.canvasRenderer.SetAlpha(alpha);
		USTutorialMessageMove.canvasRenderer.SetAlpha(alpha);
		USTutorialFaster.canvasRenderer.SetAlpha(alpha);
		USSRTutorialFaster.canvasRenderer.SetAlpha(alpha);
		USTutorialSlower.canvasRenderer.SetAlpha(alpha);
		USSRTutorialSlower.canvasRenderer.SetAlpha(alpha);
		USTutorialRep.canvasRenderer.SetAlpha(alpha);
		USSRTutorialRep.canvasRenderer.SetAlpha(alpha);
	}
	
	void tut2vis(int alpha){
		USTutorialPupIcons.canvasRenderer.SetAlpha(alpha);
		USSRTutorialPupIcons.canvasRenderer.SetAlpha(alpha);
		USTutorialMessagePup.canvasRenderer.SetAlpha(alpha);
		USSRTutorialMessagePup.canvasRenderer.SetAlpha(alpha);
		USHam1.canvasRenderer.SetAlpha(alpha);
		USSRHam1.canvasRenderer.SetAlpha(alpha);
		USHam2.canvasRenderer.SetAlpha(alpha);
		USSRHam2.canvasRenderer.SetAlpha(alpha);
		USProp.canvasRenderer.SetAlpha(alpha);
		USSRProp.canvasRenderer.SetAlpha(alpha);
	}

	// Use this for initialization
	void Start () {
		USSRPlayerSpawner.spawnOriginal(1);
		USPlayerSpawner.spawnOriginal(1);
		inity = USText.transform.position.y;
		USSRTime.canvasRenderer.SetAlpha(0);
		USTime.canvasRenderer.SetAlpha(0);
		USText.canvasRenderer.SetAlpha(0);
		USSRText.canvasRenderer.SetAlpha(0);
		USSRCountdown.canvasRenderer.SetAlpha(0);
		USCountdown.canvasRenderer.SetAlpha(0);
		USWinText.canvasRenderer.SetAlpha(0);
		USSRWinText.canvasRenderer.SetAlpha(0);
		startmenuvis(1);
		tut1vis(0);
		tut2vis(0);
		USStartMessage.canvasRenderer.SetAlpha(0);
		USSRStartMessage.canvasRenderer.SetAlpha(0);
		USSRContinueMessage.canvasRenderer.SetAlpha(1);
		USContinueMessage.canvasRenderer.SetAlpha(1);
		USTutorialTitle.canvasRenderer.SetAlpha(0);
		USSRTutorialTitle.canvasRenderer.SetAlpha(0);
		USSRReStartMessage.canvasRenderer.SetAlpha(0);
		USReStartMessage.canvasRenderer.SetAlpha(0);
		USHandicap.canvasRenderer.SetAlpha(0);
		USSRHandicap.canvasRenderer.SetAlpha(0);
		startmenu = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (started && !landed) {
			if(!timebool){
				inittime = Time.time;
				timebool = true;
				temptimer = inittime;
			}
			playTimers ();
			if(Time.time-temptimer>newitemthresh){
				Debug.Log("YOU SHOULD SPAWN");
				USPropItemIncrement();
				USSRPropItemIncrement();
				USToolItemIncrement();
				USSRToolItemIncrement();
				temptimer = Time.time;
			}
			if(velnum("US")>=-0.1)
				USText.text = PosTexts(locnum("US"));
			else
				USText.text = USTexts();
			if(velnum("USSR")>=-0.1)
				USSRText.text = PosTexts(locnum("USSR"));
			else
				USSRText.text = USSRTexts();
		}
		else if(started && landed){
			timebool = false;
			if(!TimeGet){
				fintime = Time.time - inittime;
				TimeGet = true;
			}
		}
	}

	public void USPropItemIncrement(){
		if(USPropSpawner.count<toolcount)
			USPropSpawner.count++;
	}

	public void USToolItemIncrement(){
		if(USToolSpawner.count<toolcount)
			USToolSpawner.count++;
	}
	public void USSRPropItemIncrement(){
		if(USSRPropSpawner.count<toolcount)
			USSRPropSpawner.count++;
	}

	public void USSRToolItemIncrement(){
		if(USSRToolSpawner.count<toolcount)
			USSRToolSpawner.count++;
	}

	void keypresstree(){
		if(Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.V)){
			if(startmenu){
				startmenu = false;
				tutorial1 = true;
			}
			else if(tutorial1){
				tutorial1 = false;
				tutorial2 = true;
			}
		}
		if(Input.GetKeyDown(KeyCode.O)||Input.GetKeyDown(KeyCode.C)){
			if(tutorial1){
				startmenu = true;
				tutorial1 = false;
			}
			else if(tutorial2){
				tutorial1 = true;
				tutorial2 = false;
			}
		}
	}

	void Update(){
		SMAG.text = (Mathf.Round(smag*10f)/10f).ToString();
		MAG.text = (Mathf.Round(mag*100f)/100f).ToString();
		if(Input.GetKeyUp(usa)||Input.GetKeyUp(ussra)){
			if(USRep.GetComponent<RepMovement>().handi){
				USHandicap.canvasRenderer.SetAlpha(1);
			}
			else{
				USHandicap.canvasRenderer.SetAlpha(0);
			}
			if(USSRRep.GetComponent<RepMovement>().handi){
				USSRHandicap.canvasRenderer.SetAlpha(1);
			}
			else{
				USSRHandicap.canvasRenderer.SetAlpha(0);
			}
		}
		if (!started) {	
			keypresstree();							//STARTMENU
			if(startmenu){
				USSRTutorialTitle.canvasRenderer.SetAlpha(0);
				USTutorialTitle.canvasRenderer.SetAlpha(0);
				startmenuvis(1);
				tut1vis(0);
				tut2vis(0);
			}
			else{
				startmenuvis(0);
				USSRTutorialTitle.canvasRenderer.SetAlpha(1);
				USTutorialTitle.canvasRenderer.SetAlpha(1);
				if(tutorial1){
					tut2vis(0);
					tut1vis(1);
				}
				else if(tutorial2){
					tut2vis(1);
					tut1vis(0);
				}
			}
			if (Input.GetKeyDown(KeyCode.X)) {
				if(Input.GetKeyDown(ussrb)||Input.GetKeyDown(ussra)){
				}
				else{
					AudioStarter.button.Play();	//Play sound for button press
					USSRPlayerJoined = true;
					USSRStartMessage.canvasRenderer.SetAlpha(0);
				}
			}
			if (Input.GetKeyDown(KeyCode.I)) {
				if(Input.GetKey(usb)||Input.GetKey(usa)){
				}
				else{
					AudioStarter.button.Play();	//Play sound for button press
					USPlayerJoined = true;
					USStartMessage.canvasRenderer.SetAlpha(0);
				}
			}
			if(USSRPlayerJoined && USPlayerJoined)
				updated = false;
		}
		if (USSRPlayerJoined && USPlayerJoined) {
			USSRTutorialTitle.canvasRenderer.SetAlpha(0);
			USTutorialTitle.canvasRenderer.SetAlpha(0);
			startmenuvis(0);
			tut1vis(0);
			tut2vis(0);
			USSRContinueMessage.canvasRenderer.SetAlpha(0);
			USContinueMessage.canvasRenderer.SetAlpha(0);
			AudioStarter.menu.Stop();		//stop menu theme
			if(!updated)
				joinSet();
			if (!countdownstart) {
				AudioStarter.countdown.Play();		//play countdown sound
				countdowntime = Time.time;
				countdownstart = true;
			}
			if (Time.time - countdowntime > 4.0f*deltime) {
				AudioStarter.race.Play();		//start race theme
				started = true;
				gameSet();
				USSRPlayerJoined = false;
				USPlayerJoined = false;
				countdownstart = false;
			} else {
				USSRCountdown.canvasRenderer.SetAlpha(1);
				USCountdown.canvasRenderer.SetAlpha(1);
				float timedif = Time.time - countdowntime;
				if ((timedif >= 0.0f) && (timedif < 1.0f*deltime)) {
					USSRCountdown.text = "3!";
					USCountdown.text = "3!";
				} else if ((timedif >= 1.0f*deltime) && (timedif < 2.0f*deltime)) {
					USSRCountdown.text = "2!";
					USCountdown.text = "2!";
				} else if ((timedif >= 2.0f*deltime) && (timedif < 3.0f*deltime)) {
					USSRCountdown.text = "1!";
					USCountdown.text = "1!";
				} else if ((timedif >= 3.0f*deltime) && (timedif < 4.0f*deltime)) {
					USSRCountdown.text = "GO!";
					USCountdown.text = "GO!";
				}
			}
		}
		if (started) {								//STARTED
			if(Input.GetKeyDown(KeyCode.Alpha8)){
				USPropItemIncrement();
				USSRPropItemIncrement();
				USToolItemIncrement();
				USSRToolItemIncrement();
			}
			if(updated){
				UStc = powreps(UStc,USToolImages,USToolSpawner);
				USSRtc = powreps(USSRtc,USSRToolImages,USSRToolSpawner);
				USpc = powrepsprop(USpc,USPropImages,USPropSpawner);
				USSRpc = powrepsprop(USSRpc,USSRPropImages,USSRPropSpawner);
			}
			if(Input.GetKeyUp(usa)||Input.GetKeyUp(usb)||(Input.GetKeyUp(ussra))||Input.GetKeyUp(ussrb)){
				UStc = powreps(UStc,USToolImages,USToolSpawner);
				USSRtc = powreps(USSRtc,USSRToolImages,USSRToolSpawner);
				USpc = powrepsprop(USpc,USPropImages,USPropSpawner);
				USSRpc = powrepsprop(USSRpc,USSRPropImages,USSRPropSpawner);
			}
			USSRTime.canvasRenderer.SetAlpha(1);
			USTime.canvasRenderer.SetAlpha(1);
			if (!landed) {
				USText.canvasRenderer.SetAlpha(1);
				USSRText.canvasRenderer.SetAlpha(1);
			}
			else
				updated = false;
		}
		if (landed) {	//Rep Contact Moon
			if (!displayed && MoonFallen) {	//Moon Dropped
				USWon = USRep.GetComponent<PlayerRepCollHandler> ().won;
				USSRWon = USSRRep.GetComponent<PlayerRepCollHandler> ().won;
				if (USWon && USSRWon) {
					if (USRep.transform.position.y > USSRRep.transform.position.y)
						USSRWon = false;
					else if (USRep.transform.position.y < USSRRep.transform.position.y)
						USWon = false;
				}
				if(!updated){
					if (USWon && USSRWon) {
						USWinText.text = "Well, this is certainly awkward.";
						USSRWinText.text = "Well, this is certainly awkward.";
						winSet();
					} else {
						if (USWon) {
							AudioStarter.race.Stop();	//Stop race theme pls
							AudioStarter.usvictory.Play();	//Play Beach theme or anthem
							USText.canvasRenderer.SetAlpha(0);
							USWinText.text = "That's one small step for man; one giant leap for mankind.";
							USWinText.canvasRenderer.SetAlpha(1);
							USSRText.fontSize = 60;
							USSRText.text = "The Americans have won the Space Race";
							USWinSpawner.spawn (0);
							USPlayerSpawner.despawn(0);
							USPlayerSpawner.despawn(2);
						} else if (USSRWon) {
							AudioStarter.race.Stop();	//Stop race theme pls
							AudioStarter.ussrvictory.Play(); //Play polka or anthem
							USSRText.canvasRenderer.SetAlpha(0);
							USSRWinText.text = "That's one small step for man; one giant leap for mankind.";
							USSRWinText.canvasRenderer.SetAlpha(1);
							USText.fontSize = 60;
							USText.text = "The Russians have won the Space Race";
							USSRWinSpawner.spawn(0);
							USSRPlayerSpawner.despawn(0);
							USSRPlayerSpawner.despawn(2);
						}
					}
					USToolImages.despawnAll();
					USSRToolImages.despawnAll();
					USPropImages.despawnAll();
					USSRPropImages.despawnAll();
					USSRReStartMessage.canvasRenderer.SetAlpha(1);
					USReStartMessage.canvasRenderer.SetAlpha(1);
				}
				displayed = !displayed;
				resetable = true;
			}
		}
		if(resetable){ //			Resets game
			if(Input.GetKey(KeyCode.U)){
				USReStartMessage.canvasRenderer.SetAlpha(0);
				USReset = true;
			}
			if(Input.GetKey(KeyCode.Z)){
				USSRReStartMessage.canvasRenderer.SetAlpha(0);
				USSRReset = true;
			}
			if(USSRReset && USReset)
				reset();
		}
		if (Input.GetKeyDown(KeyCode.Escape))		//QUIT
			Application.Quit();
		if(Input.GetKeyDown(KeyCode.Alpha1))
			doHit = false;
		if(Input.GetKeyDown(KeyCode.Alpha2))
			doHit = true;
	}

	int powreps(int localtoolcount, Spawner imspawner, BoostSpawner boostsp){
		if(localtoolcount != boostsp.count){
			imspawner.despawnAll();
			localtoolcount = boostsp.count;
			switch(localtoolcount){
				case 3:
					imspawner.spawnOriginal(2);
					imspawner.spawnOriginal(1);
					imspawner.spawnOriginal(0);
					break;
				case 2:
					imspawner.spawnOriginal(1);
					imspawner.spawnOriginal(0);
					break;
				case 1:
					imspawner.spawnOriginal(0);
					break;
				default:
					break;
			}
		}
		return localtoolcount;
	}

	int powrepsprop(int localpropcount, Spawner imspawner, PropSpawner boostsp){
		if(localpropcount != boostsp.count){
			Debug.Log(localpropcount);
			imspawner.despawnAll();
			localpropcount = boostsp.count;
			switch(localpropcount){
				case 3:
					imspawner.spawnOriginal(2);
					imspawner.spawnOriginal(1);
					imspawner.spawnOriginal(0);
					break;
				case 2:
					imspawner.spawnOriginal(1);
					imspawner.spawnOriginal(0);
					break;
				case 1:
					imspawner.spawnOriginal(0);
					break;
				default:
					break;
			}
		}
		return localpropcount;
	}

	void joinSet(){
		USSRTutorialMessage.canvasRenderer.SetAlpha(0);
		USSRGreeting.canvasRenderer.SetAlpha(0);
		USSRTutorialName.canvasRenderer.SetAlpha(0);
		USTutorialMessage.canvasRenderer.SetAlpha(0);
		USGreeting.canvasRenderer.SetAlpha(0);
		USTutorialName.canvasRenderer.SetAlpha(0);
		USSRCountdown.canvasRenderer.SetAlpha(0);
		USCountdown.canvasRenderer.SetAlpha(0);
		updated = true;
	}

	void gameSet(){
		USSRIntroImage.canvasRenderer.SetAlpha(0);
		USIntroImage.canvasRenderer.SetAlpha(0);
		USSRPlayerSpawner.despawn(1);
		USPlayerSpawner.despawn(1);
		USSRPlayerSpawner.spawnOriginal(2);
		USPlayerSpawner.spawnOriginal(2);
		USSRPlayerSpawner.spawn(0);
		USPlayerSpawner.spawn(0);
		USToolImages.spawnOriginal(0);
		USToolImages.spawnOriginal(1);
		USToolImages.spawnOriginal(2);
		USSRToolImages.spawnOriginal(0);
		USSRToolImages.spawnOriginal(1);
		USSRToolImages.spawnOriginal(2);
		USPropImages.spawnOriginal(0);
		USPropImages.spawnOriginal(1);
		USPropImages.spawnOriginal(2);
		USSRPropImages.spawnOriginal(0);
		USSRPropImages.spawnOriginal(1);
		USSRPropImages.spawnOriginal(2);
		updated = true;
	}

	void winSet(){
		USText.canvasRenderer.SetAlpha(0);
		USSRText.canvasRenderer.SetAlpha(0);
		USWinText.canvasRenderer.SetAlpha(1);
		USSRWinText.canvasRenderer.SetAlpha(1);
		USWinSpawner.spawn(0);
		USPlayerSpawner.despawn(0);
		USPlayerSpawner.despawn(2);
		USSRWinSpawner.spawn(0);
		USSRPlayerSpawner.despawn(0);
		USSRPlayerSpawner.despawn(2);
		updated = true;
	}

	string timerep(int val){
		if (val < 10)
			return "0" + val.ToString ();
		return val.ToString ();
	}

	void resetAudio(){
		AudioStarter.race.Stop();			//Stopping all the dumb victory music
		AudioStarter.usvictory.Stop();
		AudioStarter.ussrvictory.Stop();
		AudioStarter.menu.Play();
	}

	void reset(){
		resetAudio();
		resetBools();
		resetSpawn();
		USRep.GetComponent<RepMovement>().resetLoc ();
		USSRRep.GetComponent<RepMovement>().resetLoc ();
		USRep.GetComponent<StopReps>().startReps ();
		USSRRep.GetComponent<StopReps>().startReps ();
		USRep.GetComponent<PlayerRepCollHandler>().won = false;
		USSRRep.GetComponent<PlayerRepCollHandler>().won = false;
		Vector3 postext = USText.transform.position;
		postext.y = inity;
		USText.transform.position = postext;
		postext = USSRText.transform.position;
		postext.y = inity;
		USSRText.transform.position = postext;
		resetAlphas();
		USText.fontSize = initfontsize;
		USSRText.fontSize = initfontsize;
		USSRRep.GetComponent<RepMovement>().handi = false;
		USRep.GetComponent<RepMovement>().handi = false;
		USSRRep.GetComponent<RepMovement>().debug = false;
		USRep.GetComponent<RepMovement>().debug = false;
	}

	string getTimeString(float dtime){
		int sec = (int)Mathf.Floor(dtime);
		int mil = (int)Mathf.Round(100*(dtime - ((float)sec)));
		int min = sec / 60;
		sec -= min * 60;
		string time = timerep(min) + ":" + timerep(sec) + ":" + timerep(mil);
		return time;
	}

	void playTimers(){
		float difftime = Time.time - inittime;
		string time = getTimeString(difftime);
		USSRTime.text = time;
		USTime.text = time;
	}

	int velnum(string nation){
		Rigidbody2D plrp;
		if (nation == "US")
			plrp = USRep.GetComponent<Rigidbody2D>();
		else if (nation == "USSR")
			plrp = USSRRep.GetComponent<Rigidbody2D>();
		else
			plrp = null;
		if(plrp.velocity.y>0)
			return Mathf.RoundToInt (plrp.velocity.y * 10);
		return Mathf.FloorToInt (plrp.velocity.y * 10);
	}

	int locnum(string nation){
		if (nation == "US")
			return Mathf.RoundToInt(USRep.transform.position.y/.9f);
		else if (nation == "USSR")
			return Mathf.RoundToInt(USSRRep.transform.position.y/.9f);
		else
			return 0;
	}

	string USTexts(){
		return "Houston, we've had a problem here...";
	}

	string USSRTexts(){
		return "Baikonur, we have a problem...";
	}

	string PosTexts(int pos){
		switch(pos){
			case -2:
				return "Leaving Earth Atmosphere...";
			case -1:
				return "Leaving Earth Orbit...";
			case 0:
				return "Almost Halfway...";
			case 1:
				return "Past Halfway...";
			case 2:
				return "Approaching Moon Orbit...";
			case 3:
				return "Approaching Lunar Surface...";
			default:
				return "YOUFORGOTONE";
		}
	}

	void resetBools(){
		started 			= false;	//If true, in playable game
		landed 				= false;	//If true, a player has landed and game is in the post playable state
		displayed 			= false;	//If true, win state is currently displayed
		resetable 			= false;	//If true, game can now be reset
		USPlayerJoined 		= false;	//If true, US has joined the game at the start
		USSRPlayerJoined 	= false;	//If true, USSR has joined the game at the start
		countdownstart 		= false;	//If true, in countdown
		MoonFallen 			= false;	//If true, game is in win state post moon falling
		showStats 			= false;	//If true, game can show stats
		USAsterHit			= false;	//If true, US was hit by asteroid
		USSRAsterHit		= false;	//If true, USSR was hit by asteroid
		USSRWon				= false;
		USWon				= false;
		USSRReset			= false;
		USReset				= false;
		TimeGet				= false;
		updated				= false;
		startmenu = true;
		tutorial1 = false;
		tutorial2 = false;
	}

	void resetAlphas(){
		USSRTime.canvasRenderer.SetAlpha(0);
		USTime.canvasRenderer.SetAlpha(0);
		USText.canvasRenderer.SetAlpha(0);
		USSRText.canvasRenderer.SetAlpha(0);
		USSRIntroImage.canvasRenderer.SetAlpha(123f/255f);
		USIntroImage.canvasRenderer.SetAlpha(123f/255f);
		USSRTutorialMessage.canvasRenderer.SetAlpha(1);
		USSRGreeting.canvasRenderer.SetAlpha(1);
		USSRTutorialName.canvasRenderer.SetAlpha(1);
		USSRStartMessage.canvasRenderer.SetAlpha(1);
		USTutorialMessage.canvasRenderer.SetAlpha(1);
		USGreeting.canvasRenderer.SetAlpha(1);
		USTutorialName.canvasRenderer.SetAlpha(1);
		USStartMessage.canvasRenderer.SetAlpha(1);
		USWinText.canvasRenderer.SetAlpha(0);
		USSRWinText.canvasRenderer.SetAlpha(0);
		startmenuvis(1);
		tut1vis(0);
		tut2vis(0);
		USStartMessage.canvasRenderer.SetAlpha(0);
		USSRStartMessage.canvasRenderer.SetAlpha(0);
		USSRContinueMessage.canvasRenderer.SetAlpha(1);
		USContinueMessage.canvasRenderer.SetAlpha(1);
		USTutorialTitle.canvasRenderer.SetAlpha(0);
		USSRTutorialTitle.canvasRenderer.SetAlpha(0);
		USHandicap.canvasRenderer.SetAlpha(0);
		USSRHandicap.canvasRenderer.SetAlpha(0);
	}

	void resetSpawn(){
		USPlayerSpawner.despawn(0);
		USPlayerSpawner.despawn(2);
		USSRPlayerSpawner.despawn(0);
		USSRPlayerSpawner.despawn(2);
		USPlayerSpawner.spawnOriginal(1);
		USSRPlayerSpawner.spawnOriginal(1);
		USWinSpawner.despawn(0);
		USSRWinSpawner.despawn(0);
		USToolSpawner.count = toolcount;
		USSRToolSpawner.count = toolcount;
	}
}
