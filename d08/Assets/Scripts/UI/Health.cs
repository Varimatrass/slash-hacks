using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Creature Player;

	private Slider Slider;
	private Text Text;

	private void Start() {
		Slider = GetComponent<Slider> ();
		Text = GetComponent<Text> ();
	}

	void Update () {
		Slider.value = Player.HP;
		Slider.maxValue = Player.HPMax;
		Text.text = Player.HP + " / " + Player.HPMax;
	}
}