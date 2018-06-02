using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollision : MonoBehaviour {

	public bool collision;
	public GameObject NPC;
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag =="NPC") {
			collision = true;
			NPC = col.gameObject;

		}
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "NPC") {
			collision = false;
		}
	}
}