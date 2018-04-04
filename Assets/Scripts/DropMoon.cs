using UnityEngine;

public class DropMoon : MonoBehaviour {
	Rigidbody2D moon;
	GameManager gm;


	// Use this for initialization
	void Start () {
		moon = getMoon();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	Rigidbody2D getMoon(){
		return this.GetComponent<Rigidbody2D>();
	}

	public void dropMoon(){
		moon = getMoon();
		moon.gravityScale = 5;
	}
	
	// Update is called once per frame
	void Update () {
		moon = getMoon();
		if (this.transform.position.y <= -18) {
			gm.MoonFallen = true;
			Vector3 pos = new Vector3 (0f , 50f, -4.7f);
			this.transform.position = pos;
			moon.velocity = new Vector3 (0, 0);
			moon.gravityScale = 0;
		}
	}
}
