using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour {


	public Rigidbody player;
	Vector3 movement;
	float speed = 30.0f;
	Animator anim;
	HoldingItem holdingItem;
	void Start(){
		
		anim = GetComponent<Animator> ();
		holdingItem = GetComponent<HoldingItem> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (!this.GetComponent<Animator> ().GetBool ("isPlowing") 
			&& !this.GetComponent<Animator> ().GetBool ("isRecollecting")  
			&& !this.GetComponent<Animator> ().GetBool ("isPlanting") 
			&& !this.GetComponent<Animator> ().GetBool ("isWatering")
			&& !this.GetComponent<Animator> ().GetBool ("isCutting")) {
			float x = Input.GetAxisRaw ("Horizontal") * Time.deltaTime;
			float z = Input.GetAxisRaw ("Vertical") * Time.deltaTime;

			movement.Set (x, 0, z);
			movement = movement.normalized * speed * Time.deltaTime;
			player.MovePosition (transform.position + movement);
			Animate (x, z);
			Rotate (x,z);
		}

	}

	void Animate(float x, float z){
		bool walking = x!= 0f || z != 0f;
		if (holdingItem.holdingItem) {
			anim.SetBool ("isHoldingAndWalking", walking);
		} else {
			anim.SetBool ("isWalking", walking);
		}

	}

	void Rotate(float x, float z){

		if (x>0 && z > 0) {
			transform.rotation = Quaternion.LookRotation (new Vector3(1,0,1).normalized);
		}else if (x>0 && z < 0) {
			transform.rotation = Quaternion.LookRotation (new Vector3(1,0,-1).normalized);
		}else if (x<0 && z < 0) {
			transform.rotation = Quaternion.LookRotation (new Vector3(-1,0,-1).normalized);
		}else if (x<0 && z > 0) {
			transform.rotation = Quaternion.LookRotation (new Vector3(-1,0,1).normalized);
		}
		else if (x < 0) {
			transform.rotation = Quaternion.LookRotation (Vector3.left);
		}else if (x > 0) {
			transform.rotation = Quaternion.LookRotation (Vector3.right);
		}else if (z < 0) {
			transform.rotation = Quaternion.LookRotation (Vector3.back);
		}else if (z > 0) {
			transform.rotation = Quaternion.LookRotation (Vector3.forward);
		}



	}
}
