using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainCollider : MonoBehaviour {


	public bool collision;

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag =="Fountain") {
			collision = true;

		}
	}

	void OnCollisionExit(Collision col){

		if (col.gameObject.tag == "Fountain") {
			collision = false;
		}
	}

}
