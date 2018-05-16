using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowTime : MonoBehaviour {

	public Text dateText;
	public Text weatherSeasonText;
	public Text hourText;


	String sHour;
	String sMin;
	TimeManager timeManager;
	public Image weather;

	public Sprite sunny;
	public Sprite rainy;
	public Sprite rainStorm;
	public Sprite snowy;
	public Sprite snowStorm;

	public Canvas canvas;

	void Start(){

		sunny = Resources.Load<Sprite>("WeatherImages/weather/sunny");
		rainy = Resources.Load<Sprite>("WeatherImages/weather/rainy");
		rainStorm = Resources.Load<Sprite>("WeatherImages/weather/rainstorm");
		snowy = Resources.Load<Sprite>("WeatherImages/weather/snowy");
		snowStorm = Resources.Load<Sprite>("WeatherImages/weather/snowstorm");
		timeManager = FindObjectOfType<TimeManager> ();
	}
	// Update is called once per frame
	void Update () {

		hourText.text = "Hour: " + formatDate ();
		dateText.text = "Day: " + timeManager.getDay() + " Month: " + timeManager.getMonth() + " Year: " + timeManager.getYear();
		weatherSeasonText.text = "Season: " + timeManager.getSeason() + "\nWeather: " + timeManager.getWeather();
		weatherImage ();
	}

	private String formatDate(){

		if (timeManager.getHours() <= 10) {
			String h = timeManager.getHours().ToString ();
			sHour = "0" + h;
		} else {
			String h = timeManager.getHours().ToString ();
			sHour = h;
		}

		if (timeManager.getSeconds() <= 10) {
			int im = (int)timeManager.getSeconds();
			String m = im.ToString ();
			sMin = "0" + m;
		} else {
			int im = (int)timeManager.getSeconds();
			String m = im.ToString ();
			sMin = m;
		}

		return sHour + ":" + sMin;
	}

	public void weatherImage(){

		if (timeManager.getWeather ().Equals (TimeManager.weather.SUNNY)) {
			weather.sprite = sunny;
		} else if (timeManager.getWeather ().Equals (TimeManager.weather.RAIN)) {
			weather.sprite = rainy;
		} else if (timeManager.getWeather ().Equals (TimeManager.weather.RAINSTORM)) {
			weather.sprite = rainStorm;
		} else if (timeManager.getWeather ().Equals (TimeManager.weather.SNOW)) {
			weather.sprite = snowy;
		} else if (timeManager.getWeather ().Equals (TimeManager.weather.SNOWSTORM)) {
			weather.sprite = snowStorm;
		}

	}
}
