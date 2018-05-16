using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAreasActived : MonoBehaviour {
	public GameObject[] farmSpawn;
	public GameObject[] roadSpawn;
	// Use this for initialization
	void Start () {
		farmSpawn = GameObject.FindGameObjectsWithTag ("FarmSpawnArea");
		roadSpawn = GameObject.FindGameObjectsWithTag ("RoadSpawnArea");
		if (SceneManager.GetActiveScene ().name.Contains ("Outside")) {
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (false);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (true);
			}
		} else if (SceneManager.GetActiveScene ().name.Contains ("Road")) {
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (true);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (false);
			}
		} else {
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (false);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (false);
			}
		}
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
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (false);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (true);
			}
		} else if (SceneManager.GetActiveScene ().name.Contains ("Road")) {
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (true);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (false);
			}
		} else {
			foreach (GameObject sr in roadSpawn) {
				sr.SetActive (false);
			}
			foreach (GameObject sf in farmSpawn) {
				sf.SetActive (false);
			}
		}
	}
}
