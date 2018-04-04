using UnityEngine;

public class VertBoundStops : MonoBehaviour {

	float topmost = 2.4f;
	float bottommost = -4.40f;
	Vector3 pos;
	public bool slowed = false;
	public string side;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		side = this.gameObject.GetComponent<ObjSideID>().Get_Side();
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > topmost) {
			pos = this.transform.position;
			pos.y = topmost;
			this.transform.position = pos;
		}
		if (this.transform.position.y < bottommost) {
			pos = this.transform.position;
			pos.y = bottommost;
			this.transform.position = pos;
		}
	}
}
