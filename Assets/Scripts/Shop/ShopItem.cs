using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem {

	public string name;
	public string description;
	public int code;
	public int price;


	public enum itemTypes
	{
		SEED,
		EDIBLE,
		NOTEDIBLE
	};
	public itemTypes itemType;

	public ShopItem(string name, string description,int code, int price,itemTypes itemType){
		this.name = name;
		this.description = description;
		this.code = code;
		this.price = price;
		this.itemType = itemType;
	}

}
