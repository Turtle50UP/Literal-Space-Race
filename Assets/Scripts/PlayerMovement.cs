using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	float speed=1.0f;
	Rigidbody2D player;
	GameManager gm;
	void Start () {
		player = GetComponent<Rigidbody2D> (); 
		player.drag = 20;
		player.mass = 1;
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		gm.USSRPlayerMovable = this.gameObject;
	}
	
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.D)) {
			player.AddForce (new Vector2 (speed / Time.fixedDeltaTime, 0));
		}
		if (Input.GetKey (KeyCode.A)) {
			player.AddForce (new Vector2 (-speed / Time.fixedDeltaTime, 0));
		}
		if (Input.GetKey (KeyCode.W)) {
			player.AddForce (new Vector2 (0, speed / Time.fixedDeltaTime));
		}
		if (Input.GetKey (KeyCode.S)) {
			player.AddForce (new Vector2 (0, -speed / Time.fixedDeltaTime));
		}
    }
}
