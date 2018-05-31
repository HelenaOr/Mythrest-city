using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class WheatherSystem : MonoBehaviour
{

	public ParticleSystem rainSystem;
	public ParticleSystem snowSystem;
	public TimeManager timeManager;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("start");
		timeManager = GameObject.FindGameObjectWithTag ("TimeManager").GetComponent<TimeManager> ();

		if (timeManager.getWeather ().Equals (TimeManager.weather.RAIN) || timeManager.getWeather ().Equals (TimeManager.weather.RAINSTORM)) {
			if (SceneManager.GetActiveScene ().name.Contains ("Inside") || SceneManager.GetActiveScene ().name.Contains ("House") || SceneManager.GetActiveScene ().name.Contains ("Shop")) {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (true);
				snowSystem.gameObject.SetActive (false);

			}

		} else if(timeManager.getWeather ().Equals (TimeManager.weather.SNOW) || timeManager.getWeather ().Equals (TimeManager.weather.SNOWSTORM)){
			if (SceneManager.GetActiveScene ().name.Contains ("Inside") || SceneManager.GetActiveScene ().name.Contains ("House") || SceneManager.GetActiveScene ().name.Contains ("Shop")) {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (true);

			}
		}
		else {
			rainSystem.gameObject.SetActive (false);
			snowSystem.gameObject.SetActive (false);
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
			if (SceneManager.GetActiveScene ().name.Contains ("Inside") || SceneManager.GetActiveScene ().name.Contains ("House") || SceneManager.GetActiveScene ().name.Contains ("Shop")) {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (true);
				snowSystem.gameObject.SetActive (false);

			}

		} else if(timeManager.getWeather ().Equals (TimeManager.weather.SNOW) || timeManager.getWeather ().Equals (TimeManager.weather.SNOWSTORM)){
			if (SceneManager.GetActiveScene ().name.Contains ("Inside") || SceneManager.GetActiveScene ().name.Contains ("House") || SceneManager.GetActiveScene ().name.Contains ("Shop")) {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (false);
				Debug.Log ("Inside");
			} else {
				rainSystem.gameObject.SetActive (false);
				snowSystem.gameObject.SetActive (true);

			}
		}
		else {
			rainSystem.gameObject.SetActive (false);
			snowSystem.gameObject.SetActive (false);
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
