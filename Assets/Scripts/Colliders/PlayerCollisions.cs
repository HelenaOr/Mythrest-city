using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

	public ButtonToPress buttonToPress;
	void OnCollisionEnter(Collision col){
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
		if (col.gameObject.tag == "shopCounter") {
			buttonToPress.showPanel ("E", "Shop counter");
		} else if (col.gameObject.tag == "ShippingBinObject") {
			buttonToPress.showPanel ("E", "Shipping bin");
		} else if (col.gameObject.tag == "Fountain") {
			buttonToPress.showPanel ("E", "Recharge the watering can");
		} else if (col.gameObject.tag == "Farm") {
			buttonToPress.showPanel ("E", "Enter house");
		} else if (col.gameObject.tag == "MyHouse") {
			buttonToPress.showPanel ("E", "Exit house");
		} else if (col.gameObject.tag == "Bed") {
			buttonToPress.showPanel ("E", "Bed");
		} else if (col.gameObject.tag == "NPC") {
			buttonToPress.showPanel ("E", col.gameObject.GetComponent<NPCBehaviour> ().myself.name + " " +  col.gameObject.GetComponent<NPCBehaviour> ().myself.surname );
		}
	}

	void OnTriggerEnter(Collider col){
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
		if (col.gameObject.tag == "crop") {
			if (col.GetComponent<CropBehaviour> ().state.Equals (Crops.cropStates.HARVEST)) {
				buttonToPress.showPanel ("rightMouse", "Pick up "+ col.GetComponent<CropBehaviour> ().cropName.ToLower());
			}
		}
	}

	void OnTriggerExit(Collider col){
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
		if (col.gameObject.tag == "crop") {
			buttonToPress.hidePanel ();
		}
	}

	void OnCollisionExit(Collision col){
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
		if (col.gameObject.tag == "shopCounter") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "ShippingBinObject") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "Fountain") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "Farm") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "MyHouse") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "Bed") {
			buttonToPress.hidePanel ();
		} else if (col.gameObject.tag == "NPC") {
			buttonToPress.hidePanel ();
		}
	}
}
