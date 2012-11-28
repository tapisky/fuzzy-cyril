using UnityEngine;
using System.Collections;

public class CollisionBouncing : MonoBehaviour {
	
	public AudioClip bounceclip;
	public AudioClip bouncewall;
	
	// Setup audio clips at the beginning
	void Start () {
		
 		bounceclip = GameObject.Find("Ball_Bounce").audio.clip;
		bouncewall = GameObject.Find("Platform_clip").audio.clip;
	
	}
	
	public int collisionPower;
	public GameObject bounceAgainst;
	
	void OnCollisionEnter(Collision collisionInfo) {
		// play bounce sound if ball colliding against bouncer
		if (collisionInfo.collider.name == "Bouncer"){
			audio.clip = bounceclip;
			audio.loop = false;
			audio.pitch = Random.Range(0.75f,1.2f);
			audio.Play();
		}
		// play wall hit sound instead
		else if ( (collisionInfo.collider.name == "Side1") || (collisionInfo.collider.name == "Side2") ){
			audio.clip = bouncewall;
			audio.loop = false;
			audio.pitch = Random.Range(0.75f,1.4f);
			audio.Play();
		

			print ("Aquí estamos");	
			
		}
		//print("Collision detected");
		print("Collision detected between " + this.name + " and " + collisionInfo.collider.name);
		if (bounceAgainst.name == collisionInfo.collider.name){
	        foreach (ContactPoint contact in collisionInfo.contacts) {
				this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * collisionPower);
	        }
		}
	}
}
