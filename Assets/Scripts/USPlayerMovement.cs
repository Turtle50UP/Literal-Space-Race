using UnityEngine;

public class USPlayerMovement : MonoBehaviour {
	float speed=1.0f;
	Rigidbody2D player;
	GameManager gm;
	void Start () {
		player = GetComponent<Rigidbody2D> (); 
		player.drag = 20;
		player.mass = 1;
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		gm.USPlayerMovable = this.gameObject;
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			player.AddForce (new Vector2 (speed / Time.fixedDeltaTime, 0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			player.AddForce (new Vector2 (-speed / Time.fixedDeltaTime, 0));
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			player.AddForce (new Vector2 (0, speed / Time.fixedDeltaTime));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			player.AddForce (new Vector2 (0, -speed / Time.fixedDeltaTime));
		}
	}
}
