using UnityEngine;
using System.Collections;

public class InputClass : MonoBehaviour {
	public GameObject bouncer;
	public Rigidbody ball;
	public float default_bar_size;
	private bool pressed = false;
	private float original_hit_x;
	private float original_hit_y;
	
	// Update is called once per frame
	void Update () {
		if (pressed) { // UPDATE bar while the fire button has not been released after the first press
			RaycastHit hit;
		    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		    if (Physics.Raycast(ray, out hit)){
				print("Hit X: " + hit.point.x);
				print("Hit Y: " + hit.point.y);
				if ((ball != null) && (bouncer != null)) {
					Vector3 end_of_line = new Vector3(hit.point.x , hit.point.y, ball.position.z);
					bouncer.GetComponent<LineRenderer>().SetPosition(1, end_of_line);
					// Set collider center to the center of the line
					BoxCollider boxCollider = bouncer.GetComponent("BoxCollider") as BoxCollider;
					boxCollider.transform.position = new Vector3((hit.point.x + original_hit_x) / 2, (hit.point.y + original_hit_y) / 2, ball.position.z);
					// Set collider size
					float new_size = Mathf.Sqrt(Mathf.Pow((hit.point.x - original_hit_x), 2) + Mathf.Pow(hit.point.y - original_hit_y, 2)); // Pitagoras
					boxCollider.transform.localScale = new Vector3(new_size, boxCollider.size.y, boxCollider.size.z); //New size of bouncer bar collision box
					// Rotation of collider
					if (new_size > 0) {
						float angle = Mathf.Asin((hit.point.y - original_hit_y) / new_size) * Mathf.Rad2Deg;
						if (hit.point.x < original_hit_x)
							angle = - angle; //Change rotation
						boxCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
						print("Size Y: " + (hit.point.y - original_hit_y) + " hypot: " + new_size + " Angle: " + angle);
					}
				}
		    }
		}
        if (Input.GetButtonDown("Fire1")) { // Press DOWN, start drawing the bouncer bar
			RaycastHit hit;
		    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		    if (Physics.Raycast(ray, out hit)) { // We don't require to hit background in first plane && hit.transform.name=="Background"){
				pressed = true; //Start painting
				print("Hit X: " + hit.point.x);
				print("Hit Y: " + hit.point.y);
				original_hit_x = hit.point.x; // Save starting coordinates of line
				original_hit_y = hit.point.y;
				if ((ball != null) && (bouncer != null)) { // Set starting point of the line
					Vector3 start_of_line = new Vector3(hit.point.x , hit.point.y, ball.position.z);
					bouncer.GetComponent<LineRenderer>().SetPosition(0, start_of_line);
				}
		    }
        }
		else if (Input.GetButtonUp("Fire1")) {
			pressed = false; //Stop painting
		}
    }
}
