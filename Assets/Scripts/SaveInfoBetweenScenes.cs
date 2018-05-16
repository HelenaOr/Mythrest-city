using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveInfoBetweenScenes : MonoBehaviour {

	public GameObject hide;

	void Awake ()
	{


		DontDestroyOnLoad (this);

		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}


	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;

	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		


		if (SceneManager.GetActiveScene ().name.Contains ("Outside")) {
			Debug.Log ("true");

			hide.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

		}
		else {
			Debug.Log ("false");

			hide.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}

}
