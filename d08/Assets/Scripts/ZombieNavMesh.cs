using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMesh : MonoBehaviour {

	[HideInInspector]
	public Maya maya;

	//[HideInInspector]
	public bool dead = false;

	[HideInInspector]
	public int life = 3;

	private bool focus;
	private IEnumerator burying;

	// Use this for initialization
	void Start () {
		focus = false;
		burying = isBuried ();
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player" && !dead) {
			maya = col.GetComponent<Maya> ();
			focus = true;
		}
	}

	public void DoneBurying () {
		GameObject.Destroy (this.gameObject);
	}

	public void BuriedAgain () {
		this.GetComponent<SphereCollider> ().enabled = false;
		this.GetComponent<NavMeshAgent> ().enabled = false;
		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		this.GetComponent<Rigidbody> ().drag = 10;
	}

	// Update is called once per frame
	void Update () {
		if (dead)
			focus = !focus;
		else if (focus) {
			this.GetComponent<NavMeshAgent> ().destination = maya.transform.position;
		}
	}
}
