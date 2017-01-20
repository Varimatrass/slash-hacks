using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Maya : MonoBehaviour {

	Vector3 mouse;
	public Camera cam;
	RaycastHit hit;
	Ray r;

	NavMeshAgent nav;
	Animator anim;
	Creature my;

	void Start () {
		nav = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
		my = this.GetComponent<Creature> ();
	}

	void Update () {

		//anim.SetBool ("run", (nav.angularSpeed > 0.5 ? true : false));
		cam.transform.position = this.gameObject.transform.position + new Vector3 (5, 10 ,0);

		if (Vector3.Distance(nav.destination, transform.position) < 1.5)
			anim.SetBool ("run", false);
		if (Input.GetMouseButton(0)) {
			mouse = Input.mousePosition;
			r = cam.ScreenPointToRay(mouse);
			if (Physics.Raycast(r, out hit, 100)) {
				if (hit.collider != null) {
					if (hit.collider.tag == "Enemy" && Vector3.Distance (transform.position, hit.collider.gameObject.transform.position) < 3 ) {
						my.target = hit.collider.gameObject.GetComponent<Creature> ();
						anim.SetTrigger ("atk");
					}
					else {
						anim.SetBool ("run", true);
						Debug.DrawLine(r.origin, hit.point, Color.green);
						nav.destination = hit.point;
					}
				}
				else
					anim.SetBool ("run", false);
			}
		}
	}
}