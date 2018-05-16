using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBinManager : MonoBehaviour {

	public Canvas shippingBin;
	// Use this for initialization
	void Start () {
		shippingBin = GameObject.FindGameObjectWithTag ("ShippingBin").GetComponentInChildren<Canvas> (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<ShippingBinCollider> ().collision && Input.GetKey (KeyCode.E)) {
			shippingBin.gameObject.SetActive (true);
			Time.timeScale = 0.0f;
		
		}
	}

}
