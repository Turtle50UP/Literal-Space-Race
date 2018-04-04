using UnityEngine;

public class FlipSprite : MonoBehaviour {
	string ObjId;
	void Start(){
		ObjId = this.GetComponent<ObjSideID>().Get_Side();
	}
	void Update(){
		this.GetComponent<SpriteRenderer>().flipX = (this.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x<0f);
	}
}
