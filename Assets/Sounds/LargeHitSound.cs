using UnityEngine;

public class LargeHitSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.largehit = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
