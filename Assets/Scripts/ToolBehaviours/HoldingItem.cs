using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItem : MonoBehaviour {

	public bool holdingItem;
	public GameObject item;
	public int itemCode;
	public InventoryManager inventoryManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void saveItem(){
		Destroy (item);
		holdingItem = false;
	}

	public void Gift(int code){
		inventoryManager = GetComponent<InventoryManager> ();

		if (inventoryManager.getItem (code).quantity == 1) {
			
			inventoryManager.removeItem (code);
			
		} else {
			inventoryManager.getItem (code).quantity -= 1;
		}
		Destroy (item);
		holdingItem = false;
		itemCode = -1;
	}
}
