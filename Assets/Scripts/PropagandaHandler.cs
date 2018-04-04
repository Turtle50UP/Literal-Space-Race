using UnityEngine;

public class PropagandaHandler : MonoBehaviour {
	public Vector2 vel;
	string objid;
	string othid;
	Rigidbody2D rb;
	public bool spawned = false;
	public bool counted = false;

	// Use this for initialization
	void Start () {
		objid = this.GetComponent<ObjSideID>().Get_Side();
		othid = this.GetComponent<ObjSideID>().Get_Other_Side();
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name.Contains("Asteroid")){
			rb = this.GetComponent<Rigidbody2D>();
			if(Mathf.Sign(other.transform.position.x-this.transform.position.x)==Mathf.Sign(rb.velocity.x)){
				vel = rb.velocity;
				vel.x *= -1.0f;
				rb.velocity = vel;
			}
		}
		if(other.name.Contains("Propaganda")){
			if(objid == "USSR"){
				if(other.gameObject.GetComponent<ObjSideID>().Get_Side()!=objid){
					GameObjUtil.Destroy(other.gameObject);
					GameObjUtil.Destroy(this.gameObject);
				}
			}
		}
	}
}
