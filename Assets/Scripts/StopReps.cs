using UnityEngine;

public class StopReps : MonoBehaviour {
	Rigidbody2D thisbody;

	void Start(){
		thisbody = this.GetComponent<Rigidbody2D> ();
	}
	public void stopReps(){
		thisbody.gravityScale = 0;
		thisbody.velocity = new Vector2 (0,0);
	}

	public void startReps(){
		thisbody.gravityScale = 0.005f;
	}
}
