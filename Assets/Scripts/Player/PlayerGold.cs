using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour {

	public GameObject moneyCanvas;
	public static int startMoney = 1400;
	public int currentMoney;
	public static int maxMoney = 999999999;
	public GameObject warnings;


	// Use this for initialization
	void Start () {
		warnings = GameObject.FindGameObjectWithTag ("warnings");

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

	public void notEnoughMoney(){
		warnings.transform.Find("Warnings").gameObject.SetActive (true);
		warnings.GetComponentInChildren<Text>().text = "Not enough money";
		StartCoroutine (setWarningInactive ());
	}
	IEnumerator setWarningInactive(){
		yield return new WaitForSeconds (2.0f);
		warnings.transform.Find("Warnings").gameObject.SetActive (false);
	}
}
