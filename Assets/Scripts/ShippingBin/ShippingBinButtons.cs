using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShippingBinButtons : MonoBehaviour {

	public Button exit;
	public GameObject[] prefabs;
	PlayerGold playerGold;
	InventoryManager inventory;
	public RectTransform content;
	public int children;
	// Use this for initialization
	void Start () {
		playerGold = FindObjectOfType (typeof(PlayerGold)) as PlayerGold;
		inventory = FindObjectOfType (typeof(InventoryManager)) as InventoryManager;
		exit.onClick.AddListener (Exit);
		startFunction ();
	}
	
	// The first part on this onEnable....
	void OnEnable(){
		startFunction ();
	}

	void OnDisable(){
		content = this.GetComponentInChildren<ScrollRect> ().content;
		children = this.GetComponentInChildren<ScrollRect> ().content.childCount;
		prefabs = new GameObject[children];

		for (int i = 0; i <children ; i++) {

			prefabs [i] = content.GetChild (i).gameObject;

		}
	}

	void sellItem(int code,Button b){

		InventoryItem item = inventory.getItem (code);
		playerGold.gainMoney (item.sellPrice* item.quantity);
		inventory.removeItem (code);
		Destroy (b.transform.parent.gameObject);

		updateButtonText (item, b);
	}

	void updateButtonText(InventoryItem item, Button b){
		string text = b.GetComponentInChildren<Text> ().text;

		text = text.Substring (0, text.Length - 2) + " " +item.quantity.ToString();
		b.GetComponentInChildren<Text> ().text = text;
	}

	public void startFunction(){
		inventory = FindObjectOfType (typeof(InventoryManager)) as InventoryManager;

		//////////////////////////////////////////////////////////////////////////////

		content = this.GetComponentInChildren<ScrollRect> ().content;
		children = this.GetComponentInChildren<ScrollRect> ().content.childCount;
		prefabs = new GameObject[children];

		for (int i = 0; i <children ; i++) {

			prefabs [i] = content.GetChild (i).gameObject;

		}
		//////////////////////////////////////////////////////////////////////////////


		foreach (GameObject prefab in prefabs) {
			Button b = prefab.GetComponentInChildren<Button> ();

			b.onClick.RemoveAllListeners ();
		}

		foreach (GameObject prefab in prefabs) {
			Button b = prefab.GetComponentInChildren<Button> ();
			int code = b.GetComponent<ShippingBinButtonItemCode> ().code;
			b.onClick.AddListener (() => sellItem (code,b));
		}

	}


	void Exit(){
		Time.timeScale = 1.0f;
		this.GetComponentInParent<Canvas> ().gameObject.SetActive (false);
	}
}
