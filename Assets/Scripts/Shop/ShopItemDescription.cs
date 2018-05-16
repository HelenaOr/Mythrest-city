using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemDescription : MonoBehaviour, IPointerEnterHandler {


	public GameObject ItemDescription;
	ShopManager shopManager;
	// Use this for initialization
	void Start () {
		ItemDescription = GameObject.FindGameObjectWithTag ("ShopItemDescription");
		shopManager = FindObjectOfType (typeof(ShopManager)) as ShopManager;
	}

	public void OnPointerEnter(PointerEventData eventData){
		ShopItem shopItem = shopManager.getShopItem (this.GetComponentInChildren<Button> ().GetComponent<ShopButtonItemID> ().itemCode);
		var temColor = ItemDescription.transform.Find ("Image").GetComponent<Image> ().color;
		temColor.a = 1f;
		ItemDescription.transform.Find ("Image").GetComponent<Image> ().color = temColor;
		ItemDescription.transform.Find("Image").GetComponent<Image>().sprite =  this.GetComponentInChildren<Image>().sprite;
		ItemDescription.transform.Find ("NamePanel").GetComponentInChildren<Text> ().text = "Name: " + shopItem.name;
		ItemDescription.transform.Find ("PricePanel").GetComponentInChildren<Text> ().text = "Price: " + shopItem.price.ToString();
		ItemDescription.transform.Find ("DescriptionPanel").GetComponentInChildren<Text> ().text = "Description: " + shopItem.description;

	}

}
