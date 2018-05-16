using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToBed : MonoBehaviour {


	public GameObject panel;
	public Rigidbody player;
	public TextMesh playerText;
	BedCollision bedCollision;
	ButtonToPress buttonToPress;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();
		playerText = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<TextMesh> ();
		bedCollision = FindObjectOfType<BedCollision> ();
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Vector3.Distance (player.position, transform.position));
		if (bedCollision.collision) {
			
			showPanel ();


		} else {
			Time.timeScale = 1.0f;
			panel.SetActive (false);

		}
		
	}

	void showPanel(){

		if (Input.GetKey (KeyCode.E)) {
			
			panel.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}
}
