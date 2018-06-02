﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class MovingBetweenScenes : MonoBehaviour
{

	public GameObject player;
	public GameObject[] allNPCs;
	public TimeManager timeManager;
	public DoorCollisions[] doorCollision;
	public RoadCollisions[] roadCollision;

	public static Vector3 posToSpawnOutside = new Vector3 (-56.86f, 4.2f, 71.21f);
	public static Vector3 posToSpawnInside = new Vector3 (9.5f, 4.2f, 55.4f);

	public static Vector3 posToSpawnOnRoadFromFarm = new Vector3 (86f, 4.2f, -7.3f);
	public static Vector3 posToSpawnOnRoadFromVillage = new Vector3 (-86f, 4.2f, -7.3f);

	public static Vector3 posToSpawnOnFarmFromRoad = new Vector3 (-78.6f, 4.2f, -3.2f);

	public static Vector3 posToSpawnonVillageFromRoad = new Vector3 (0.0f, 4.2f, -41.8f);
	public static Vector3 posToSpawnOnVillageFromShop = new Vector3 (64.7f, 4.2f, -43.77f);
	public static Vector3 posToSpawnOnVillageFromEmilyHouse = new Vector3 (-69f, 4.2f, 26.35f);
	public static Vector3 posToSpawnOnVillageFromRyleyHouse = new Vector3 (-25.9f, 4.2f, 27f);
	public static Vector3 posToSpawnOnVillageFromLilyTylerHouse = new Vector3 (-68.2f, 4.2f, -43.3f);

	public static Vector3 posToSpawnOnShop = new Vector3 (-5.3f, 4.2f, -31.8f);
	public static Vector3 posToSpawnOnEmilyHouse = new Vector3 (-20.7f, 4.2f, -25f);
	public static Vector3 posToSpawnOnRileyHouse = new Vector3 (-9.66f, 4.2f, -28.22f);
	public static Vector3 posToSpawnOnLilyTylerHouse = new Vector3 (-19.7f, 4.2f, -26.27f);

	// Use this for initialization
	void Start ()
	{
	}

	
	// Update is called once per frame
	void Update ()
	{
		enterExitHouse ();
		roadMovement ();
		
	}


	void enterExitHouse ()
	{
		doorCollision = GameObject.FindObjectsOfType<DoorCollisions> ();

		foreach (DoorCollisions col in doorCollision) {

			if (col.collision == true) {
				if (Input.GetKey (KeyCode.E)) {

					if (col.tag == "MyHouse") {
						player.transform.position = posToSpawnOutside;
						SceneManager.LoadScene ("FarmOutside");
					} else if (col.tag == "Farm") {
						player.transform.position = posToSpawnInside;
						SceneManager.LoadScene ("FarmInside");
					} else if (col.tag == "VillajeToShop") {
						if (timeManager.getHours () >= 8.0f && timeManager.getHours () < 17.0f) {
							player.transform.position = posToSpawnOnShop;
							SceneManager.LoadScene ("Shop");
						} else {
							Debug.Log ("ShopClosed");
						}

					} else if (col.tag == "VillageToEmilyHouse") {
						player.transform.position = posToSpawnOnEmilyHouse;
						SceneManager.LoadScene ("EmilyHouse");
					} else if (col.tag == "VillageToRileyHouse") {
						player.transform.position = posToSpawnOnRileyHouse;
						SceneManager.LoadScene ("RileyHouse");
					} else if (col.tag == "VillageToLilyTylerHouse") {
						player.transform.position = posToSpawnOnLilyTylerHouse;
						SceneManager.LoadScene ("LilyTylerHouse");
					} else if (col.tag == "ShopToVillaje") {
						player.transform.position = posToSpawnOnVillageFromShop;
						SceneManager.LoadScene ("Village");
					} else if (col.tag == "EmilyHouseToVillaje") {
						player.transform.position = posToSpawnOnVillageFromEmilyHouse;
						SceneManager.LoadScene ("Village");
					} else if (col.tag == "LilyTylerHouseToVillage") {
						player.transform.position = posToSpawnOnVillageFromLilyTylerHouse;
						SceneManager.LoadScene ("Village");
					} else if (col.tag == "RileyHouseToVillage") {
						player.transform.position = posToSpawnOnVillageFromRyleyHouse;
						SceneManager.LoadScene ("Village");
					}
				}
			}

		}


	}

	void roadMovement ()
	{
		roadCollision = GameObject.FindObjectsOfType<RoadCollisions> ();

		foreach (RoadCollisions col in roadCollision) {
			if (col.collision == true) {
				if (col.tag == "RoadToFarm") {
					player.transform.position = posToSpawnOnFarmFromRoad;

					SceneManager.LoadScene ("FarmOutside");
				} else if (col.tag == "RoadToVillaje") {
					player.transform.position = posToSpawnonVillageFromRoad;
					SceneManager.LoadScene ("Village");
				} else if (col.tag == "FarmToRoad") {
					player.transform.position = posToSpawnOnRoadFromFarm;
					SceneManager.LoadScene ("Road");
				} else if (col.tag == "VillageToRoad") {
					player.transform.position = posToSpawnOnRoadFromVillage;
					SceneManager.LoadScene ("Road");
				}
			}
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
		
		timeManager = FindObjectOfType (typeof(TimeManager)) as TimeManager;
		if (SceneManager.GetActiveScene ().name.Equals ("Village")) {
			Debug.Log (SceneManager.GetActiveScene ().name);
			allNPCs = GameObject.FindGameObjectsWithTag ("NPC");

			foreach (GameObject npc in allNPCs) {

				if (npc.name.Contains ("Emily")) {

					if (timeManager.getHours () >= 9.0f && timeManager.getHours () < 19.0f) {
						npc.SetActive (true);
					}
					else {
						npc.SetActive (false);
					}

				}
				if (npc.name.Contains ("Lily")) {
					if (timeManager.getHours () >= 7.0f && timeManager.getHours () < 8.0f) {
						npc.SetActive (true);
					} else if (timeManager.getHours () >= 17.0f && timeManager.getHours () < 20.0f) {
						npc.SetActive (true);
					} else {
						npc.SetActive (false);
					}
				}
				if (npc.name.Contains ("Riley")) {
					if (timeManager.getHours () >= 10.0f && timeManager.getHours () < 20.0f) {
						npc.SetActive (true);
					
					} else {
						npc.SetActive (false);
					}
				}if (npc.name.Contains ("Tyler")) {
					if (timeManager.getHours () >= 7.0f && timeManager.getHours () < 19.0f) {
						npc.SetActive (true);

					} else {
						npc.SetActive (false);
					}
				}
					
			}
			
		}

		if (SceneManager.GetActiveScene ().name.Equals ("EmilyHouse")) {
			Debug.Log (SceneManager.GetActiveScene ().name);
			allNPCs = GameObject.FindGameObjectsWithTag ("NPC");

			foreach (GameObject npc in allNPCs) {

				if (npc.name.Contains ("Emily")) {

					if (timeManager.getHours () >= 9.0f && timeManager.getHours () < 19.0f) {
						npc.SetActive (false);
					} else {
						npc.SetActive (true);
					}

				}

			}

		}

		if (SceneManager.GetActiveScene ().name.Equals ("LilyTylerHouse")) {
			Debug.Log (SceneManager.GetActiveScene ().name);
			allNPCs = GameObject.FindGameObjectsWithTag ("NPC");

			foreach (GameObject npc in allNPCs) {

				if (npc.name.Contains ("Lily")) {

					if (timeManager.getHours () >= 6.0f && timeManager.getHours () < 7.0f) {
						npc.SetActive (true);
					} else if (timeManager.getHours () >= 20.0f) {
						npc.SetActive (true);
					}
					else {
						npc.SetActive (false);
					}

				}if (npc.name.Contains ("Tyler")) {

					if (timeManager.getHours () >= 6.0f && timeManager.getHours () < 7.0f) {
						npc.SetActive (true);
					} else if (timeManager.getHours () >= 19.0f) {
						npc.SetActive (true);
					}
					else {
						npc.SetActive (false);
					}

				}

			}

		}
		if (SceneManager.GetActiveScene ().name.Equals ("RileyHouse")) {
			Debug.Log (SceneManager.GetActiveScene ().name);
			allNPCs = GameObject.FindGameObjectsWithTag ("NPC");

			foreach (GameObject npc in allNPCs) {

				if (npc.name.Contains ("Riley")) {

					if (timeManager.getHours () >= 10.0f && timeManager.getHours () < 20.0f) {
						npc.SetActive (false);
					} else {
						npc.SetActive (true);
					}

				}

			}

		}
		if (SceneManager.GetActiveScene ().name.Equals ("Shop")) {
			Debug.Log (SceneManager.GetActiveScene ().name);
			allNPCs = GameObject.FindGameObjectsWithTag ("NPC");

			foreach (GameObject npc in allNPCs) {

				if (npc.name.Contains ("Lily")) {
					if (timeManager.getHours () >= 8.0f && timeManager.getHours () < 17.0f) {
						npc.GetComponent<NPCMovement> ().enabled = false;
						npc.GetComponent<Animator> ().SetBool ("isWalking", false);
						npc.SetActive (true);
					} 
					else {
						npc.SetActive (false);
					}

				}

			}

		}


	}


}
