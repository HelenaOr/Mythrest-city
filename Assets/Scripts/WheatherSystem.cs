using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class WheatherSystem : MonoBehaviour
{

	public ParticleSystem rainSystem;
	public TimeManager timeManager;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("start");
		timeManager = GameObject.FindGameObjectWithTag ("TimeManager").GetComponent<TimeManager> ();

		if (timeManager.getWeather ().Equals (TimeManager.weather.RAIN) || timeManager.getWeather ().Equals (TimeManager.weather.RAINSTORM)) {
			Debug.Log ("entro");
			if (SceneManager.GetActiveScene ().name.Contains ("Inside")) {
				rainSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (true);
				Debug.Log ("Outside");
			}

		} else {
			rainSystem.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void weatherParticlesEnabled ()
	{
		timeManager = GameObject.FindGameObjectWithTag ("TimeManager").GetComponent<TimeManager> ();

		if (timeManager.getWeather ().Equals (TimeManager.weather.RAIN) || timeManager.getWeather ().Equals (TimeManager.weather.RAINSTORM)) {
			if (SceneManager.GetActiveScene ().name.Contains ("Inside")) {
				rainSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (true);
				Debug.Log ("Outside");
			}
				
		} else {
			rainSystem.gameObject.SetActive (false);
		}
	}

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		weatherParticlesEnabled ();
	}
}
