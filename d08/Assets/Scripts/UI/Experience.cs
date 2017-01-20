using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {

	public Creature Player;

	private Slider Slider;

	private void Start() {
		Slider = GetComponent<Slider> ();
	}

	void Update () {
		Slider.value = Player.Experience;
		Slider.maxValue = Player.ExperienceToNextLevel;
	}
}