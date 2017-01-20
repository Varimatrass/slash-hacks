using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombyCollider : MonoBehaviour {
	void OnTriggerEnter (Collider col) {
		this.GetComponentInParent<ZombieNavMesh> ().IsPlayer (col);
	}
}
