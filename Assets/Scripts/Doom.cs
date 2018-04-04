using UnityEngine;

public class Doom : MonoBehaviour {

	// Use this for initialization
	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		GameObjUtil.Destroy(other.gameObject);
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(this.transform.position.y>4.6f||this.transform.position.y<-4.6f){
			if(this.gameObject.name.Contains("Hammer")||this.gameObject.name.Contains("Sickle")||this.gameObject.name.Contains("Wrench"))
				this.gameObject.GetComponent<SelfLoop>().reset=false;
			GameObjUtil.Destroy(this.gameObject);
		}
	}
}
