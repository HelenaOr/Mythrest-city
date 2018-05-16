using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEfectOnSoil : MonoBehaviour {

	CreateSoil soil;
	public ParticleSystem rain;
	Material watterM;
	// Use this for initialization
	void Start () {
	
		soil = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		watterM = Resources.Load<Material> ("Materials/Watered");
	}
	
	// Update is called once per frame
	void Update () {
		if (rain.gameObject.activeSelf) {
			waterAllSoil ();
		}
	}

	public void waterAllSoil(){
		List<Soil> allSoil = soil.allSquares;

		foreach (Soil s in allSoil) {
			if (s.soilType.Equals (Soil.SoilTypes.PLANTED)) {
				s.soilType = Soil.SoilTypes.WATEREDANDPLATED;
				s.getSoil ().GetComponent<Renderer> ().material = watterM;
			}
		}

	}
}
