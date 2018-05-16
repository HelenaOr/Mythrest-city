using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour {
	List<Soil> soil;
	Camera camera;
	PlayerStamina playerStamina;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		playerStamina = GetComponent<PlayerStamina> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void cutWeed ()
	{


		GameObject cropsHandler = GameObject.FindGameObjectWithTag ("CropHandler"); 
		CropBehaviour[] crops = cropsHandler.GetComponentsInChildren<CropBehaviour> ();


		CreateSoil sl = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		soil = sl.allSquares;

		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "crop") {
				for (int i = 0; i < crops.Length; i++) {
					Debug.Log (Vector3.Distance (this.transform.position, crops [i].transform.position));

					if (Vector3.Distance (this.transform.position, crops [i].transform.position) < 6 && hit.transform.Equals(crops[i].transform)) {

						foreach (Soil s in soil) {
							if (s.getSoil ().transform.position.x == crops [i].transform.position.x && s.getSoil ().transform.position.z == crops [i].transform.position.z) {
								if (s.getType ().Equals (Soil.SoilTypes.PLANTED)) {
									s.soilType = Soil.SoilTypes.PLOWED;
								}
								if (s.getType ().Equals (Soil.SoilTypes.WATEREDANDPLATED)) {
									s.soilType = Soil.SoilTypes.WATERED;
								}
							}
						}
						playerStamina.loseStamina (5);
						Destroy (crops [i].transform.gameObject);
						break;
					}
				}
			}
		}



	}
}
