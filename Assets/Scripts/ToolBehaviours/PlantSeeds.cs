using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlantSeeds : MonoBehaviour {
	PlayerActions playerActions;
	PlayerStamina playerStamina;
	Animator playerAnimator;
	Transform seeds;

	List<Soil> soil;
	Camera camera;

	public Canvas ToolCanvas;
	public InventoryManager inventory;

	public Transform seedsParent;
	public Transform tseeds;
	public Transform cabseeds;
	public Transform cseeds;
	public Transform onseeds;
	public Transform radseeds;
	public Transform spiseeds;
	public Transform dairadseeds;
	public Transform brocseeds;

	public Transform chertreeseeds;
	public Transform petreeseeds;
	public Transform aptreeseeds;
	public Transform ortreeseeds;

	int seedsCode;
	// Use this for initialization
	void Start () {
		camera = Camera.main;

		playerActions = GetComponent<PlayerActions> ();
		playerStamina = GetComponent<PlayerStamina> ();
		playerAnimator = GetComponent<Animator> ();
		 

		///Resources///
		tseeds = Resources.Load<Transform>("Crops/turnip/turnipseeds");
		cabseeds = Resources.Load<Transform> ("Crops/cabbage/cabbageseeds");
		cseeds = Resources.Load<Transform> ("Crops/carrot/carrotseeds");
		onseeds = Resources.Load<Transform> ("Crops/onion/onionseeds");
		radseeds = Resources.Load<Transform> ("Crops/radish/radishseeds");
		spiseeds = Resources.Load<Transform> ("Crops/spinach/spinachseeds");
		dairadseeds = Resources.Load<Transform> ("Crops/daikon radish/daikon radishseeds");
		brocseeds = Resources.Load<Transform> ("Crops/broccoli/broccoliseeds");

		chertreeseeds = Resources.Load<Transform>("Trees/cherryTree/cherryseeds");
		petreeseeds = Resources.Load<Transform>("Trees/peachTree/peachseeds");
		aptreeseeds = Resources.Load<Transform>("Trees/appleTree/appleseeds");
		ortreeseeds = Resources.Load<Transform>("Trees/orangeTree/orangeseeds");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void typeOfSeeds ()
	{

		if (playerActions.seed == PlayerActions.Seeds.TURNIP) {
			seeds = tseeds;
			seedsCode = 8;
		} else if (playerActions.seed == PlayerActions.Seeds.CABBAGE) {
			seeds = cabseeds;
			seedsCode = 9;
		}else if (playerActions.seed == PlayerActions.Seeds.CARROT) {
			seeds = cseeds;
			seedsCode = 10;
		}else if (playerActions.seed == PlayerActions.Seeds.ONION) {
			seeds = onseeds;
			seedsCode = 11;
		} else if (playerActions.seed == PlayerActions.Seeds.RADISH) {
			seeds = radseeds;
			seedsCode = 12;
		} else if (playerActions.seed == PlayerActions.Seeds.SPINACH) {
			seeds = spiseeds;
			seedsCode = 13;
		}    else if (playerActions.seed == PlayerActions.Seeds.DAIKONRADISH) {
			seeds = dairadseeds;
			seedsCode = 14;
		}   else if (playerActions.seed == PlayerActions.Seeds.BROCCOLI) {
			seeds = brocseeds;
			seedsCode = 15;
		}  else if (playerActions.seed == PlayerActions.Seeds.CHERRYTREE) {
			seeds = chertreeseeds;
			seedsCode =36;
		}   else if (playerActions.seed == PlayerActions.Seeds.PEACHTREE) {
			seeds = petreeseeds;
			seedsCode = 37;
		}   else if (playerActions.seed == PlayerActions.Seeds.APPLETREE) {
			seeds = aptreeseeds;
			seedsCode = 38;
		}   else if (playerActions.seed == PlayerActions.Seeds.ORANGETREE) {
			seeds = ortreeseeds;
			seedsCode = 39;
		}  
	}

	public void removeSeedsButton(){
		Button[] buttons = ToolCanvas.GetComponentInChildren<ScrollRect> ().content.GetComponentsInChildren<Button> ();
		foreach (Button b in buttons) {
			if (int.Parse(b.tag) == seedsCode) {
				if (inventory.getItem (int.Parse(b.tag)).quantity <= 1) {
					Debug.Log ("Remove" + b.tag.ToString ());
					Debug.Log (playerActions.seed.ToString ());
					inventory.removeItem (int.Parse(b.tag));
					Destroy (b.gameObject);

					playerActions.tool = PlayerActions.Tools.NONE;
					playerActions.seed = PlayerActions.Seeds.NONE;
				} else {
					inventory.getItem (int.Parse(b.tag)).quantity -= 1;
				}


			}
		}
	}

	public void plantSeeds ()
	{

		typeOfSeeds ();
		CreateSoil sl = FindObjectOfType (typeof(CreateSoil)) as CreateSoil;
		soil=sl.allSquares;
		for (int i = 0; i < soil.Count; i++) {
			if (soil [i].getSoil ().GetComponent<SoilCollision> ().collision == true && (soil [i].getType ().Equals (Soil.SoilTypes.PLOWED) ||
				soil [i].getType ().Equals (Soil.SoilTypes.WATERED))) {
				Ray ray = camera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {

					if (soil [i].getSoil ().transform.gameObject.Equals (hit.transform.gameObject)) {
						removeSeedsButton ();
						playerStamina.loseStamina (5);
						Transform s = Instantiate (seeds.transform, new Vector3 ((soil [i].getSoil ().transform.position.x), 0f, soil [i].getSoil ().transform.position.z), soil [i].getSoil ().transform.rotation) as Transform;
						s.SetParent (seedsParent);
						if (soil [i].getType () == Soil.SoilTypes.WATERED) {
							soil [i].soilType = Soil.SoilTypes.WATEREDANDPLATED;
						} else {
							soil [i].soilType = Soil.SoilTypes.PLANTED;
						}
						break;

					}


				}
			}

		}
	}

}
