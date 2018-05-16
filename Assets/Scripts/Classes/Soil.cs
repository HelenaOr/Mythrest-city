using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Soil  {

	public enum SoilTypes {NOTPLOWED,PLOWED,WATERED,PLANTED,WATEREDANDPLATED};
	public SoilTypes soilType;
	public GameObject soil;


	public Soil(SoilTypes type, GameObject soil){
		this.soilType = type;
		this.soil = soil;
	}

	public SoilTypes getType(){
		return soilType;
	}
	public GameObject getSoil(){
		return soil;
	}

	public void setSoil(GameObject soil){
		this.soil = soil;
	}


	public void destroyOldSoil(){

		GameObject.Destroy (this.soil);

	}
}
