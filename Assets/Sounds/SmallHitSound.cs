using UnityEngine;

public class SmallHitSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.smallhit = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
