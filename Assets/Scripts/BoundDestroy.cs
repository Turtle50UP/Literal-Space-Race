using UnityEngine;

public class BoundDestroy : MonoBehaviour {

	float bottommost = -6.0f;
	float topmost = 6.0f;
	public float eightbound;
	public float threebound;
	GameManager gm;
	public KeyCode launchtool;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManager> ();
	}

	void Update () {
		if (this.transform.position.y < bottommost || this.transform.position.y > topmost) {
			if(this.gameObject.name.Contains("Hammer")||this.gameObject.name.Contains("Sickle")||this.gameObject.name.Contains("Wrench"))
				this.gameObject.GetComponent<SelfLoop>().reset=false;
			GameObjUtil.Destroy(this.gameObject);
		}
		if(this.transform.position.x > eightbound || this.transform.position.x < -1*eightbound || (this.transform.position.x < threebound && this.transform.position.x > -1*threebound)){
			GameObjUtil.Destroy(this.gameObject);
		}
		if(gm.MoonFallen){
			GameObjUtil.Destroy(this.gameObject);
		}
	}
}
