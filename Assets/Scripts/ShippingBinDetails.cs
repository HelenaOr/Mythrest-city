using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShippingBinDetails : MonoBehaviour, IPointerEnterHandler {


	public GameObject ItemDescription;
	ShowShippingBin showShippingBin;
	// Use this for initialization
	void Start () {
		ItemDescription = GameObject.FindGameObjectWithTag ("ShippingBinItemDetails");
		showShippingBin = FindObjectOfType (typeof(ShowShippingBin)) as ShowShippingBin;
	}


	public void OnPointerEnter(PointerEventData eventData){
		InventoryItem inventoryItem = showShippingBin.getShippingBinItem (this.GetComponentInChildren<Button> ().GetComponent<ShippingBinButtonItemCode> ().code);
		var temColor = ItemDescription.transform.Find ("Image").GetComponent<Image> ().color;
		temColor.a = 1f;
		ItemDescription.transform.Find ("Image").GetComponent<Image> ().color = temColor;
		ItemDescription.transform.Find("Image").GetComponent<Image>().sprite =  this.GetComponentInChildren<Image>().sprite;
		ItemDescription.transform.Find ("NamePanel").GetComponentInChildren<Text> ().text = "Name: " + inventoryItem.name;
		ItemDescription.transform.Find ("PricePanel").GetComponentInChildren<Text> ().text = "Sell price: " + inventoryItem.sellPrice.ToString();
		ItemDescription.transform.Find ("DescriptionPanel").GetComponentInChildren<Text> ().text = "Description: " + inventoryItem.description;

	}
}
