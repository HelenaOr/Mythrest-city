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

		for (int i = 0; i < soil.Count; i++) {
			if (soil [i].getSoil ().GetComponent<SoilCollision> ().collision == true &&
				(soil [i].getType ().Equals (Soil.SoilTypes.PLOWED) || soil [i].getType ().Equals (Soil.SoilTypes.PLANTED))) {
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {

					if ((hit.transform.tag == "crop"
						&& (hit.transform.position.x == soil [i].getSoil ().transform.position.x && hit.transform.position.z == soil [i].getSoil ().transform.position.z))) {

						if (soil [i].getType () == Soil.SoilTypes.PLANTED) {

							soil [i].soilType = Soil.SoilTypes.PLOWED;

						} if(soil [i].getType () == Soil.SoilTypes.WATEREDANDPLATED){
							soil [i].soilType = Soil.SoilTypes.PLOWED;
						}
						Destroy (crops [i].gameObject);
						playerStamina.loseStamina (5);
						break;

					}


				}
			}
		}



	}
}
