using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCollision : MonoBehaviour {

	public bool collision;
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag =="Player") {
			
			collision = true;

		}
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Player") {
			collision = false;
		}
	}
}
