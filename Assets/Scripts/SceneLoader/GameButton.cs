using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour {

	public Button[] buttons;
	public Transform[] images ;
	Sprite[] instructions;
	// Use this for initialization
	void Start () {

		instructions = Resources.LoadAll <Sprite>("Instructions") as Sprite[];
		buttons = GetComponentsInChildren<Button> ();
		foreach (Button b in buttons) {
			if (b.name.Contains ("Game")) {
				b.onClick.AddListener (NewGame);
			}if (b.name.Contains ("Instructions")) {
				b.onClick.AddListener (Instructions);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NewGame(){
		SceneManager.LoadScene ("FarmOutside");
	}

	void Instructions(){
		Transform t = this.transform.Find ("InstructionImage");
		t.gameObject.SetActive (true);
		t.GetComponent<Image> ().sprite = instructions [0];
		t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextImage (0));

	}

	void NextImage(int currentImage){
		Transform t = this.transform.Find ("InstructionImage");

		if (currentImage == 0) {
			t.GetComponent<Image> ().sprite = instructions [1];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextImage (1));
		}if (currentImage == 1) {
			t.GetComponent<Image> ().sprite = instructions [2];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextImage (2));
		}if (currentImage == 2) {
			t.GetComponent<Image> ().sprite = instructions [3];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextImage (3));
		}if (currentImage == 3) {
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.gameObject.SetActive (false);
		}
	}
}
