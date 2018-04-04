using UnityEngine;

public class PlayerRepCollHandler : MonoBehaviour {
	GameObject moon;
	GameManager gm;
	public bool won = false;
	bool firsthit = true;

	void Start(){
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		moon = gm.Moon;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name.Contains("Moon")) {
			moon.GetComponent<DropMoon> ().dropMoon();
			gm.landed = true;
			if (gm.landed) {
				this.GetComponent<StopReps> ().stopReps();
				this.GetComponent<RepMovement> ().move = false;
			}
			won = true;
		}
		else if(other.gameObject.name.Contains("Earth") && gm.started){
			if (!firsthit){
				AudioStarter.earthHitTime = Time.time;
				AudioStarter.earth.Play();
			}
			else
				firsthit = false;
		}
	}

	void Update(){
		if ((Time.time - AudioStarter.earthHitTime) > 1.2f)
			AudioStarter.earth.Stop();		//stop playing earth hit sound after two seconds
		if (gm.GetComponent<GameManager> ().landed) {
			this.GetComponent<StopReps> ().stopReps ();
			this.GetComponent<RepMovement> ().move = false;
			firsthit = true;
		}
	}

}
