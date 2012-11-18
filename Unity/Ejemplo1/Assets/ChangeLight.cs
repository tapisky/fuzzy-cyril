using UnityEngine;
using System.Collections;

public class ChangeLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<BoxCollider>().co
		RenderSettings.ambientLight = Color.red;
		print("Hello World");
	}
}
