using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CropBehaviour : MonoBehaviour
{

	TimeManager timeManager;
	public MockCropDB crops;

	CreateSoil soil;
	public List<Soil> allS;

	public Material dryCrop;
	public Material[] M_ST1;
	public Material[] M_ST2;
	public Material[] M_HARVEST;

	public MeshFilter MF_ST1;
	public MeshFilter MF_ST2;
	public MeshFilter MF_HARVEST;


	public Crops.cropStates state;
	public bool dry;
	public bool watered;

	public string cropName;
	public string cropDescription;
	public int dayPlanted;
	public int dayToS1;
	public int dayToS2;
	public int dayToHarvest;
	public string season;
	public int staminaRecovery;
	public int code;
	public int price;
	public CropCollision collision;
	// Use this for initialization
	void Start ()
	{

		soil = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		allS = soil.allSquares;
		crops = FindObjectOfType<MockCropDB> ();
		timeManager = FindObjectOfType<TimeManager> ();
		dayPlanted = (int)timeManager.getDay ();
		state = Crops.cropStates.SEED;

		dryCrop = Resources.Load<Material> ("Materials/mockcrops/Dry");
		this.gameObject.transform.Rotate (-90, 0, 0);

		if (this.gameObject.name.Contains ("turnipseeds")) {
			cropName = crops.turnip.getName ();
			staminaRecovery = crops.turnip.staminaRecovery;
			cropDescription = crops.turnip.getDescription ();
			dayToS1 = dayPlanted + crops.turnip.getS1Days ();
			dayToS2 = dayToS1 + crops.turnip.getS2Days ();
			dayToHarvest = dayToS2 + crops.turnip.getHarvestDays ();
			season = crops.turnip.getSeason ();
			code = crops.turnip.code;
			price = crops.turnip.price;
		}else if (this.gameObject.name.Contains ("cabbageseeds")) {
			cropName = crops.cabbage.getName ();
			staminaRecovery = crops.cabbage.staminaRecovery;
			cropDescription = crops.cabbage.getDescription ();
			dayToS1 = dayPlanted + crops.cabbage.getS1Days ();
			dayToS2 = dayToS1 + crops.cabbage.getS2Days ();
			dayToHarvest = dayToS2 + crops.cabbage.getHarvestDays ();
			season = crops.cabbage.getSeason ();
			code = crops.cabbage.code;
			price = crops.cabbage.price;
		}
		else if (this.gameObject.name.Contains ("carrotseeds")) {
			cropName = crops.carrot.getName ();
			staminaRecovery = crops.carrot.staminaRecovery;
			cropDescription = crops.carrot.getDescription ();
			dayToS1 = dayPlanted + crops.carrot.getS1Days ();
			dayToS2 = dayToS1 + crops.carrot.getS2Days ();
			dayToHarvest = dayToS2 + crops.carrot.getHarvestDays ();
			season = crops.carrot.getSeason ();
			code = crops.carrot.code;
			price = crops.carrot.price;
		}else if (this.gameObject.name.Contains ("onionseeds")) {
			cropName = crops.onion.getName ();
			staminaRecovery = crops.onion.staminaRecovery;
			cropDescription = crops.onion.getDescription ();
			dayToS1 = dayPlanted + crops.onion.getS1Days ();
			dayToS2 = dayToS1 + crops.onion.getS2Days ();
			dayToHarvest = dayToS2 + crops.onion.getHarvestDays ();
			season = crops.onion.getSeason ();
			code = crops.onion.code;
			price = crops.onion.price;
		}else if (this.gameObject.name.Equals ("radishseeds(Clone)")) {
			cropName = crops.radish.getName ();
			staminaRecovery = crops.radish.staminaRecovery;
			cropDescription = crops.radish.getDescription ();
			dayToS1 = dayPlanted + crops.radish.getS1Days ();
			dayToS2 = dayToS1 + crops.radish.getS2Days ();
			dayToHarvest = dayToS2 + crops.radish.getHarvestDays ();
			season = crops.radish.getSeason ();
			code = crops.radish.code;
			price = crops.radish.price;
		}else if (this.gameObject.name.Contains ("spinachseeds")) {
			cropName = crops.spinach.getName ();
			staminaRecovery = crops.spinach.staminaRecovery;
			cropDescription = crops.spinach.getDescription ();
			dayToS1 = dayPlanted + crops.spinach.getS1Days ();
			dayToS2 = dayToS1 + crops.spinach.getS2Days ();
			dayToHarvest = dayToS2 + crops.spinach.getHarvestDays ();
			season = crops.spinach.getSeason ();
			code = crops.spinach.code;
			price = crops.spinach.price;
		}else if (this.gameObject.name.Contains ("daikon radishseeds")) {
			cropName = crops.daikonRadish.getName ();
			staminaRecovery = crops.daikonRadish.staminaRecovery;
			cropDescription = crops.daikonRadish.getDescription ();
			dayToS1 = dayPlanted + crops.daikonRadish.getS1Days ();
			dayToS2 = dayToS1 + crops.daikonRadish.getS2Days ();
			dayToHarvest = dayToS2 + crops.daikonRadish.getHarvestDays ();
			season = crops.daikonRadish.getSeason ();
			code = crops.daikonRadish.code;
			price = crops.daikonRadish.price;
		}else if (this.gameObject.name.Contains ("broccoliseeds")) {
			cropName = crops.broccoli.getName ();
			staminaRecovery = crops.broccoli.staminaRecovery;
			cropDescription = crops.broccoli.getDescription ();
			dayToS1 = dayPlanted + crops.broccoli.getS1Days ();
			dayToS2 = dayToS1 + crops.broccoli.getS2Days ();
			dayToHarvest = dayToS2 + crops.broccoli.getHarvestDays ();
			season = crops.broccoli.getSeason ();
			code = crops.broccoli.code;
			price = crops.broccoli.price;
		}

		M_ST1 = Resources.Load<Renderer> ("Crops/" + cropName + "/" + cropName + "ST1").sharedMaterials;
		M_ST2 = Resources.Load<Renderer> ("Crops/" + cropName + "/" + cropName + "ST2").sharedMaterials;
		M_HARVEST = Resources.Load<Renderer> ("Crops/" + cropName + "/" + cropName + "ST3").sharedMaterials;

		MF_ST1 = Resources.Load<MeshFilter> ("Crops/" + cropName+ "/" + cropName + "ST1");
		MF_ST2 = Resources.Load<MeshFilter> ("Crops/" + cropName+ "/" + cropName + "ST2");
		MF_HARVEST = Resources.Load<MeshFilter> ("Crops/" + cropName+ "/" + cropName + "ST3");

	}

	// Update is called once per frame
	void Update ()
	{
		if (dry) {
			this.gameObject.GetComponent<Renderer> ().material = dryCrop;
		}
		isWattered ();

	}

	public void growing ()
	{



		if (season.Equals (timeManager.getSeason ().ToString ())) {
			if (timeManager.getDay () >= dayToS1) {
				state = Crops.cropStates.ST1;
				this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_ST1;
				this.GetComponent<MeshFilter> ().sharedMesh = MF_ST1.sharedMesh;

			}
			if (timeManager.getDay () >= dayToS2) {
				this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_ST2;
				state = Crops.cropStates.ST2;
				this.GetComponent<MeshFilter> ().sharedMesh = MF_ST2.sharedMesh;
			}
			if (timeManager.getDay () >= dayToHarvest) {
				state = Crops.cropStates.HARVEST;
				this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_HARVEST;
				this.GetComponent<MeshFilter> ().sharedMesh = MF_HARVEST.sharedMesh;
				collision = this.gameObject.AddComponent (typeof(CropCollision)) as CropCollision;
			}

		} else {
			this.gameObject.GetComponent<Renderer> ().material = dryCrop;
		}


	}

	public bool isWattered ()
	{
		foreach (Soil s in allS) {


			if (((s.getSoil ().transform.position.x) == this.transform.position.x && (s.getSoil ().transform.position.z) == this.transform.position.z) &&
			    (s.getType ().Equals (Soil.SoilTypes.WATERED) || s.getType ().Equals (Soil.SoilTypes.WATEREDANDPLATED))) {
				 
				setWatered (true);
				break;
			} else {
				setWatered (false);
			}

		}

		return watered;
	}

	public void setWatered (bool watered)
	{
		
		this.watered = watered;
	}

	public string getCropName(){
		return cropName;
	}
}
