using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour {

	Button newGameButton;

	// Use this for initialization
	void Start () {

		newGameButton = GetComponentInChildren<Button> ();
		newGameButton.onClick.AddListener (NewGame);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NewGame(){
		SceneManager.LoadScene ("FarmOutside");
	}
}
