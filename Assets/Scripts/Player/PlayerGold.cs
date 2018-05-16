using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour {

	public GameObject moneyCanvas;
	public static int startMoney = 10000;
	public int currentMoney;
	public static int maxMoney = 999999999;

	// Use this for initialization
	void Start () {

		currentMoney = startMoney;
		moneyCanvas.GetComponent<Text> ().text = currentMoney.ToString ();
	}
	
	public void spendMoney(int money){

		if (money > currentMoney) {
			Debug.Log ("Not enough moeney");
		} else {
			currentMoney -= money;
			moneyCanvas.GetComponent<Text> ().text = currentMoney.ToString ();
		}
	}

	public void gainMoney(int money){
		currentMoney += money;
		moneyCanvas.GetComponent<Text> ().text = currentMoney.ToString ();
		
	}
}
