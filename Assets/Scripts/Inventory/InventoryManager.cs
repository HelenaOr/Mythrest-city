using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{

	//public const int maxItems = 20;

	public int howManyItems;

	public Canvas inventoryCanvas;

	public List<InventoryItem> items = new List<InventoryItem>(50);

	InventoryItem hoe;
	InventoryItem watteringCan;
	InventoryItem sickle;

	// Use this for initialization
	void Start ()
	{
		
		hoe = new InventoryItem ("Hoe", "Your hoe, it can not be thrown, gifted, sold or eated.",0, 0, 23, InventoryItem.inventoryTypes.TOOL);
		watteringCan = new InventoryItem ("Watering can", "Your watering can, it can not be thrown, gifted, sold or eated.",0, 0, 24, InventoryItem.inventoryTypes.TOOL);
		sickle = new InventoryItem ("Sickle", "Your sickle, it can not be thrown, gifted, sold or eated.",0, 0, 25, InventoryItem.inventoryTypes.TOOL);

		addItem (hoe, 1);
		addItem (watteringCan, 1);
		addItem (sickle, 1);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void addItem (InventoryItem item, int howMany)
	{


		for (int i = 0; i < items.Count; i++) {
			if (items [i] != null && items [i].quantity != 0) {
				if (items [i].code == item.code) {
					items [i].quantity += howMany;
					return;
				}
			} else {

				item.quantity += howMany;
				items [i] = item;
				howManyItems += 1;
				return;

			}
				
		}
	}

	public void removeItem (int code)
	{

		InventoryItem itemToRemove = getItem (code);
		howManyItems -= 1;
		if (howManyItems < 0) {
			howManyItems = 0;
		}
		items.Remove (itemToRemove);

	}

	public InventoryItem getItem (int code)
	{
		for (int i = 0; i < items.Count; i++) {
			if (items [i] != null && items [i].quantity != 0) {
				
				if (items [i].code == code) {
					return items [i];
				}
			}


		}
		return null;
	}
}
