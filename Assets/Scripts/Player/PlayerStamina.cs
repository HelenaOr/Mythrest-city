using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour {

	public Slider staminaSlider;

	int startStamina = 100;
	public int currentStamina;

	public bool fainted;

	public TimeManager timeManager;

	// Use this for initialization
	void Start () {
		staminaSlider = GameObject.FindGameObjectWithTag ("staminaSlider").GetComponent<Slider>();
		currentStamina = startStamina;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loseStamina(int amount){
		currentStamina -= amount;
		staminaSlider.value = currentStamina;

		if (currentStamina <= 0 && !fainted) {
			faint ();
		}
	}

	public void faint(){
		fainted = true;
		timeManager.resetDay ();
	}
}
