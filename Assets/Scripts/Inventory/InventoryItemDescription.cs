using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemDescription : MonoBehaviour, IPointerEnterHandler {

	public GameObject ItemDescription;
	InventoryManager inventoryManager;
	// Use this for initialization
	void Start () {
		ItemDescription = GameObject.FindGameObjectWithTag ("InventoryItemDescription");
		inventoryManager = FindObjectOfType (typeof(InventoryManager)) as InventoryManager;
	}


	public void OnPointerEnter(PointerEventData eventData){
		InventoryItem inventoryItem = inventoryManager.getItem (this.GetComponentInChildren<Button> ().GetComponent<InventoryButtonNumer> ().itemCode);
		var temColor = ItemDescription.transform.Find ("Image").GetComponent<Image> ().color;
		temColor.a = 1f;
		ItemDescription.transform.Find ("Image").GetComponent<Image> ().color = temColor;
		ItemDescription.transform.Find("Image").GetComponent<Image>().sprite =  this.GetComponentInChildren<Image>().sprite;
		ItemDescription.transform.Find ("NamePanel").GetComponentInChildren<Text> ().text = "Name: " + inventoryItem.name;
		ItemDescription.transform.Find ("StaminaPanel").GetComponentInChildren<Text> ().text = "Stamina: " + inventoryItem.staminaRecovery.ToString();
		ItemDescription.transform.Find ("DescriptionPanel").GetComponentInChildren<Text> ().text = "Description: " + inventoryItem.description;

	}
}
