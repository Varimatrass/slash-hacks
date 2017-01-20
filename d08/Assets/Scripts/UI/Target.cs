using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	public Creature Player;

	private Slider Slider;
	private Text Text;

	private void Start() {
		Slider = GetComponent<Slider> ();
		Text = GetComponentInChildren<Text> ();
	}

	void Update () {
		if (Player.target == null) {
			Slider.gameObject.SetActive(false);
			Text.gameObject.SetActive(false);
			return;
		} else {
			Slider.gameObject.SetActive(true);
			Text.gameObject.SetActive(true);
		}
		Slider.value = Player.target.HP;
		Slider.maxValue = Player.target.HPMax;
		Text.text = Player.target.HP + " / " + Player.target.HPMax; 
	}
}