using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using UnityEngine.Analytics;

public class ShowInventory : MonoBehaviour
{
	public List<GameObject> addedToViewObjects = new List<GameObject>();

	void OnEnable(){
		showList ();
	}


	public void showList(){
		List<InventoryItem> im = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ().items;
		InventoryManager inventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ();
		InventoryButtons buttons = FindObjectOfType (typeof(InventoryButtons)) as InventoryButtons;
		for (int j = 0; j < addedToViewObjects.Count; j++) {
			if (addedToViewObjects [j] == null) {
				addedToViewObjects.RemoveAt (j);
			}
		}
		if ((this.GetComponentInChildren<ScrollRect> ().content.childCount < inventory.howManyItems)) {
			for (int i = 0; i < im.Count; i++) {
				
				if (im [i] != null && im [i].quantity != 0) {
					
					if (!im [i].addedToView) {
						GameObject ia = Resources.Load<GameObject> ("InventoryPrefab/IventoryItem");
						GameObject item = Instantiate (ia,this.GetComponentInChildren<ScrollRect> ().content.transform) as GameObject;
						addedToViewObjects.Add (item);
						if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.EDIBLE)) {
							Sprite image = Resources.Load<Sprite> ("CropImages/" + im [i].name.ToLower () + "Image");
							item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = im [i].name + " " + im [i].quantity;
							item.GetComponentInChildren<Image> ().sprite = image;
							item.GetComponentInChildren<Button> ().GetComponentInChildren<InventoryButtonNumer> ().itemCode = im [i].code;
						} else if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.TOOL)) {
							Sprite image = Resources.Load<Sprite> ("ToolImages/" + im [i].name.ToLower () + " Image");
							item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text =im [i].name + " " + im [i].quantity;
							item.GetComponentInChildren<Image> ().sprite = image;
							item.GetComponentInChildren<Button> ().GetComponentInChildren<InventoryButtonNumer> ().itemCode = im [i].code;

							item.transform.localScale = new Vector3 (1, 1, 1);

						} else if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.SEED)) {
							Sprite image = Resources.Load<Sprite> ("ToolImages/InventorySeeds/" + im [i].name.ToLower ());
							item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text =im [i].name + " " + im [i].quantity;
							item.GetComponentInChildren<Image> ().sprite = image;
							item.GetComponentInChildren<Button> ().GetComponentInChildren<InventoryButtonNumer> ().itemCode = im [i].code;

							item.transform.localScale = new Vector3 (1, 1, 1);

						} else if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.NOTEDIBLE)) {
							Sprite image = Resources.Load<Sprite> ("ItemImages/" + im [i].name.ToLower ()+"Image");
							item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text =im [i].name + " " + im [i].quantity;
							item.GetComponentInChildren<Image> ().sprite = image;
							item.GetComponentInChildren<Button> ().GetComponentInChildren<InventoryButtonNumer> ().itemCode = im [i].code;

							item.transform.localScale = new Vector3 (1, 1, 1);

						}



						im [i].addedToView = true;
						buttons.startFunction ();

					}

				}

			}

		}




	}



}
