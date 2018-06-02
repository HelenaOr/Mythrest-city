using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour {
	List<Soil> soil;
	Camera camera;
	PlayerStamina playerStamina;
	public Material plowM;
	public Material waterM;
	TimeManager timeManager;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		playerStamina = GetComponent<PlayerStamina> ();
		timeManager = FindObjectOfType (typeof(TimeManager)) as TimeManager;

	}


	//In this function a ray cast is thrown to check if we can plow the soil square
	//if we can, the soil will be plowed and its state will change

	public void plowSoil ()
	{

		CreateSoil s = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		soil = s.allSquares;
		for (int i = 0; i < soil.Count; i++) {

			if (soil [i].getSoil ().GetComponent<SoilCollision> ().collision == true && soil [i].getType ().Equals (Soil.SoilTypes.NOTPLOWED)) {

				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {

					if (soil [i].getSoil ().transform.gameObject.Equals (hit.transform.gameObject)) {

						Debug.Log ("Boom");
						playerStamina.loseStamina (5);
						StartCoroutine (waitForTextureChange (i));

					}
				}

			}
		}

	}

	IEnumerator waitForTextureChange(int i){
		yield return new WaitForSeconds (1.1f);
		if (timeManager.getWeather ().Equals (TimeManager.weather.RAIN) || timeManager.getWeather ().Equals (TimeManager.weather.RAINSTORM)) {
			soil [i].soilType = Soil.SoilTypes.WATERED;
			soil [i].getSoil ().GetComponent<Renderer> ().material = waterM;
		} else {
			soil [i].soilType = Soil.SoilTypes.PLOWED;
			soil [i].getSoil ().GetComponent<Renderer> ().material = plowM;
		}
	}
}
