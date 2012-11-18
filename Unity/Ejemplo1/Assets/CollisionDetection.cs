using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	public GameObject target;
	void OnTriggerEnter(Collider collisionInfo) {
		print("Collision detected between " + this.name + " and " + collisionInfo.collider.name);
		if (collisionInfo.collider.name == target.name) {
			print("Player entered in dead area, it should be dead by now");
		}
	}
}
