using UnityEngine;

public class RepMovement : MonoBehaviour {

	Rigidbody2D playerrep;
	bool alt = false;
	Vector2 force;
	float mag;
	public bool move = true;
	Vector3 initloc;
	GameManager gm;
	Vector2 sForce;
	Vector2 mForce;
	Vector2 lForce;
	GameObject thisPlayer;
	string playerID;
	bool hasplayer = false;
	float tcoll = -1f;
	float slowfactor = 1.5f;
	bool slowed = false;
	Vector2 handiforce;
	public KeyCode handiA;
	public KeyCode handiSt;
	public KeyCode handiSe;
	public bool handi = false;
	public bool debug = false;
	float smag;
	float handif;
	// Use this for initialization
	void Start () {
		smag = -25f;
		handif = smag/5f*2f;
		playerrep = GetComponent<Rigidbody2D> ();
		mag = 0.9f;
		force = new Vector2 (0, mag / Time.fixedDeltaTime);
		initloc = this.transform.position;
		gm = GameObject.Find("GameManager").GetComponent<GameManager> ();
		gm.smag = smag;
		gm.mag = mag;
		sForce = new Vector2(0, mag*(smag)/Time.fixedDeltaTime);
		mForce = new Vector2(0, mag*(2f*smag)/Time.fixedDeltaTime);
		lForce = new Vector2(0, mag*(4f*smag)/Time.fixedDeltaTime);
		handiforce = new Vector2(0,mag*(handif)/Time.fixedDeltaTime);
		playerID = this.GetComponent<ObjSideID>().Get_Side();
	}

	public void resetLoc(){
		this.transform.position = initloc;
		move = true;
		alt = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(handiA)){
			if(Input.GetKeyDown(handiSt))
				handi = false;
			if(Input.GetKeyDown(handiSe))
				handi = true;
		}
		if(Input.GetKey(KeyCode.O)||Input.GetKey(KeyCode.C)){
			if(Input.GetKey(KeyCode.V)||Input.GetKey(KeyCode.P)){
				if(Input.GetKeyDown(KeyCode.I)||Input.GetKeyDown(KeyCode.X))
					mag+=0.05f;
				else if(Input.GetKeyDown(KeyCode.U)||Input.GetKeyDown(KeyCode.Z))
					mag-=0.05f;
				force = new Vector2 (0, mag / Time.fixedDeltaTime);
			}
			else{
				if(Input.GetKeyDown(KeyCode.I)||Input.GetKeyDown(KeyCode.X))
					smag+=0.1f;
				else if(Input.GetKeyDown(KeyCode.U)||Input.GetKeyDown(KeyCode.Z))
					smag-=0.1f;
			}
		}
		gm.smag = smag;
		gm.mag = mag;
		if (gm.started){
			if(move){
				if(!hasplayer){
					if(playerID == "US")
						thisPlayer = gm.USPlayerMovable;
					else
						thisPlayer = gm.USSRPlayerMovable;
					hasplayer = true;
				}
				else{
					if(thisPlayer.GetComponent<VertBoundStops>().slowed){
						slowed = thisPlayer.GetComponent<VertBoundStops>().slowed;
						if(tcoll < 0){
							tcoll = Time.time;
						}
						if((int)Mathf.Floor(Time.time-tcoll)>=3){
							slowed = false;
							tcoll = -1.0f;
							thisPlayer.GetComponent<VertBoundStops>().slowed = false;
						}
					}
					varForce();
					if (gm.doHit){
						if(handi){
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(0)){
								AudioStarter.smallhit.Play ();		//Play small hit sound
								playerrep.AddForce(handiforce);
							}
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(1)){
								AudioStarter.hit.Play ();			//play medium hit sound
								playerrep.AddForce(handiforce);
							}
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(2)){
								AudioStarter.largehit.Play ();
								playerrep.AddForce(handiforce);
							}
						}
						else{
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(0)){
								AudioStarter.smallhit.Play ();		//Play small hit sound
								playerrep.AddForce(sForce);
							}
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(1)){
								AudioStarter.hit.Play ();			//play medium hit sound
								playerrep.AddForce(mForce);
							}
							if (thisPlayer.GetComponent<AsteroidHitHandler>().getHit(2)){
								AudioStarter.largehit.Play ();
								playerrep.AddForce(lForce);
							}
						}
					}
				}
			}
			else{
				hasplayer = false;
			}
		}
		if (Input.GetKey(KeyCode.U)||Input.GetKey(KeyCode.Z)){
			if (Input.GetKeyDown(KeyCode.I)||Input.GetKeyDown(KeyCode.X))
				debug = true;
		}
		if(debug)
			force = new Vector2 (0, mag / Time.fixedDeltaTime * 100);
		else
			force = new Vector2 (0, mag / Time.fixedDeltaTime);
	}

	void varForce(){
		Vector2 temp = force;
		temp.y += ((thisPlayer.transform.position.y+1.0f)/3.4f)*5f;
		if(slowed)
			temp.y /= slowfactor;
		playerrep.AddForce(temp);
	}
}
