using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToPress : MonoBehaviour {

	Sprite E;
	Sprite I;
	Sprite F;
	Sprite X;
	Sprite rightMouse;
	// Use this for initialization
	void Start () {
		E = Resources.Load<Sprite> ("Keys/E");
		I = Resources.Load<Sprite> ("Keys/I");
		F = Resources.Load<Sprite> ("Keys/F");
		X = Resources.Load<Sprite> ("Keys/X");
		rightMouse = Resources.Load<Sprite> ("Keys/rightMouse");
	}
	
	public void showPanel(string letter, string textToShow){
		this.transform.Find ("ButtonToPressPanel").gameObject.SetActive(true);
		Transform panel = this.transform.Find ("ButtonToPressPanel");
		if (letter == "E") {
			panel.Find("Image").GetComponent<Image>().sprite= E;
		}else if (letter == "I") {
			panel.Find("Image").GetComponent<Image>().sprite = I;
		}else if (letter == "F") {
			panel.Find("Image").GetComponent<Image>().sprite = F;
		}else if (letter == "X") {
			panel.Find("Image").GetComponent<Image>().sprite = X;
		}else if (letter == "rightMouse") {
			panel.Find("Image").GetComponent<Image>().sprite = rightMouse;
		}
		panel.GetComponentInChildren<Text> ().text = textToShow;
	}

	public void hidePanel(){
		this.transform.Find ("ButtonToPressPanel").gameObject.SetActive(false);
	}

}
