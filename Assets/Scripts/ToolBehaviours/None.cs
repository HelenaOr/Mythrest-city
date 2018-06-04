using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class None : MonoBehaviour {

	Camera camera;
	List<Soil> soil;
	InventoryManager inventory;
	GameObject player;
	public TreeBehaviour[] tree ;
	ButtonToPress buttonToPress;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		inventory = GetComponent<InventoryManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void recollect ()
	{
		GameObject cropsHandler = GameObject.FindGameObjectWithTag ("CropHandler"); 
		CropBehaviour[] crops = cropsHandler.GetComponentsInChildren<CropBehaviour> ();
		 tree = cropsHandler.GetComponentsInChildren<TreeBehaviour> ();

		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		CreateSoil sl = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		soil = sl.allSquares;

		MockCropDB cropDB = FindObjectOfType<MockCropDB> ();

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == "crop") {
				for (int i = 0; i < crops.Length; i++) {
					if (crops [i].GetComponent<CropCollision> () != null) {
						if (crops [i].GetComponent<CropCollision> ().collision == true && hit.transform.Equals (crops [i].transform)) {

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

							buttonToPress.hidePanel ();
							Destroy (crops [i].transform.gameObject);
							InventoryItem item = new InventoryItem (crops [i].cropName, crops [i].cropDescription, crops [i].staminaRecovery,crops[i].price, crops[i].code, InventoryItem.inventoryTypes.EDIBLE);
							inventory.addItem (item, 9);

							break;
						}
					}


				}
			} else if (hit.transform.tag == "SpawnItem") {
				Debug.Log (Vector3.Distance (hit.transform.position, player.transform.position) < 10);
				string name = hit.transform.name.Replace ("(Clone)", "");
				if (Vector3.Distance (hit.transform.position, player.transform.position) < 10) {
					if (hit.transform.name.Contains ("Branch")) {
						InventoryItem item = new InventoryItem (name, "A branch, nothing more, nothing less.", 0, 1, 20, InventoryItem.inventoryTypes.NOTEDIBLE);
						inventory.addItem (item, 1);
						Destroy (hit.transform.gameObject);
					} else if (hit.transform.name.Contains ("Apricot")) {
						InventoryItem item = new InventoryItem (name, "Wild item which you can eat or sell. Only found in spring.", 3, 20, 16, InventoryItem.inventoryTypes.EDIBLE);
						inventory.addItem (item, 1);
						Destroy (hit.transform.gameObject);

					}else if (hit.transform.name.Contains ("Plum")) {
						InventoryItem item = new InventoryItem (name, "Wild item which you can eat or sell. Only found in summer.", 3, 20, 16, InventoryItem.inventoryTypes.EDIBLE);
						inventory.addItem (item, 1);
						Destroy (hit.transform.gameObject);

					}else if (hit.transform.name.Contains ("Black")) {
						InventoryItem item = new InventoryItem (name, "Wild item which you can eat or sell. Only found in fall.", 3, 20, 16, InventoryItem.inventoryTypes.EDIBLE);
						inventory.addItem (item, 1);
						Destroy (hit.transform.gameObject);

					}else if (hit.transform.name.Contains ("Goji")) {
						InventoryItem item = new InventoryItem (name, "Wild item which you can eat or sell. Only found in winter", 3, 20, 16, InventoryItem.inventoryTypes.EDIBLE);
						inventory.addItem (item, 1);
						Destroy (hit.transform.gameObject);

					}

				}
			} else if (hit.transform.tag == "tree") {

				for (int j = 0; j < tree.Length; j++) {
					if (tree [j].GetComponent<TreeCollision> () != null) {
						if (tree [j].GetComponent<TreeCollision> ().collision == true && hit.transform.Equals (tree [j].transform)) {
							tree [j].daysToNextStage = tree [j].dayToHarvest;
							tree[j].gameObject.GetComponent<Renderer> ().sharedMaterials = tree[j].M_ST2;
							tree[j].GetComponent<MeshFilter> ().sharedMesh = tree[j].MF_ST2.sharedMesh;

							InventoryItem fruit = new InventoryItem (tree [j].treeName, tree [j].treeDescription, tree [j].staminaRecovery, tree [j].price, tree [j].code, InventoryItem.inventoryTypes.EDIBLE);
							inventory.addItem (fruit, 3);
							break;
						}
					}

				}
			}
		}



	}

}
