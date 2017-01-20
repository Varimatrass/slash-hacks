using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMesh : MonoBehaviour {

	[HideInInspector]
	public Maya maya;

	[HideInInspector]
	public bool dead = false;

	private bool focus;

	// Use this for initialization
	void Start () {
		focus = false;
	}

	void OnTriggerEnter (Collider col) {
		if (col.name == "Maya") {
			maya = col.GetComponent<Maya> ();
			focus = true;
		}
	}

	void BuriedAgain () {
		
	}

	// Update is called once per frame
	void Update () {
		if (dead)
			BuriedAgain ();
		else if (focus) {
			this.GetComponent<NavMeshAgent> ().destination = maya.transform.position;
		}
	}
}
