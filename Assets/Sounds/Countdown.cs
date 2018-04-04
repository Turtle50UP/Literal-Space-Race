using UnityEngine;

public class Countdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.countdown = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
