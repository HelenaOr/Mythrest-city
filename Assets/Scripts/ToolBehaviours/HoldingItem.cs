using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItem : MonoBehaviour {

	public bool holdingItem;
	public GameObject item;
	public int itemCode;
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
}
