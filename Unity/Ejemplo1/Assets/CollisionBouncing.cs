using UnityEngine;
using System.Collections;

public class CollisionBouncing : MonoBehaviour {
	
	public AudioSource bounceclip;
	public AudioSource bouncewall;
	public int numbounces;
	
		
	// Setup audio clips at the beginning
	void Start () {
		
 		bounceclip = GameObject.Find("Ball_Bounce").audio;
		bouncewall = GameObject.Find("Platform_clip").audio;
		numbounces = 0;
	
	}
	
	public int collisionPower;
	public GameObject bounceAgainst;
	
	
	void OnCollisionEnter(Collision collisionInfo) 
	{
		// play bounce sound if ball colliding against bouncer
		if (collisionInfo.collider.name == "Bouncer"){
			bounceclip.loop = false;
			bounceclip.pitch = Random.Range(0.75f,1.2f);
			bounceclip.Play();
			numbounces ++;
		}
		// play wall hit sound instead
		else if ( (collisionInfo.collider.name == "Side1") || (collisionInfo.collider.name == "Side2") ){
			bouncewall.loop = false;
			bouncewall.pitch = Random.Range(0.75f,1.4f);
			bouncewall.Play();	
		}
		//print("Collision detected");
		//print("Collision detected between " + this.name + " and " + collisionInfo.collider.name);
		if (bounceAgainst.name == collisionInfo.collider.name){
	        foreach (ContactPoint contact in collisionInfo.contacts) {
				this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * collisionPower);
	        }
		}
	}
	
}
