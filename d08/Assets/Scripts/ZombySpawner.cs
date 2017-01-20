using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombySpawner : MonoBehaviour {

	public ZombieNavMesh[] Zombies;

	private GameObject[] myZomb;
	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		int nbZombInit = Random.Range (1, 5);
		for (int i = 0; i < nbZombInit; i++) {
			spawn = new Vector3 (Random.Range (50, 150), 1, Random.Range (50, 150));
			GameObject.Instantiate (Zombies [Random.Range (0, 2)], spawn, Quaternion.identity);
		}
		StartCoroutine (ZombieSpawn ());
	}

	IEnumerator ZombieSpawn () {
		yield return new WaitForSeconds (5);
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length < 10) {
			spawn = new Vector3 (Random.Range (50, 150), 1, Random.Range (50, 150));
			GameObject.Instantiate (Zombies [Random.Range (0, 2)], spawn, Quaternion.identity);
		}
		StartCoroutine (ZombieSpawn ());
	}

	// Update is called once per frame
	void Update () {
	}
}
