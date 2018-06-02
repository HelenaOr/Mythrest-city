using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

	float seconds = 0;

	float hour = 8.0f;
	float day = 1.0f;
	float month = 1.0f;
	float year = 1.0f;

	public enum seasons {SPRING, SUMMER, FALL, WINTER};
	public seasons season;

	public enum weather {SUNNY, RAIN, SNOW, RAINSTORM, SNOWSTORM};
	public weather dayWeather;

	public CreateSoil s;
	public MockCropDB parent;
	public CropBehaviour[] crops;
	public Material notPlowed;
	public Material plowed;
	public Material wateredM;
	public Material dryCrop;
	public TimeManager time;
	public PlayerStamina stamina;
	public WheatherSystem weatherSystem;
	public TreeBehaviour[] allTrees;

	public GameObject spawnFarmAreas;
	public GameObject spawnRoadAreas;

	void Start(){
		weatherSystem = FindObjectOfType (typeof(WheatherSystem)) as WheatherSystem;
		setWeather ();

	}
	// Update is called once per frame
	void Update () {
		
		if (seconds <= 60) {
			seconds += Time.deltaTime;
		} else {
			seconds = 0;
			hour += 1;
		}
		if (hour >= 24) {
			resetDay ();
			setWeather ();
		}
		if (day >= 31) {
			day = 1;
			month += 1;

		}
		if (month >= 5) {
			
			month = 1;
			year += 1;
		}

		//Debug.Log (seconds);
		setSeason ();

	}


	void setSeason(){
		if (month == 1) {
			season = seasons.SPRING;
		}
		if (month == 2) {
			season = seasons.SUMMER;
		}
		if (month == 3) {
			season = seasons.FALL;
		}
		if (month == 4) {
			season = seasons.WINTER;
		}

	}

	public void setWeather(){

		int random = UnityEngine.Random.Range (1, 10);

		if (season == seasons.SPRING) {
			if (random >= 1 && random <= 6) {
				dayWeather = weather.SUNNY;

			} else if (random == 7) {
				dayWeather = weather.RAINSTORM;
			} else {
				dayWeather = weather.RAIN;
			}
		}
		if (season == seasons.SUMMER) {
			if (random >= 1 && random <= 7) {
				dayWeather = weather.SUNNY;

			} else if (random == 8) {
				dayWeather = weather.RAINSTORM;
			} else {
				dayWeather = weather.RAIN;
			}
		}
		if (season == seasons.FALL) {
			if (random >= 1 && random <= 6) {
				dayWeather = weather.SUNNY;
			} else if (random == 7) {
				dayWeather = weather.RAINSTORM;
			} else {
				dayWeather = weather.RAIN;
			}
		}
		if (season == seasons.WINTER) {
			if (random >= 1 && random <= 6) {
				dayWeather = weather.SNOW;
			} else if (random == 7) {
				dayWeather = weather.SNOWSTORM;
			} else {
				dayWeather = weather.SUNNY;
			}
		}
		weatherSystem.weatherParticlesEnabled ();
	}


	public float getSeconds(){
		return seconds;
	}

	public void setSeconds(float seconds){
		this.seconds = seconds;
	}

	public float getHours(){
		return hour;
	}

	public void setHours(float hour){
		this.hour = hour;
	}

	public float getDay(){
		return day;
	}

	public void setDay(float day){
		this.day = day;
	}

	public float getMonth(){
		return month;
	}

	public float getYear(){
		return year;
	}

	public seasons getSeason(){
		return season;
	}

	public weather getWeather(){
		return dayWeather;
	}



	// This is the function where the time is reseted each day
	//not only reseting time values but reseting the soil,
	//checking the state of our crops and reseting the player stamina

	public void resetDay(){
		
		crops = parent.GetComponentsInChildren<CropBehaviour> ();
		allTrees = FindObjectsOfType<TreeBehaviour> ();
		for (int i = 0; i < s.getSoil ().Count; i++) {
			if (s.getSoil () [i].soilType == Soil.SoilTypes.PLOWED || s.getSoil () [i].soilType == Soil.SoilTypes.WATERED) {
				s.getSoil () [i].soilType = Soil.SoilTypes.NOTPLOWED;
				s.getSoil () [i].getSoil ().GetComponent<Renderer> ().material = notPlowed;

			}
			if ((s.getSoil () [i].soilType == Soil.SoilTypes.WATEREDANDPLATED || s.getSoil()[i].soilType == Soil.SoilTypes.PLANTED)) {
				s.getSoil () [i].soilType = Soil.SoilTypes.PLANTED;
				s.getSoil () [i].getSoil ().GetComponent<Renderer> ().material = plowed;
			}
		}

		for (int i = 0; i < crops.Length; i++) {
			if (!crops [i].watered && ! crops[i].state.Equals(Crops.cropStates.HARVEST)) {
				if (crops [i].state.Equals (Crops.cropStates.SEED)) {
					crops [i].dayToS1 += 1;
					crops [i].dayToS2 += 1;
					crops [i].dayToHarvest += 1;
				}
				if (crops [i].state.Equals (Crops.cropStates.ST1)) {
					crops [i].dayToS2 += 1;
					crops [i].dayToHarvest += 1;
				}
				if (crops [i].state.Equals (Crops.cropStates.ST2)) {
					crops [i].dayToHarvest += 1;
				}
				crops [i].dry = true;

			} else {
				crops [i].dry = false;
				crops [i].growing ();
			}
		}

		stamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();

		if (stamina.fainted) {
			stamina.staminaSlider.value = 50;
			stamina.currentStamina = 50;
		} else {
			stamina.staminaSlider.value = 100;
			stamina.currentStamina = 100;
		}

		foreach (TreeBehaviour howManyDays in allTrees) {
			howManyDays.daysToNextStage -= 1;
			howManyDays.growingTree ();
		}

		MockNPCDB allNpc = FindObjectOfType (typeof(MockNPCDB)) as MockNPCDB;

		allNpc.Emily.gifted = false;
		allNpc.Emily.talked = false;

		allNpc.Riley.gifted = false;
		allNpc.Riley.talked = false;

		allNpc.Lily.gifted = false;
		allNpc.Lily.talked = false;

		allNpc.Tyler.gifted = false;
		allNpc.Tyler.talked = false;

		for (int i = 0; i < spawnFarmAreas.transform.childCount; i++) {

			for (int j = 0; j < spawnFarmAreas.transform.GetChild (i).childCount; j++) {
				Destroy (spawnFarmAreas.transform.GetChild (i).GetChild (j).gameObject);
			}
			spawnFarmAreas.transform.GetChild (i).GetComponent<SpawnItemsManager> ().spawnedItems = new List<GameObject> ();
			spawnFarmAreas.transform.GetChild (i).GetComponent<SpawnItemsManager> ().Spawn ();
		}

		for (int i = 0; i < spawnRoadAreas.transform.childCount; i++) {

			for (int j = 0; j < spawnRoadAreas.transform.GetChild (i).childCount; j++) {
				Destroy (spawnRoadAreas.transform.GetChild (i).GetChild (j).gameObject);
			}
			spawnRoadAreas.transform.GetChild (i).GetComponent<SpawnItemsManager> ().spawnedItems = new List<GameObject> ();
			spawnRoadAreas.transform.GetChild (i).GetComponent<SpawnItemsManager> ().Spawn ();
		}

		seconds = 0.0f;
		hour = 6.0f;
		day = day + 1;
		setWeather ();

	}

}
