using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour {

	public Button[] buttons;
	public Transform[] images ;
	public Sprite[] tools;
	public Sprite[] maps;
	public Sprite[] basics;
	public Transform allInstructions;
	// Use this for initialization
	void Start () {

		tools = Resources.LoadAll <Sprite>("Instructions/Tools") as Sprite[];
		maps = Resources.LoadAll <Sprite>("Instructions/Map") as Sprite[];
		basics = Resources.LoadAll <Sprite>("Instructions/Basics") as Sprite[];
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
		Transform t = this.transform.Find ("InstructionSelector");
		t.gameObject.SetActive (true);
		Button[] buttons = t.GetComponentsInChildren<Button> ();

		foreach (Button b in buttons) {
			if (b.name.Contains ("Basics")) {
				b.onClick.AddListener (ShowBasics);
			}if (b.name.Contains ("World")) {
				b.onClick.AddListener (ShowWorld);
			}if (b.name.Contains ("Tools")) {
				b.onClick.AddListener (ShowTools);
			}if (b.name.Contains ("Back")) {
				b.onClick.AddListener (Back);
			}
		}


	}
	void Back(){
		Transform t = this.transform.Find ("InstructionSelector");
		t.gameObject.SetActive (false);
	}
	void ShowBasics(){
		Transform t = this.transform.Find ("InstructionImage");
		t.gameObject.SetActive (true);

		t.GetComponent<Image> ().sprite = basics [0];
		t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextBasicsImage (0));
	}
	void ShowWorld(){
		Transform t = this.transform.Find ("InstructionImage");
		t.gameObject.SetActive (true);

		t.GetComponent<Image> ().sprite = maps [0];
		t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextWorldImage (0));
	}
	void ShowTools(){
		Transform t = this.transform.Find ("InstructionImage");
		t.gameObject.SetActive (true);
		t.GetComponent<Image> ().sprite = tools [0];
		t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextToolImage (0));
	}

	void NextBasicsImage(int currentImage){
		Transform t = this.transform.Find ("InstructionImage");

		if (currentImage == 0) {
			t.GetComponent<Image> ().sprite = basics [1];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextBasicsImage (1));
		}if (currentImage == 1) {
			t.GetComponent<Image> ().sprite = basics [2];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextBasicsImage (2));
		}if (currentImage == 2) {
			t.GetComponent<Image> ().sprite = basics [3];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextBasicsImage (3));
		}if (currentImage == 3) {
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.gameObject.SetActive (false);
		}
	}

	void NextWorldImage(int currentImage){
		Transform t = this.transform.Find ("InstructionImage");

		if (currentImage == 0) {
			t.GetComponent<Image> ().sprite = maps [1];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextWorldImage (1));
		}if (currentImage == 1) {
			t.GetComponent<Image> ().sprite = maps [2];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextWorldImage (2));
		}if (currentImage == 2) {
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.gameObject.SetActive (false);
		}
	}

	void NextToolImage(int currentImage){
		Transform t = this.transform.Find ("InstructionImage");

		if (currentImage == 0) {
			t.GetComponent<Image> ().sprite = tools [1];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextToolImage (1));
		}if (currentImage == 1) {
			t.GetComponent<Image> ().sprite = tools [2];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextToolImage (2));
		}if (currentImage == 2) {
			t.GetComponent<Image> ().sprite = tools [3];
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.GetComponentInChildren<Button> ().onClick.AddListener (() => NextToolImage (3));
		}if (currentImage == 3) {
			t.GetComponentInChildren<Button> ().onClick.RemoveAllListeners ();
			t.gameObject.SetActive (false);
		}
	}
}
