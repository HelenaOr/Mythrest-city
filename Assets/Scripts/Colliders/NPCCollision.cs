using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollision : MonoBehaviour {

	public bool collision;
	public GameObject NPC;
	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag =="NPC") {
			collision = true;
			NPC = col.gameObject;

		}
	}

	void OnCollisionExit(Collision col){

		if (col.gameObject.tag == "NPC") {
			collision = false;
		}
	}
}