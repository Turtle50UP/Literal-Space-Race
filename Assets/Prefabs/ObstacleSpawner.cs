
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
	public GameObject[] prefabs;
	public bool despawned = false;
	public bool spawning = false;//false;
	public float lxlim;
	public float hxlim;
	public float lylim;
	public float hylim;
	public bool switchside = false;
	float[] aststart;
	float[] tlims;
	float[] tmaxs;
	float[] tmins;
	GameObject gm;

	void Awake () {
		gm = GameObject.Find("GameManager");
		aststart = new float[3] {Time.time,Time.time,Time.time}; //s,m,l
		tmaxs = new float[3] { 2f, 4f, 6f };
		tmins = new float[3] { 1f, 2f, 3f };
		tlims = new float[3] {
			Random.Range (tmins [0], tmaxs [0]),
			Random.Range (tmins [1], tmaxs [1]),
			Random.Range (tmins [2], tmaxs [2])
		};
	}

	void initastart(int i){
		aststart[i] = Time.time;
	}

	void randlim(int i){
		tlims [i] = Random.Range (tmins [i], tmaxs [i]);
	}

	public void spawn(int whichAster){
		Vector3 pos = this.transform.position;
		pos.x = Random.Range (lxlim, hxlim);
		pos.y = Random.Range (lylim, hylim);
		float randangle = Random.Range (0f,360f);
		GameObject gob = GameObjUtil.Instantiate(prefabs[whichAster],pos);
		Rigidbody2D rb = gob.GetComponent<Rigidbody2D> ();
		Vector3 vvec = new Vector3 (0f,-2f,0f);
		rb.velocity = vvec;
		float randval = Random.Range(-100f,100f);
		float randomga = (1.0f-Mathf.Exp(-1.0f*(randval*randval*0.00001f))*randval);
		rb.angularVelocity = randomga;
		gob.GetComponent<Transform>().Rotate(0,0,randangle);
	}

	public void timelimspawn(int i){
		if (Time.time - aststart [i] >= tlims [i]) {
			spawn (i);
			initastart (i);
			randlim (i);
		}
	}

	public void despawnAll(bool desp){
		despawned = desp;
	}

	public void startSpawning(bool spawnb){
		despawned = false;
		spawning = spawnb;
		for (int i = 0; i < 3; i++) {
			initastart (i);
			randlim (i);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(gm.GetComponent<GameManager>().started && !gm.GetComponent<GameManager>().landed){
			spawning = true;
		}
		else{
			spawning = false;
		}
		if (spawning) {
			for (int i = 0; i < 3; i++) {
				timelimspawn (i);
			}
		}
	}
}
