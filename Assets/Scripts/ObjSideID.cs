using UnityEngine;

public class ObjSideID : MonoBehaviour {

	GameObject thisobj;
	string objname;

	// Use this for initialization
	void Awake () {
		thisobj = this.gameObject;
		objname = thisobj.name;
	}
	
	public string Get_Side(){
		if (objname.Contains("USSR")){
			return "USSR";
		}
		else if (objname.Contains("US")){
			return "US";
		}
		else{
			return objname;
		}
	}

	public string Get_Other_Side(){
		if (objname.Contains("USSR")){
			return "USSR";
		}
		else if (objname.Contains("US")){
			return "US";
		}
		else{
			return objname;
		}
	}

	// Update is called once per frame
}
