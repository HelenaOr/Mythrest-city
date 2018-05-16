using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class InventoryButtons : MonoBehaviour
{

	public Button[] allButtons;

	public Button[] optionsButtons;

	public Button exit;

	public GameObject itemOptions;
	public Canvas ToolCanvas;
	InventoryManager inventoryManager;
	public GameObject[] invPrefb;
	ShowInventory showInventory;
	Animator anim;
	// Use this for initialization

	void Awake ()
	{
		exit.onClick.AddListener (Exit);
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		itemOptions = Resources.Load<GameObject> ("InventoryPrefab/ItemOptions");
		inventoryManager = FindObjectOfType (typeof(InventoryManager)) as InventoryManager;
		showInventory = FindObjectOfType (typeof(ShowInventory)) as ShowInventory;

	}

	void Start ()
	{
		startFunction ();
	}


	void OnEnable ()
	{

		startFunction ();

	}


	void initButtons ()
	{
		invPrefb = showInventory.addedToViewObjects.ToArray ();
		allButtons = new Button[invPrefb.Length];
		exit.enabled = true;
		for (int i = 0; i < invPrefb.Length; i++) {
			if (invPrefb [i] != null) {
				invPrefb [i].GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
				allButtons [i] = invPrefb [i].GetComponentInChildren<Button> ();
			}

		}
	}


	public void startFunction ()
	{
		initButtons ();
		foreach (Button b in allButtons) {
			if (b != null) {
				

				if (inventoryManager.getItem (b.GetComponentInChildren<InventoryButtonNumer> ().itemCode) != null &&
				    inventoryManager.getItem (b.GetComponentInChildren<InventoryButtonNumer> ().itemCode).quantity != 0) {


					InventoryItem item = inventoryManager.getItem (b.GetComponentInChildren<InventoryButtonNumer> ().itemCode);
					b.GetComponentInChildren<Text> ().text = b.GetComponentInChildren<Text> ().text.Substring (0, b.GetComponentInChildren<Text> ().text.Length - 2) + " " + item.quantity;
					b.onClick.AddListener (() => showOptionsPanel (item, b));


				} else {
					Destroy (b.transform.parent.gameObject);

				}
			}
				
		}


	}


	public void showOptionsPanel (InventoryItem item, Button b)
	{

		GameObject instance = Instantiate (itemOptions, this.GetComponentInChildren<ScrollRect> ().content.parent.transform);
		instance.SetActive (true);
		exit.enabled = false;
		disableButtons ();
		optionsButtons = instance.GetComponentsInChildren<Button> ();
		Debug.Log (item.name);
		if (item.inventoryType.Equals (InventoryItem.inventoryTypes.TOOL)) {
			foreach (Button iob in optionsButtons) {
				if (iob.name == "Cancel") {
					iob.onClick.AddListener (() => cancel (iob));
				}

			}
		} else {
			foreach (Button iob in optionsButtons) {
				if (iob.name == "Hold") {
					iob.onClick.AddListener (() => hold (item,iob));
				} else if (iob.name == "Eat") {
					iob.onClick.AddListener (() => eat (item, iob, b));
				} else if (iob.name == "Throw") {
					iob.onClick.AddListener (() => throwItem (item, iob, b));
				} else if (iob.name == "Cancel") {
					iob.onClick.AddListener (() => cancel (iob));
				}

			}
		}

		

	}

	void hold (InventoryItem item,Button iob)
	{
		Debug.Log ("hold");
		HoldingItem holdingItem = GameObject.FindGameObjectWithTag ("Player").GetComponent<HoldingItem> ();
		holdingItem.holdingItem = true;
		ButtonToPress btp = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
		btp.showPanel ("X", "Save " + item.name);
		anim.SetBool ("isHolding", true);
		if (item.inventoryType.Equals (InventoryItem.inventoryTypes.EDIBLE)) {
			GameObject resource = Resources.Load<GameObject> ("Hold "+ item.inventoryType.ToString().ToLower()+"/" + item.name.ToLower());
			GameObject instance = Instantiate (resource, GameObject.FindGameObjectWithTag ("Player").transform);
			holdingItem.item = instance;
			holdingItem.itemCode = item.code;
		}
		Destroy (iob.transform.parent.gameObject);
		enableButtons ();
		Exit ();
	}

	void eat (InventoryItem item, Button iob, Button b)
	{
		if (item.inventoryType.Equals (InventoryItem.inventoryTypes.EDIBLE)) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ().currentStamina += item.staminaRecovery;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ().staminaSlider.value += item.staminaRecovery;
			item.quantity -= 1;
			b.GetComponentInChildren<Text> ().text = b.GetComponentInChildren<Text> ().text.Substring (0, b.GetComponentInChildren<Text> ().text.Length - 2) + " " + item.quantity;
			if (item.quantity <= 0) {
				inventoryManager.removeItem (item.code);
				Destroy (iob.transform.parent.gameObject);
				showInventory = FindObjectOfType (typeof(ShowInventory)) as ShowInventory;

				for (int i = 0; i < allButtons.Length; i++) {
					if (allButtons [i] != null) {
						if (item.code == (allButtons [i].GetComponentInChildren<InventoryButtonNumer> ().itemCode)) {
							showInventory.addedToViewObjects.Remove (allButtons [i].transform.parent.gameObject);
							Destroy (allButtons [i].transform.parent.gameObject);
							allButtons [i] = null;
							break;
						}
					}

				}


			}
			
		} else {
			Debug.Log ("Not Edible");
		}
		exit.enabled = true;

		enableButtons ();
		startFunction ();

	}

	void throwItem (InventoryItem item, Button iob, Button b)
	{
		Debug.Log (item.name);
		inventoryManager.removeItem (item.code);
		Button[] toolButtons = ToolCanvas.GetComponentInChildren<ScrollRect> ().content.GetComponentsInChildren<Button> ();

		showInventory = FindObjectOfType (typeof(ShowInventory)) as ShowInventory;
		foreach (Button toolButton in toolButtons) {
			Debug.Log (item.code == b.GetComponentInChildren<InventoryButtonNumer> ().itemCode);
			if (toolButton.tag != "Untagged") {
				if (item.code == b.GetComponentInChildren<InventoryButtonNumer> ().itemCode && item.code == int.Parse (toolButton.tag)) {
					Destroy (toolButton.gameObject);


				}
			}

		}

		for (int i = 0; i < allButtons.Length; i++) {
			if (allButtons [i] != null) {
				if (item.code == allButtons [i].GetComponentInChildren<InventoryButtonNumer> ().itemCode) {
					showInventory.addedToViewObjects.Remove (allButtons [i].transform.parent.gameObject);
					Destroy (allButtons [i].transform.parent.gameObject);
					allButtons [i] = null;
					break;
				}
			}

		}

		Destroy (iob.transform.parent.gameObject);
		exit.enabled = true;
		enableButtons ();
		startFunction ();

	}

	void cancel (Button iob)
	{
		Debug.Log ("cancel");
		Destroy (iob.transform.parent.gameObject);
		exit.enabled = true;
		enableButtons ();
		startFunction ();

	}

	void Exit ()
	{
		Time.timeScale = 1.0f;

		initButtons ();
		this.GetComponentInParent<Canvas> ().gameObject.SetActive (false);
	}


	void disableButtons ()
	{
		foreach (Button db in allButtons) {
			if (db != null)
				db.enabled = false;

		}
	}

	void enableButtons ()
	{
		foreach (Button eb in allButtons) {
			if (eb != null)
				eb.enabled = true;
		}
	}
		

}
