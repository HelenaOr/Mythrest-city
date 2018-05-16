using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem {

	public string name;
	public string description;
	public int quantity ;
	public bool addedToView;
	public int sellPrice;
	public int code;
	public int staminaRecovery;

	public enum inventoryTypes
	{
		NONE,EDIBLE,
		NOTEDIBLE,
		SEED,
		TOOL
	};

	public inventoryTypes inventoryType;

	public InventoryItem(string name, string description,int staminaRecovery,int sellPrice,int code, inventoryTypes inventoryType){
		this.name = name;
		this.description = description;
		this.staminaRecovery = staminaRecovery;
		this.sellPrice = sellPrice;
		this.code = code;
		this.inventoryType = inventoryType;
		this.addedToView = false;
	}

}
