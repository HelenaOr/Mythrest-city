using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public Button yes;
	public Button no;

	TimeManager timeManager;
	public Material notPlowed;
	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		
		timeManager = FindObjectOfType<TimeManager> ();
		playerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		yes.onClick.AddListener (NextDay);
		no.onClick.AddListener (Exit);
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void NextDay(){
		Time.timeScale = 1.0f;
		timeManager.resetDay ();
		playerMovement.enabled = false;
		GameObject.FindGameObjectWithTag ("sleepingHolder").transform.Find ("SleepImage").gameObject.SetActive (true);
		StartCoroutine (sleepCanvas ());


	}

	void Exit(){
		Time.timeScale = 1.0f;
		this.GetComponentInParent<Canvas> ().gameObject.SetActive(false);
		
	}

	IEnumerator sleepCanvas(){
		yield return new WaitForSeconds (2);
		playerMovement.enabled = true;
		GameObject.FindGameObjectWithTag ("sleepingHolder").transform.Find ("SleepImage").gameObject.SetActive (false);
	}
}
