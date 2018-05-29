using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsManager : MonoBehaviour
{

	public static int numberOfObjects = 7;
	public List<GameObject> spawnedItems;
	public Transform spawnCenter;
	public GameObject apricot;
	public GameObject plum;
	public GameObject blackberry;
	public GameObject gojiberry;
	public GameObject branch;

	TimeManager timeManager;

	public TimeManager.seasons season;
	// Use this for initialization
	void Start ()
	{
		

		spawnCenter = GetComponent<Transform> ();

		apricot = Resources.Load<GameObject> ("SpawnItems/Apricot");
		plum = Resources.Load<GameObject> ("SpawnItems/Plum");
		blackberry = Resources.Load<GameObject> ("SpawnItems/BlackBerry");
		gojiberry = Resources.Load<GameObject> ("SpawnItems/GojiBerry");
		branch = Resources.Load<GameObject> ("SpawnItems/Branch");

		Spawn ();



	}

	public void Spawn ()
	{
		timeManager = FindObjectOfType (typeof(TimeManager)) as TimeManager;
		season = timeManager.getSeason ();
		for (int i = 0; i < numberOfObjects; i++) {
			
			Vector3 pos = SpawnRadius (spawnCenter.position, 8.0f);

			if (timeManager.getSeason ().Equals (TimeManager.seasons.SPRING)) {
				int random = Random.Range (1, 4);
				int randAng = Random.Range (0, 361);
				if (random == 1) {

					GameObject instanceAP = Instantiate (apricot, pos, Quaternion.Euler(-90,randAng,0));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);

				} else {
					GameObject instanceAP = Instantiate (branch, pos, Quaternion.Euler(-90,randAng,0));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);
				}

			}if (timeManager.getSeason ().Equals (TimeManager.seasons.SUMMER)) {
				int randAng = Random.Range (0, 361);

				int random = Random.Range (1, 4);
				if (random == 1) {

					GameObject instanceAP = Instantiate (plum, pos, new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);

				} else {
					GameObject instanceAP = Instantiate (branch, pos,  new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);
				}
			}if (timeManager.getSeason ().Equals (TimeManager.seasons.FALL)) {
				int randAng = Random.Range (0, 361);

				int random = Random.Range (1, 4);
				if (random == 1) {

					GameObject instanceAP = Instantiate (blackberry, pos, new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);

				} else {
					GameObject instanceAP = Instantiate (branch, pos, new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);
				}
			}if (timeManager.getSeason ().Equals (TimeManager.seasons.WINTER)) {
				int randAng = Random.Range (0, 361);

				int random = Random.Range (1, 4);
				if (random == 1) {

					GameObject instanceAP = Instantiate (gojiberry, pos, new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);

				} else {
					GameObject instanceAP = Instantiate (branch, pos, new Quaternion(-90,randAng,0,1));
					instanceAP.transform.SetParent (spawnCenter);
					spawnedItems.Add (instanceAP);
				}
			}



		}
			
		

			
			

	}

	Vector3 SpawnRadius (Vector3 center, float radius)
	{
		float ang = Random.value * 360;
		float ang2 = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin (ang2 * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + radius * Mathf.Cos (ang * Mathf.Deg2Rad);
		return pos;

	}

}
