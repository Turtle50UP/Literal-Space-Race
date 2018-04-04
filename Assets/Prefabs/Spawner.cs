using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] prefabs;

	public void spawn(int i){
		if(GameObject.Find (prefabs[i].name+"(Clone)")==null)
			GameObjUtil.Instantiate (prefabs[i], this.transform.position);
	}

	public void spawnOriginal(int i){
		if(GameObject.Find (prefabs[i].name+"(Clone)")==null)
			GameObjUtil.Instantiate (prefabs[i], prefabs[i].transform.position);
	}

	public void despawn(int i){
		if(GameObject.Find (prefabs[i].name+"(Clone)")!=null)
			GameObjUtil.Destroy (GameObject.Find (prefabs[i].name+"(Clone)"));
	}

	public void despawnAll(){
		for (int i = 0; i < prefabs.Length; i++) {
			GameObjUtil.Destroy (GameObject.Find (prefabs[i].name+"(Clone)"));
		}
	}
}
