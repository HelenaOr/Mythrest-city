using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShippingBin : MonoBehaviour
{

	ShippingBinButtons shippingBinButtons;
	public List<InventoryItem> im = new List<InventoryItem>();
	void OnEnable ()
	{
		showShippingBin ();
	}

	void OnDisable(){
		int children = this.GetComponentInChildren<ScrollRect> ().content.childCount;
		RectTransform content = this.GetComponentInChildren<ScrollRect> ().content;
		for (int i = 0; i <children ; i++) {
			Destroy (content.GetChild (i).gameObject);
		}



	}

	public void showShippingBin ()
	{
		shippingBinButtons = FindObjectOfType (typeof(ShippingBinButtons)) as ShippingBinButtons;
		List<InventoryItem> imAUX = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ().items;
		InventoryManager inventory = GameObject.FindGameObjectWithTag ("Player").GetComponent<InventoryManager> ();
		im = new List<InventoryItem>();
		foreach (InventoryItem aux in imAUX) {
			if (!aux.inventoryType.Equals (InventoryItem.inventoryTypes.TOOL) &&!aux.inventoryType.Equals (InventoryItem.inventoryTypes.NONE)  ) {
				im.Add (aux);
			}
		}

		if ((this.GetComponentInChildren<ScrollRect> ().content.childCount < inventory.howManyItems)) {
			for (int i = 0; i < im.Count; i++) {

				if (im [i] != null && im [i].quantity != 0) {

					GameObject ia = Resources.Load<GameObject> ("ShippingPrefab/ShippingbinPrefab");
					GameObject item = Instantiate (ia, this.GetComponentInChildren<ScrollRect> ().content.transform) as GameObject;
					if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.EDIBLE)) {
						Sprite image = Resources.Load<Sprite> ("CropImages/" + im [i].name.ToLower () + "Image");
						item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = im [i].name + " " + im [i].quantity;
						item.GetComponentInChildren<Image> ().sprite = image;
						item.GetComponentInChildren<Button> ().GetComponentInChildren<ShippingBinButtonItemCode> ().code = im [i].code;
					}  else if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.SEED)) {
						Sprite image = Resources.Load<Sprite> ("ToolImages/InventorySeeds/" + im [i].name.ToLower ());
						item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = im [i].name + " " + im [i].quantity;
						item.GetComponentInChildren<Image> ().sprite = image;
						item.GetComponentInChildren<Button> ().GetComponentInChildren<ShippingBinButtonItemCode> ().code = im [i].code;

						item.transform.localScale = new Vector3 (1, 1, 1);

					} else if (im [i].inventoryType.Equals (InventoryItem.inventoryTypes.NOTEDIBLE)) {
						Sprite image = Resources.Load<Sprite> ("ItemImages/" + im [i].name.ToLower () + "Image");
						item.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = im [i].name + " " + im [i].quantity;
						item.GetComponentInChildren<Image> ().sprite = image;
						item.GetComponentInChildren<Button> ().GetComponentInChildren<ShippingBinButtonItemCode> ().code = im [i].code;

						item.transform.localScale = new Vector3 (1, 1, 1);

					}




				}
			


			}

		
		}
		shippingBinButtons.startFunction ();
	}

	public InventoryItem getShippingBinItem(int code){
		
		for (int i = 0; i < im.Count; i++) {
			if (im [i].code == code) {
				return im [i];
			}
		}
		return null;
	}
}

