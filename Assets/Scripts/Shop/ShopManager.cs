using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

	MockShopDB shopDB;

	//public static int maxItems = 10;
	public List<ShopItem> items;
	public Canvas shopCanvas;
	TimeManager timeManager;
	// Use this for initialization
	void Start ()
	{
		shopCanvas = GameObject.FindGameObjectWithTag ("ShopCanvas").GetComponentInChildren <Canvas> (true);
		shopDB = GetComponent<MockShopDB> ();
		items = shopDB.items;
		timeManager = FindObjectOfType (typeof(TimeManager)) as TimeManager;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.GetComponent<ShopCollision> ().collision && Input.GetKey (KeyCode.E)) {

		
			Time.timeScale = 0.0f;
			GameObject lily = GameObject.Find ("LilyDavis");
			lily.transform.Find ("TalkCanvas").gameObject.SetActive (true);
			lily.transform.Find ("TalkCanvas").Find ("TalkPanel").Find ("TalkText").GetComponent<Text> ().text = "Welcome!";
			StartCoroutine (WaitForLeftClick ());


			
		}
	}

	IEnumerator WaitForLeftClick(){
		while (true) {
			if (Input.GetMouseButtonDown (0)) {
				shopCanvas.gameObject.SetActive (true);
				GameObject lily = GameObject.Find ("LilyDavis");
				lily.transform.Find ("TalkCanvas").gameObject.SetActive (false);
				yield break;
			}

			yield return null;
		}

	}

	public ShopItem getShopItem (int code)
	{
		for (int i = 0; i < items.Count; i++) {
			if (items [i].code == code) {
				return items [i];
			}
		}
		return null;
	}
}
