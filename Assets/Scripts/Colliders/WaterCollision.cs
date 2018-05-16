using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour {

	public bool collision;


	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Square") {
			collision = true;

		}
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Square") {
			collision = false;
		}

	}
}
