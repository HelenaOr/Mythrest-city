using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToolManager : MonoBehaviour
{


	public Button hoe;
	public Button none;
	public Button wcan;
	public Button sickle;

	public Button exit;

	public PlayerActions player;
	public InventoryManager inventoryManager;
	public Button[] newButtons;

	// Use this for initialization
	void Start ()
	{


		hoe.onClick.AddListener (EquipHoe);
		wcan.onClick.AddListener (EquipWCan);
		sickle.onClick.AddListener (EquipSickle);
		none.onClick.AddListener (EquipNone);
		exit.onClick.AddListener (Exit);


	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnEnable ()
	{
		newButtons = this.GetComponentsInChildren<Button> ();
		foreach (Button b in newButtons) {


			if (b.tag == "8") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipTurnipSeeds);
			}
			if (b.tag == "9") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipCabbageSeeds);
			}

			if (b.tag == "10") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipCarrotSeeds);
			}

			if (b.tag == "11") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipOnionSeeds);
			} 

			if (b.tag == "12") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipRadishSeeds);
			} 

			if (b.tag == "13") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipSpinachSeeds);
			}if (b.tag == "14") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipDaikonRadishSeeds);
			}if (b.tag == "15") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipBroccoliSeeds);
			}
			if (b.tag == "36") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipCherryTreeSeeds);
			}
			if (b.tag == "37") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipPeachTreeSeeds);
			}
			if (b.tag == "38") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipAppleTreeSeeds);
			}
			if (b.tag == "39") {
				b.transform.localScale = new Vector3 (1, 1, 1);
				b.onClick.AddListener (EquipOrangeTreeSeeds);
			}


		
		}
	}




	public void EquipHoe ()
	{
		
		player.tool = PlayerActions.Tools.HOE;
		player.seed = PlayerActions.Seeds.NONE;
		Exit ();
	}

	public void EquipWCan ()
	{
		player.tool = PlayerActions.Tools.WATERINGCAN;
		player.seed = PlayerActions.Seeds.NONE;
		Exit ();

	}

	public void EquipSickle ()
	{
		player.tool = PlayerActions.Tools.SICKLE;
		player.seed = PlayerActions.Seeds.NONE;
		Exit ();

	}

	public void EquipNone ()
	{
		player.tool = PlayerActions.Tools.NONE;
		player.seed = PlayerActions.Seeds.NONE;
		Exit ();

	}

	public void EquipTurnipSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.TURNIP;
		Exit ();

	}

	public void EquipCabbageSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.CABBAGE;
		Exit ();
	}

	public void EquipCarrotSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.CARROT;
		Exit ();
	}

	public void EquipOnionSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.ONION;
		Exit ();
	}

	public void EquipRadishSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.RADISH;
		Exit ();
	}

	public void EquipSpinachSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.SPINACH;
		Exit ();
	}
	public void EquipDaikonRadishSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.DAIKONRADISH;
		Exit ();
	}
	public void EquipBroccoliSeeds ()
	{
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.BROCCOLI;
		Exit ();
	}
	public void EquipCherryTreeSeeds(){
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.CHERRYTREE;
		Exit ();
	}
	public void EquipPeachTreeSeeds(){
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.PEACHTREE;
		Exit ();
	}
	public void EquipAppleTreeSeeds(){
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.APPLETREE;
		Exit ();
	}
	public void EquipOrangeTreeSeeds(){
		player.tool = PlayerActions.Tools.SEEDS;
		player.seed = PlayerActions.Seeds.ORANGETREE;
		Exit ();
	}
	public void Exit ()
	{
		Time.timeScale = 1.0f;
		this.GetComponentInParent<Canvas> ().gameObject.SetActive (false);

	}

}
