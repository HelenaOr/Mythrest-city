using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilCollision : MonoBehaviour {

	public bool collision;
	void OnCollisionEnter(Collision col){
		
		if (col.collider.gameObject.tag == "Player") {
			//col.gameObject.GetComponent<PlayerActions> ().plowSoil ();

			collision = true;

		}
	}

	void OnCollisionExit(Collision col){
		if (col.collider.gameObject.tag == "Player") {
			collision = false;
		}

	}
}
