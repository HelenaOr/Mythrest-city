using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Button resume;
	public Button exit;
	public Transform Pause;
	// Use this for initialization
	void Start () {
	
		resume.onClick.AddListener (Resume);
		exit.onClick.AddListener (Exit);

	}
	

	void Exit(){
		Application.Quit ();
	}

	void Resume(){
		Pause.gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}
}
