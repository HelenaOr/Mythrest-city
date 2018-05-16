using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour {

	public bool collision;

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag =="Player") {
			collision = true;

		}
	}

	void OnCollisionExit(Collision col){

		if (col.gameObject.tag == "Player") {
			collision = false;
		}
	}
}
