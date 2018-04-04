using UnityEngine;
/* Russo Trap Polka Madre
 * http://freemusicarchive.org/music/Polka_Madre/Polka_Madre_Live_at_WFMU_on_Rob_Weisbergs_Show_on_962008/Russo_Trap
 * Licensed under Creative Commons: By Attribution-NonCommercial-ShareAlike 3.0 United States
 *https://creativecommons.org/licenses/by-nc-sa/3.0/us/
*/

public class USSRVictoryTheme : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioStarter.ussrvictory = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
