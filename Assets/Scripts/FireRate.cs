using UnityEngine;

public class FireRate : MonoBehaviour {
	GameManager gm;
	GameObject thisrep;
	Rigidbody2D rep;
	ParticleSystem ps;
	int rate = 0;
	void Start(){
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (this.name == "USFire")
			thisrep = gm.USRep;
		else if (this.name == "USSRFire")
			thisrep = gm.USSRRep;
		ps = GetComponent<ParticleSystem> ();
		rep = thisrep.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rep = thisrep.GetComponent<Rigidbody2D> ();
		rate = Mathf.RoundToInt (rep.velocity.y * 2000);
		var em = ps.emission;
		em.rateOverTime = rate;
	}
}
