using UnityEngine;

public class SelfLoop : MonoBehaviour {
	public float leftmost;
	public float rightmost;
	Vector3 pos;
	GameManager gm;
	public bool reset = false;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if(this.gameObject.name.Contains("Sickle"))
		{
			leftmost =	-1.0f*gm.rightmost;
			rightmost = -1.0f*gm.leftmost;
		}
		else{
		if(this.transform.position.x<0){
			leftmost =	-1.0f*gm.rightmost;
			rightmost = -1.0f*gm.leftmost;
		}
		else{
			leftmost =	gm.leftmost;
			rightmost = gm.rightmost;
		}
		}
		reset = true;
	}

	public void respawned(){
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (this.transform.position.x > rightmost) {
			pos = this.transform.position;
			pos.x = leftmost + .01f;
			this.transform.position = pos;
		}
		if (this.transform.position.x < leftmost) {
			pos = this.transform.position;
			pos.x = rightmost - .01f;
			this.transform.position = pos;
		}
	}
}
