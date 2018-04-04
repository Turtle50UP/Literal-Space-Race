using UnityEngine;

public struct AudioStarter {
	public static AudioSource menu;
	public static AudioSource race;
	public static AudioSource countdown;
	public static AudioSource hit;
	public static AudioSource smallhit;
	public static AudioSource largehit;
	public static AudioSource button;
	public static AudioSource usvictory;
	public static AudioSource ussrvictory;
	public static AudioSource earth;
	public static AudioSource usprop;
	public static AudioSource ussrprop;
	public static float earthHitTime;
	public static bool started;
}

public class StartMusic : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AudioStarter.menu = GetComponent<AudioSource>();
		PlayStartMusic();
		AudioStarter.earthHitTime = 0.0f;
	}

	void PlayStartMusic() {
		AudioStarter.menu.Play();
	}

	// Update is called once per frame
	void Update () {
		
	}
}