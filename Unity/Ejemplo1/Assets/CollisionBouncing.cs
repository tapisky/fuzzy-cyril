using UnityEngine;
using System.Collections;

public class CollisionBouncing : MonoBehaviour {
	public int collisionPower;
	public GameObject bounceAgainst;
	void OnCollisionEnter(Collision collisionInfo) {
		//print("Collision detected");
		print("Collision detected between " + this.name + " and " + collisionInfo.collider.name);
		if (bounceAgainst.name == collisionInfo.collider.name){
	        foreach (ContactPoint contact in collisionInfo.contacts) {
				this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * collisionPower);
	        }
		}
	}
}
