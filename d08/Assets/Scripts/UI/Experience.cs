using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {

	public Creature Player;

	private Slider Slider;
	private Text Text;

	private void Start() {
		Slider = GetComponent<Slider> ();
		Text = GetComponentInChildren<Text> ();
	}

	void Update () {
		Slider.value = Player.Experience;
		Slider.maxValue = Player.ExperienceToNextLevel;
		Text.text = Player.Experience + " / " + Player.ExperienceToNextLevel; 
	}
}