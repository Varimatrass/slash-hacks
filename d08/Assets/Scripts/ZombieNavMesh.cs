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
	private Animator anim;

	// Use this for initialization
	void Start () {
		focus = false;
		anim = this.GetComponent<Animator> ();
	}

	public void IsPlayer (Collider col) {
		if (col.tag == "Player" && !dead) {
			maya = col.GetComponent<Maya> ();
			focus = true;
			anim.SetBool ("run", true);
			StartCoroutine (TryHit ());
		}
	}

	public void DoneBurying () {
		if (this.transform.position.y <= -2)
			GameObject.Destroy (this.gameObject);
	}

	public void BuriedAgain () {
		this.GetComponentInChildren<SphereCollider> ().enabled = false;
		this.GetComponent<CapsuleCollider> ().enabled = false;
		this.GetComponent<NavMeshAgent> ().enabled = false;
		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		this.GetComponent<Rigidbody> ().drag = 10;
	}

	IEnumerator TryHit () {
		if (Vector3.Distance (this.transform.position, maya.transform.position) <= 1.5f) {
			anim.SetBool ("run", false);
			anim.SetTrigger ("atk");
			this.GetComponent<Creature> ().Attack (maya.GetComponent<Creature> ());
		} else if (!anim.GetBool ("run"))
			anim.SetBool ("run", true);
		yield return new WaitForSeconds (2);
		StartCoroutine (TryHit ());
	}

	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Creature> ().HP <= 0 && !dead) {
			dead = true;
			focus = !focus;
			this.GetComponent<NavMeshAgent> ().destination = this.transform.position;
			this.GetComponent<Creature> ().OnDeath (maya.GetComponent<Creature> ());
			BuriedAgain ();
		}
		else if (focus)
			this.GetComponent<NavMeshAgent> ().destination = maya.transform.position;
		DoneBurying ();
	}
}
