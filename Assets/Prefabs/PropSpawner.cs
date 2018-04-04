using UnityEngine;

public class PropSpawner : MonoBehaviour {
	public GameObject[] prefabs;
    GameManager gm;
    bool spawned;
    GameObject prop;
    Vector3 objPos;
    GameObject pl;
    public KeyCode propsp;
    int propid;
    public int count = -1;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawned = false;
    }

	public void spawnProp(int i){
        if(gm.started){
            if(this.GetComponent<ObjSideID>().Get_Side()=="USSR")
                pl = gm.USSRPlayerMovable;
            else
                pl = gm.USPlayerMovable;
            objPos = pl.transform.position;
            objPos.x += (-1.0f*(Mathf.Sign(this.transform.position.x)))*1.5f;
			prop = GameObjUtil.Instantiate (prefabs[i], objPos);
            objPos = new Vector3((-1.0f*(Mathf.Sign(this.transform.position.x)))*5f,0f,0f);
            prop.GetComponent<Rigidbody2D>().velocity = objPos;
            prop.GetComponent<PropagandaHandler>().spawned = true;
            prop.GetComponent<PropagandaHandler>().counted = false;
        }
	}

	public void despawn(int i){
		if(GameObject.Find (prefabs[i].name+"(Clone)")!=null)
			GameObjUtil.Destroy (GameObject.Find (prefabs[i].name+"(Clone)"));
	}

	void despawnAll(){
		for (int i = 0; i < prefabs.Length; i++) {
			GameObjUtil.Destroy (GameObject.Find (prefabs[i].name+"(Clone)"));
		}
	}

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(count<0)
            count = gm.propcount;
        if(Input.GetKeyDown(propsp)&&gm.started){
            if(count>0){
                spawnProp(0);
                count --;
            }
        }
    }
}
