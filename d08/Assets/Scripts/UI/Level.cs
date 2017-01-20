using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public Creature Player;

	private Text text;

	private void Start() {
		text = GetComponent<Text> ();
	}

	void Update () {
		text.text = "Level " + Player.Level;
	}
}