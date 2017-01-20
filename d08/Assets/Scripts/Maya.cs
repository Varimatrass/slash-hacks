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
	//Animator anim;

	void Start () {
		nav = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
	}

	void Update () {

		//anim.SetBool ("run", (nav.angularSpeed > 0 ? true : false));
		cam.transform.position = this.gameObject.transform.position + new Vector3 (5, 10 ,0);

		if (Input.GetMouseButton(0)) {
			mouse = Input.mousePosition;
			r = cam.ScreenPointToRay(mouse);
			if (Physics.Raycast(r, out hit, 100)) {
				if (hit.collider != null) {
					Debug.DrawLine(r.origin, hit.point, Color.green);
					nav.destination = hit.point;
				}
			}
		}
	}
}
