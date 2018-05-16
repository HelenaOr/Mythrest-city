using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringCan : MonoBehaviour {
	List<Soil> soil;
	Camera camera;
	PlayerStamina playerStamina;
	public Material watterM;

	public static int totalCapacity = 10;
	public int currentCapacity;
	public GameObject warning;
	// Use this for initialization
	void Start () {
	
		camera = Camera.main;
		playerStamina = GetComponent<PlayerStamina> ();
		currentCapacity = totalCapacity;
		warning = GameObject.FindGameObjectWithTag ("warnings");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void waterSoil ()
	{


		GameObject cropsHandler = GameObject.FindGameObjectWithTag ("CropHandler"); 
		CropBehaviour[] crops = cropsHandler.GetComponentsInChildren<CropBehaviour> ();

		CreateSoil sl = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		soil=sl.allSquares;


		if (currentCapacity > 0) {
			currentCapacity -= 1;
			Debug.Log (currentCapacity);
			for (int i = 0; i < soil.Count; i++) {
				if (soil [i].getSoil ().GetComponent<SoilCollision> ().collision == true &&
				    (soil [i].getType ().Equals (Soil.SoilTypes.PLOWED) || soil [i].getType ().Equals (Soil.SoilTypes.PLANTED))) {
					Ray ray = camera.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit;

					if (Physics.Raycast (ray, out hit)) {

						if (soil [i].getSoil ().transform.gameObject.Equals (hit.transform.gameObject) || (hit.transform.tag == "crop"
						    && (hit.transform.position.x == soil [i].getSoil ().transform.position.x && hit.transform.position.z == soil [i].getSoil ().transform.position.z))) {

							if (soil [i].getType () == Soil.SoilTypes.PLANTED) {

								soil [i].soilType = Soil.SoilTypes.WATEREDANDPLATED;

							} else {
								soil [i].soilType = Soil.SoilTypes.WATERED;
							}

							Debug.Log ("Boom");
							playerStamina.loseStamina (5);
							soil [i].getSoil ().GetComponent<Renderer> ().material = watterM;
							break;

						}


					}
				}
			}
		} else {
			warning.transform.Find("Warnings").gameObject.SetActive (true);
			warning.GetComponentInChildren<Text>().text = "Watering can is empty";
			StartCoroutine (setPanelInactive ());
		}

	}

	IEnumerator setPanelInactive(){
		yield return new WaitForSeconds (2);
		warning.transform.Find("Warnings").gameObject.SetActive (false);

	}

	public void chargeWatteringCan(){
		currentCapacity = totalCapacity;
	}
}
