using UnityEngine;

public class BoostSpawner : MonoBehaviour {
	public GameObject[] prefabs;
    GameManager gm;
    bool spawned;
    GameObject tool;
    Vector3 objPos;
    GameObject pl;
    public KeyCode toolsp;
    int toolid;
    public int count = -1;
    bool delay;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawned = false;
        delay = false;
    }

	public void spawnTool(int i){
        if(gm.started){
            if(this.GetComponent<ObjSideID>().Get_Side()=="USSR")
                pl = gm.USSRPlayerMovable;
            else
                pl = gm.USPlayerMovable;
            objPos = pl.transform.position;
            objPos.y += 2f;
			tool = GameObjUtil.Instantiate (prefabs[i], objPos);
            objPos = new Vector3(0f,10f,0f);
            tool.GetComponent<SelfLoop>().respawned();
            tool.GetComponent<Rigidbody2D>().velocity = objPos;
            tool.GetComponent<ToolHandler>().spawned = true;
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
            count = gm.toolcount;
        if(Input.GetKeyDown(toolsp)&&gm.started&&!delay){
            delay = true;
            if(count>0){
                spawnTool(1);
                count --;
            }
        }
        if(delay)
            delay = false;
    }
}
