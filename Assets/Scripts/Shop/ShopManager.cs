using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using System;

public class ShopManager : MonoBehaviour {

	MockShopDB shopDB;

	//public static int maxItems = 10;
	public List<ShopItem> items;
	public Canvas shopCanvas;

	// Use this for initialization
	void Start () {
		shopCanvas = GameObject.FindGameObjectWithTag ("ShopCanvas").GetComponentInChildren <Canvas> (true);
		shopDB = GetComponent<MockShopDB> ();
		items = shopDB.items;

	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<ShopCollision> ().collision && Input.GetKey (KeyCode.E)) {
			Debug.Log ("sHOW");
			shopCanvas.gameObject.SetActive (true);
		}
	}

	public ShopItem getShopItem(int code){
		for (int i = 0; i < items.Count; i++) {
			if (items [i].code == code) {
				return items [i];
			}
		}
		return null;
	}
}
