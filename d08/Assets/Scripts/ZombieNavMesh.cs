using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavMesh : MonoBehaviour {

	[HideInInspector]
	public Maya maya;

	[HideInInspector]
	public bool dead = false;

	[HideInInspector]
	public int life = 3;

	private bool focus;
	private IEnumerator burying;

	// Use this for initialization
	void Start () {
		focus = false;
	}

	public void IsPlayer (Collider col) {
		if (col.tag == "Player" && !dead) {
			maya = col.GetComponent<Maya> ();
			focus = true;
			StartCoroutine (TryHit ());
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

	IEnumerator TryHit () {
		if (Vector3.Distance (this.transform.position, maya.transform.position) <= 1.5f)
			this.GetComponent<Creature> ().Attack (maya.GetComponent<Creature> ());
		yield return new WaitForSeconds (2);
		StartCoroutine (TryHit ());
	}

	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Creature> ().HP == 0) {
			dead = true;
			focus = !focus;
			this.GetComponent<NavMeshAgent> ().destination = this.transform.position;
			this.GetComponent<Creature> ().OnDeath (maya.GetComponent<Creature> ());
		}
		else if (focus)
			this.GetComponent<NavMeshAgent> ().destination = maya.transform.position;
	}
}
