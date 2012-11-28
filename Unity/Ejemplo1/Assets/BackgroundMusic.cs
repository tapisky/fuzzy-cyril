using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	
	float looptime = 0;
	
	// Use this for initialization
	void Start () {
	
		//looptime = audio.clip.length;
		//audio.loop = true;
		//audio.playOnAwake = false;
		//audio.Play();
		//Invoke("NextClip", looptime);
	}
	
	// Update is called once per frame
	void Update () {
	
		//print (looptime);
		//looptime = audio.clip.length;
	}
	
	void NextClip() {
		
		//audio.Stop();
		//audio.Play ();
		//Invoke("NextClip", looptime);
		
	}
}
