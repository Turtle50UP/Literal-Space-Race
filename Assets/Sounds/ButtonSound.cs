using UnityEngine;

public class ButtonSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.button = GetComponent<AudioSource>();
	}
}
