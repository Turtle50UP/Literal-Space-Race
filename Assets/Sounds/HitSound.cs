using UnityEngine;

public class HitSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.hit = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
