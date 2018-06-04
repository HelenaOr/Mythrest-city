using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
	public Button exit;
	public Button[] buttons;
	public InventoryManager inventoryManager;
	public PlayerGold playerGold;
	public ShopManager shopManager;
	//Arguments to add the seeds button//

	public Canvas toolCanvas;

	// Use this for initialization
	void Start ()
	{	
		shopManager = FindObjectOfType (typeof(ShopManager)) as ShopManager;
		RectTransform content = this.GetComponentInParent<Canvas> ().GetComponentInChildren<ScrollRect> ().content;
		buttons = content.gameObject.GetComponentsInChildren<Button> ();
		foreach (Button b in buttons) {
			Debug.Log (b.name);
			if (b.GetComponentInChildren<Text> ().text.ToLower ().Contains ("seeds")) {
				b.onClick.AddListener (() => buySeeds (b));


			} else {
				b.onClick.AddListener (() => buyItem (b));
			}
		}

		exit.onClick.AddListener (Exit);


	}
		



	void Exit ()
	{
		RectTransform content = this.GetComponentInParent<Canvas> ().GetComponentInChildren<ScrollRect> ().content;
		Time.timeScale = 1.0f;

		this.GetComponentInParent<Canvas> ().gameObject.SetActive (false);
	}

	void buySeeds (Button button)
	{
		playerGold = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerGold> ();
		MockShopDB shopItems = FindObjectOfType<MockShopDB> ();

		if (playerGold.currentMoney < shopManager.getShopItem (button.GetComponent<ShopButtonItemID> ().itemCode).price) {
			playerGold.notEnoughMoney ();
			Exit ();
		} else {

			if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.turnipSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/turnipSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.turnipSeeds.description, 0, shopItems.turnipSeeds.price, 8, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney (shopItems.turnipSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();


			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.daikonradishSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/daikonRadishSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.daikonradishSeeds.description,0,shopItems.daikonradishSeeds.price,shopItems.daikonradishSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.daikonradishSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();


			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.cabbageSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/cabbageSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.cabbageSeeds.description,0,shopItems.cabbageSeeds.price,9, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);

				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.cabbageSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();


			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.carrotSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/carrotSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.carrotSeeds.description,0,shopItems.carrotSeeds.price,10, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.carrotSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.onionSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/onionSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.onionSeeds.description,0,shopItems.onionSeeds.price,11, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.onionSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.radishSeeds.code) {
				Button resource = Resources.Load<Button> ("seedsButton/radishSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.radishSeeds.description,0,shopItems.radishSeeds.price,12, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}playerGold.spendMoney(shopItems.radishSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.spinachSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/spinachSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.spinachSeeds.description,0,shopItems.spinachSeeds.price,13, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.spinachSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.broccoliSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/broccoliSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.broccoliSeeds.description,0,shopItems.broccoliSeeds.price,shopItems.broccoliSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.broccoliSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.cherryTreeSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/cherryTreeSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.cherryTreeSeeds.description,0,shopItems.cherryTreeSeeds.price,shopItems.cherryTreeSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.cherryTreeSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.peachTreeSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/peachTreeSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.peachTreeSeeds.description,0,shopItems.peachTreeSeeds.price,shopItems.peachTreeSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.peachTreeSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.appleTreeSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/appleTreeSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.appleTreeSeeds.description,0,shopItems.appleTreeSeeds.price,shopItems.appleTreeSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.appleTreeSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}else if (button.GetComponent<ShopButtonItemID> ().itemCode == shopItems.orangeTreeSeeds.code ) {
				Button resource = Resources.Load<Button> ("seedsButton/orangeTreeSeeds");
				InventoryItem itemToAdd = new InventoryItem (button.GetComponentInChildren<Text> ().text, shopItems.orangeTreeSeeds.description,0,shopItems.orangeTreeSeeds.price,shopItems.orangeTreeSeeds.code, InventoryItem.inventoryTypes.SEED);
				inventoryManager.addItem (itemToAdd, 1);
				if (inventoryManager.getItem (itemToAdd.code).quantity <= 1) {
					Button instance = Instantiate (resource);
					instance.transform.SetParent (toolCanvas.GetComponentInChildren<ScrollRect> ().content);

				}
				playerGold.spendMoney(shopItems.orangeTreeSeeds.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();

			}
		
		}

	}

	void buyItem(Button b){
		playerGold = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerGold> ();
		MockShopDB shopItems = FindObjectOfType<MockShopDB> ();

		if (playerGold.currentMoney < shopManager.getShopItem (b.GetComponent<ShopButtonItemID> ().itemCode).price) {
			playerGold.notEnoughMoney ();
			Exit ();
		} else {
			if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("vegetable")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.vegetableSmoothie.description,50,shopItems.vegetableSmoothie.price,shopItems.vegetableSmoothie.code, InventoryItem.inventoryTypes.EDIBLE);
				playerGold.spendMoney(shopItems.vegetableSmoothie.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}else if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("fruit")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.fruitSmoothie.description,25,shopItems.fruitSmoothie.price,shopItems.fruitSmoothie.code, InventoryItem.inventoryTypes.EDIBLE);
				playerGold.spendMoney(shopItems.fruitSmoothie.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}else if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("wine")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.wine.description,10,shopItems.wine.price,shopItems.wine.code, InventoryItem.inventoryTypes.EDIBLE);
				playerGold.spendMoney(shopItems.wine.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}else if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("bracelet")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.bracelet.description,0,shopItems.bracelet.price,shopItems.bracelet.code, InventoryItem.inventoryTypes.NOTEDIBLE);
				playerGold.spendMoney(shopItems.bracelet.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}else if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("book")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.book.description,0,shopItems.book.price,shopItems.book.code, InventoryItem.inventoryTypes.NOTEDIBLE);
				playerGold.spendMoney(shopItems.book.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}else if (b.GetComponentInChildren<Text> ().text.ToLower().Contains ("photo")) {
				InventoryItem itemToAdd = new InventoryItem (b.GetComponentInChildren<Text> ().text, shopItems.photo.description,0,shopItems.photo.price,shopItems.photo.code, InventoryItem.inventoryTypes.NOTEDIBLE);
				playerGold.spendMoney(shopItems.photo.price);
				playerGold.moneyCanvas.GetComponent<Text> ().text = playerGold.currentMoney.ToString ();
				inventoryManager.addItem (itemToAdd, 1);

			}
		}


	}


}
