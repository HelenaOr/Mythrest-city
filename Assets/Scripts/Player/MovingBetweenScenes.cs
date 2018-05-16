using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingBetweenScenes : MonoBehaviour
{

	public GameObject player;
	public DoorCollisions[] doorCollision;
	public RoadCollisions[] roadCollision;

	public static Vector3 posToSpawnOutside = new Vector3 (-55.3f,4.2f,59.7f);
	public static Vector3 posToSpawnInside =  new Vector3 (9.5f,4.2f,55.4f);

	public static Vector3 posToSpawnOnRoadFromFarm = new Vector3 (86f,4.2f,-7.3f);
	public static Vector3 posToSpawnOnRoadFromVillage = new Vector3 (-86f, 4.2f, -7.3f);

	public static Vector3 posToSpawnOnFarmFromRoad = new Vector3 (-75f,4.2f,-60f);

	public static Vector3 posToSpawnonVillageFromRoad = new Vector3 (-1.2f, 4.2f, -43.5f);

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
						col.collision = false;
						player.transform.position = posToSpawnOutside;
						SceneManager.LoadScene ("FarmOutside");
					} else if (col.tag == "Farm") {
						col.collision = false;
						player.transform.position = posToSpawnInside;
						SceneManager.LoadScene ("FarmInside");
					}

				}
			}

		}


	}

	void roadMovement(){
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



}
