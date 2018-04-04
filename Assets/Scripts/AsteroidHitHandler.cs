using UnityEngine;

public class AsteroidHitHandler : MonoBehaviour {

	//Three booleans representing hit state of small, med or large asteroid, respectively
	bool sHit = false;
	bool mHit = false;
	bool lHit = false;
	string thisid;
	GameManager gm;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Start()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		thisid = this.GetComponent<ObjSideID>().Get_Side();
	}

	public bool getHit(int hitnum){
		/* This function returns the particular hit asteroid by the ship,
		 * as well as resetting the boolean for detection.
		 */
		switch(hitnum){
			case 0:
			if(sHit){
				sHit = false;
				return true;
			}
			return sHit;
			case 1:
			if(mHit){
				mHit = false;
				return true;
			}
			return mHit;
			case 2:
			if(lHit){
				lHit = false;
				return true;
			}
			return lHit;
			default:
			return false;
		}
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		string othername = other.gameObject.name;
		if(othername.Contains("AsteroidS"))
			sHit = true;
		else if(othername.Contains("AsteroidM"))
			mHit = true;
		else if(othername.Contains("AsteroidL"))
			lHit = true;
		if(sHit || mHit || lHit)
			GameObjUtil.Destroy(other.gameObject);
		if(othername.Contains("Hammer")||othername.Contains("Sickle")||othername.Contains("Wrench")){
			other.gameObject.GetComponent<SelfLoop>().reset = false;
			GameObjUtil.Destroy(other.gameObject);
			if(this.GetComponent<ObjSideID>().Get_Side() == "USSR")
				gm.USSRToolItemIncrement();
			else
				gm.USToolItemIncrement();
		}
	}
	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		string othername = other.gameObject.name;
		if(othername.Contains("Propa")){
			if(other.gameObject.GetComponent<ObjSideID>().Get_Side()==thisid){
				if(!other.gameObject.GetComponent<PropagandaHandler>().counted){
					if(this.GetComponent<ObjSideID>().Get_Side() == "USSR")
						gm.USSRPropItemIncrement();
					else
						gm.USPropItemIncrement();
				other.gameObject.GetComponent<PropagandaHandler>().counted = true;
				}
			}
			else{
				this.GetComponent<VertBoundStops>().slowed = true;
				if(this.GetComponent<ObjSideID>().Get_Side() == "USSR")
					AudioStarter.usprop.Play();
				else
					AudioStarter.ussrprop.Play();
			}
			GameObjUtil.Destroy(other.gameObject);
		}
	}
}
/*
if(this.GetComponent<ObjSideID>().Get_Side() == "USSR")
				gm.USSRToolItemIncrement();
			else
				gm.USToolItemIncrement(); */
