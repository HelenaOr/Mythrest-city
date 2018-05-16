using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShop : MonoBehaviour {

	GameObject player;
	GameObject shop;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		shop = GameObject.FindGameObjectWithTag ("shopCounter");
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void OnEnable(){
		showShop ();
		
	}

	void showShop(){

		List<ShopItem> shopInv = GameObject.FindGameObjectWithTag ("shopCounter").GetComponent<ShopManager> ().items;
		Debug.Log (shopInv.Count);
		if((this.GetComponentInChildren<ScrollRect> ().content.childCount < shopInv.Count-1)){
			for (int i = 0; i < shopInv.Count; i++) {
				if (shopInv [i].name != "") {
					GameObject prefab = Resources.Load<GameObject> ("ShopItemPrefab/ShopItemPrefab");
					GameObject instanceprefab = Instantiate (prefab) as GameObject;
					if (shopInv [i].itemType.Equals (ShopItem.itemTypes.SEED)) {
						Sprite image = Resources.Load<Sprite> ("ToolImages/InventorySeeds/" + shopInv [i].name.ToLower());
						instanceprefab.GetComponentInChildren<Image> ().sprite = image;

					}
					else if (shopInv [i].itemType.Equals (ShopItem.itemTypes.EDIBLE) || shopInv [i].itemType.Equals (ShopItem.itemTypes.NOTEDIBLE)) {
						Sprite image = Resources.Load<Sprite> ("BuyableItems/images/" + shopInv [i].name.ToLower()+"image");
						instanceprefab.GetComponentInChildren<Image> ().sprite = image;

					}


					instanceprefab.transform.SetParent (this.GetComponentInChildren<ScrollRect> ().content);
					instanceprefab.transform.localScale = new Vector3 (1, 1, 1);
					instanceprefab.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = shopInv [i].name;
					instanceprefab.GetComponentInChildren<Button> ().GetComponent<ShopButtonItemID> ().itemCode = shopInv [i].code;
					instanceprefab.gameObject.transform.Find ("Text").GetComponent<Text> ().text = shopInv [i].price.ToString ();
				}

			}
		}

	}
}
