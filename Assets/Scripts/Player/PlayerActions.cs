using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
	public Rigidbody player;

	public bool outside;

	public Hoe hoe;
	public PlantSeeds plant;
	public WateringCan wateringCan;
	public Sickle sickle;
	public None none;
	public HoldingItem holdingItem;

	Camera camera;

	public GameObject toolPanel;

	ToolManager toolManager;

	public enum Tools
	{
		NONE,
		HOE,
		WATERINGCAN,
		SICKLE,
		SEEDS}

	;

	public enum Seeds
	{
		NONE,
		TURNIP,
		CABBAGE,
		ONION,
		RADISH,
		CARROT,
		SPINACH,
		DAIKONRADISH,
		BROCCOLI,
		CHERRYTREE,
		PEACHTREE,
		APPLETREE,
		ORANGETREE}

	;

	public Tools tool;
	public Seeds seed;

	//public Transform plow;
	public Transform watered;

	public Material plowM;
	public Material watterM;
	//CreateSoil s;
	List<Soil> soil;

	public Transform seedsParent;
	Transform seeds;

	public Canvas ToolCanvas;
	public Canvas InventoryView;
	public InventoryManager inventory;

	PlayerStamina playerStamina;
	public FountainCollider fountainCollision;
	PlayerFriendship playerFrienship;
	public NPCCollision NPCCollision;
	Animator anim;
	GameObject hoeGO;
	GameObject wcanGO;
	GameObject sickleGO;
	public bool doingAction;
	ButtonToPress buttonToPress;
	// Use this for initialization
	void Start ()
	{

		playerStamina = GetComponent<PlayerStamina> ();

		camera = Camera.main;
		tool = Tools.NONE;

		hoe = GetComponent<Hoe> ();
		plant = GetComponent<PlantSeeds> ();
		wateringCan = GetComponent<WateringCan> ();
		sickle = GetComponent<Sickle> ();
		none = GetComponent<None> ();
		holdingItem = GetComponent<HoldingItem> ();
		inventory = GetComponent<InventoryManager> ();
		fountainCollision = GetComponent<FountainCollider> ();
		NPCCollision = GetComponent<NPCCollision> ();
		if (SceneManager.GetActiveScene ().name.Contains ("Outside") || SceneManager.GetActiveScene ().name == "Farming" || SceneManager.GetActiveScene ().name == "Farm") {
			outside = true;

		} else {
			outside = false;
		}

		anim = GetComponent<Animator> ();
		hoeGO = this.transform.Find ("hoe").gameObject;
		wcanGO = this.transform.Find ("wateringcan").gameObject;
		sickleGO = this.transform.Find ("sickle").gameObject;
		buttonToPress = FindObjectOfType (typeof(ButtonToPress)) as ButtonToPress;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (holdingItem.holdingItem) {

			if (NPCCollision.collision == true ) {
				if(Input.GetKey (KeyCode.E)){
					NPCCollision.NPC.GetComponent<NPCBehaviour> ().Talk (holdingItem.itemCode);
					if (!NPCCollision.NPC.GetComponent<NPCBehaviour> ().alreadygifted) {
						anim.SetBool ("isHolding", false);
						holdingItem.Gift (holdingItem.itemCode);
					}



				}

			}
			if (NPCCollision.collision == true && NPCCollision.NPC.GetComponent<NPCBehaviour> ().talking) {
				if (Input.GetMouseButtonDown (0)) {
					NPCCollision.NPC.GetComponent<NPCBehaviour> ().closeDialog ();
				}

			}
			if (Input.GetKey (KeyCode.X)) {
				buttonToPress.hidePanel ();
				anim.SetBool ("isHolding", false);
				holdingItem.saveItem ();


			}

		}
		if (!holdingItem.holdingItem) {
			if (!this.GetComponent<Animator> ().GetBool ("isPlowing") && !this.GetComponent<Animator> ().GetBool ("isRecollecting")  && !this.GetComponent<Animator> ().GetBool ("isPlanting")) {
				if (Input.GetKey (KeyCode.F)) {
					Time.timeScale = 0.0f;
					ToolCanvas.gameObject.SetActive (true);
				} if (Input.GetKey (KeyCode.I)) {
					InventoryView.gameObject.SetActive (true);
					Time.timeScale = 0.0f;

				} 
			}
			if (tool.Equals (Tools.NONE)) {
				if (Input.GetMouseButtonDown (1)) {
					anim.SetBool ("isRecollecting", true);
					StartCoroutine (waitForEndOfAnimGrab ());
				}
					
					
			} if (tool.Equals (Tools.HOE)) {
				if (Input.GetMouseButtonDown (1)) {

					hoeGO.SetActive (true);
					hoeGO.GetComponent<Animator> ().SetBool ("isPlowing", true);
					anim.SetBool ("isPlowing", true);
					StartCoroutine (waitForEndOfAnimPlow ());
				}
					
			} if (tool.Equals (Tools.SICKLE)) {
				if (Input.GetMouseButtonDown (1)) {
					sickleGO.SetActive (true);
					sickleGO.GetComponent<Animator> ().SetBool ("isCutting", true);
					anim.SetBool ("isCutting", true);
					StartCoroutine (waitForEndOfAnimSickle ());
				}
					
			} if (tool.Equals (Tools.SEEDS)) {
				if (Input.GetMouseButtonDown (1)) {
					anim.SetBool ("isPlanting",true);
					StartCoroutine (waitForEndOfAnimPlant ());
				}
					
			} if (tool.Equals (Tools.WATERINGCAN)) {
				if (Input.GetMouseButtonDown (1)) {
					wcanGO.SetActive (true);
					wcanGO.GetComponent<Animator> ().SetBool ("isWatering", true);
					anim.SetBool ("isWatering", true);
					StartCoroutine (waitForEndOfAnimWater ());
				}
					
			}if (fountainCollision.collision == true) {
				if (Input.GetKey (KeyCode.E)) {
					wcanGO.SetActive (true);
					wcanGO.GetComponent<Animator> ().SetBool ("isWatering", true);
					anim.SetBool ("isWatering", true);
					StartCoroutine (waitForEndOfAnimChargeWCan ());

				}

			} if (NPCCollision.collision == true && !NPCCollision.NPC.GetComponent<NPCBehaviour> ().talking) {
				if (Input.GetKey (KeyCode.E)) {
					NPCCollision.NPC.GetComponent<NPCBehaviour> ().Talk (-1);


				}

			}
			if (NPCCollision.collision == true && NPCCollision.NPC.GetComponent<NPCBehaviour> ().talking) {
				if (Input.GetMouseButtonDown (0)) {
					NPCCollision.NPC.GetComponent<NPCBehaviour> ().closeDialog ();
				}

			}
		}

			

	}
		
	IEnumerator waitForEndOfAnimPlow(){
		yield return new WaitForSeconds (1.1f);
		hoe.plowSoil ();
		hoeGO.GetComponent<Animator> ().SetBool ("isPlowing", false);
		anim.SetBool ("isPlowing", false);
		hoeGO.SetActive (false);


	
	}

	IEnumerator waitForEndOfAnimWater(){
		yield return new WaitForSeconds (1.5f);
		wateringCan.waterSoil ();
		wcanGO.GetComponent<Animator> ().SetBool ("isWatering", false);
		anim.SetBool ("isWatering", false);
		wcanGO.SetActive (false);

	}

	IEnumerator waitForEndOfAnimChargeWCan(){
		yield return new WaitForSeconds (1.5f);
		wateringCan.chargeWatteringCan ();
		wcanGO.GetComponent<Animator> ().SetBool ("isWatering", false);
		anim.SetBool ("isWatering", false);
		wcanGO.SetActive (false);

	}

	IEnumerator waitForEndOfAnimSickle(){
		yield return new WaitForSeconds (1.2f);
		sickle.cutWeed ();
		sickleGO.GetComponent<Animator> ().SetBool ("isCutting", false);
		anim.SetBool ("isCutting", false);
		sickleGO.SetActive (false);

	}

	IEnumerator waitForEndOfAnimGrab(){
		yield return new WaitForSeconds (1.5f);
		none.recollect ();
		anim.SetBool ("isRecollecting", false);
	}
	IEnumerator waitForEndOfAnimPlant(){
		yield return new WaitForSeconds (1f);
		plant.plantSeeds ();
		anim.SetBool ("isPlanting", false);
	}
}
