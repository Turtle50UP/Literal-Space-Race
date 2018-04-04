using UnityEngine;

public class ToolHandler : MonoBehaviour {

	Rigidbody2D rb;
	public bool spawned = false;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		rb.angularVelocity = 125f*(Random.Range(-1.0f,1.0f)<0.0f ? -1.0f : 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(spawned){
			rb = this.GetComponent<Rigidbody2D>();
			rb.angularVelocity = 10000f*(Random.Range(-1.0f,1.0f)<0.0f ? -1.0f : 1.0f);
			spawned = false;
		}
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("I HIT YOU!!!!");
		AudioStarter.hit.Play();
	}
}
