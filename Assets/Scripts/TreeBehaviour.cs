using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour {


	TimeManager timeManager;
	public MockCropDB crops;

	CreateSoil soil;
	public List<Soil> allS;

	public Material[] M_ST1;
	public Material[] M_ST2;
	public Material[] M_HARVEST;

	public MeshFilter MF_ST1;
	public MeshFilter MF_ST2;
	public MeshFilter MF_HARVEST;


	public Crops.cropStates state;

	public string treeName;
	public string treeDescription;
	public int daysToNextStage;
	public int dayToS1;
	public int dayToS2;
	public int dayToHarvest;
	public string season;
	public int staminaRecovery;
	public int code;
	public int price;
	public TreeCollision collision;
	MeshCollider col;
	// Use this for initialization
	void Start () {
		soil = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		allS = soil.allSquares;
		crops = FindObjectOfType<MockCropDB> ();
		timeManager = FindObjectOfType<TimeManager> ();
		state = Crops.cropStates.SEED;
		col = this.gameObject.AddComponent (typeof(MeshCollider)) as MeshCollider;
		col.convex = true;
		if (this.gameObject.name.Contains ("cherryseeds")) {

			treeName = crops.cherry.name;
			treeDescription = crops.cherry.description;
			daysToNextStage = crops.cherry.daysToStage1;
			dayToS1 = crops.cherry.daysToStage1;
			dayToS2 = crops.cherry.daysToStage2;
			dayToHarvest = crops.cherry.daysToHarvest;
			season = crops.cherry.season;
			staminaRecovery = crops.cherry.staminaRecovery;
			code = crops.cherry.code;
			price = crops.cherry.price;

		}else if (this.gameObject.name.Contains ("peachseeds")) {

			treeName = crops.peach.name;
			treeDescription = crops.peach.description;
			daysToNextStage = crops.peach.daysToStage1;
			dayToS1 = crops.peach.daysToStage1;
			dayToS2 = crops.peach.daysToStage2;
			dayToHarvest = crops.peach.daysToHarvest;
			season = crops.peach.season;
			staminaRecovery = crops.peach.staminaRecovery;
			code = crops.peach.code;
			price = crops.peach.price;
		}else if (this.gameObject.name.Contains ("appleseeds")) {

			treeName = crops.apple.name;
			treeDescription = crops.apple.description;
			daysToNextStage = crops.apple.daysToStage1;
			dayToS1 = crops.apple.daysToStage1;
			dayToS2 = crops.apple.daysToStage2;
			dayToHarvest = crops.apple.daysToHarvest;
			season = crops.apple.season;
			staminaRecovery = crops.apple.staminaRecovery;
			code = crops.apple.code;
			price = crops.apple.price;
		}else if (this.gameObject.name.Contains ("orangeseeds")) {

			treeName = crops.orange.name;
			treeDescription = crops.orange.description;
			daysToNextStage = crops.orange.daysToStage1;
			dayToS1 = crops.orange.daysToStage1;
			dayToS2 = crops.orange.daysToStage2;
			dayToHarvest = crops.orange.daysToHarvest;
			season = crops.orange.season;
			staminaRecovery = crops.orange.staminaRecovery;
			code = crops.orange.code;
			price = crops.orange.price;
		}

		M_ST1 = Resources.Load<Renderer> ("Trees/" + treeName + "Tree/" + treeName + "ST1").sharedMaterials;
		M_ST2 = Resources.Load<Renderer> ("Trees/" + treeName + "Tree/" + treeName + "ST2").sharedMaterials;
		M_HARVEST = Resources.Load<Renderer> ("Trees/" + treeName + "Tree/" + treeName + "ST3").sharedMaterials;

		MF_ST1 = Resources.Load<MeshFilter> ("Trees/" + treeName+ "Tree/" + treeName + "ST1");
		MF_ST2 = Resources.Load<MeshFilter> ("Trees/" + treeName+ "Tree/" + treeName + "ST2");
		MF_HARVEST = Resources.Load<MeshFilter> ("Trees/" + treeName+ "Tree/" + treeName + "ST3");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void growingTree(){

		if (daysToNextStage < 0) {
			daysToNextStage = 0;
		}

		if (daysToNextStage <=0 && state.Equals(Crops.cropStates.SEED)) {
			daysToNextStage = dayToS2;
			state = Crops.cropStates.ST1;
			this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_ST1;
			this.GetComponent<MeshFilter> ().sharedMesh = MF_ST1.sharedMesh;
			col.sharedMesh =  MF_ST1.sharedMesh;
			col.convex = true;
		}else if (daysToNextStage <= 0 && state.Equals(Crops.cropStates.ST1)) {
			daysToNextStage = dayToHarvest;
			state = Crops.cropStates.ST2;
			this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_ST2;
			this.GetComponent<MeshFilter> ().sharedMesh = MF_ST2.sharedMesh;
			col.sharedMesh = MF_ST2.sharedMesh;
			col.convex = true;
		}else if (daysToNextStage <=0  && state.Equals(Crops.cropStates.ST2) && season.Equals(timeManager.getSeason().ToString())) {

			daysToNextStage = dayToHarvest;
			state = Crops.cropStates.HARVEST;
			this.gameObject.GetComponent<Renderer> ().sharedMaterials = M_HARVEST;
			this.GetComponent<MeshFilter> ().sharedMesh = MF_HARVEST.sharedMesh;
			col.sharedMesh = MF_HARVEST.sharedMesh;
			col.convex = true;
			collision = this.gameObject.AddComponent (typeof(TreeCollision)) as TreeCollision;

		}

	}
}
