using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crops{

	public string name;
	public string description;
	public int daysToStage1; 
	public int daysToStage2; 
	public int daysToHarvest;
	public int price;
	public int code;
	public string season;
	public int staminaRecovery;
	public enum cropStates {SEED, ST1, ST2, HARVEST};
	public cropStates state;

	public Crops(string name, string description,int staminaRecovery, int daysToStage1, int daysToStage2, int daysToHarvest,int price,int code,string season){
		this.name = name;
		this.staminaRecovery = staminaRecovery;
		this.description = description;
		this.daysToStage1 = daysToStage1;
		this.daysToStage2 = daysToStage2;
		this.daysToHarvest = daysToHarvest;
		this.price = price;
		this.code = code;
		this.season = season;
	}
	public int getS1Days(){
		return daysToStage1;
	}
	public int getS2Days(){
		return daysToStage2;
	}
	public int getHarvestDays (){
		return daysToHarvest;
	}

	public int getPrice(){
		return price;
	}

	public int getCode(){
		return code;
	}

	public string getName(){
		return name;
	}

	public string getDescription(){
		return description;
	}
	public string getSeason(){
		return season;
	}
}
