using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolImage : MonoBehaviour {

	PlayerActions playerTool;
	public Image toolImage;

	public Sprite hoe;
	public Sprite springSeeds;
	public Sprite summerSeeds;
	public Sprite fallSeeds;
	public Sprite winterSeeds;
	public Sprite springTreeSeeds;
	public Sprite summerTreeSeeds;
	public Sprite fallTreeSeeds;
	public Sprite winterTreeSeeds;
	public Sprite sickle;
	public Sprite wateringcan;
	public Sprite none;

	// Use this for initialization
	void Start () {
		playerTool = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerActions> ();
		hoe = Resources.Load<Sprite> ("ToolImages/hoe image");
		sickle = Resources.Load<Sprite> ("ToolImages/sickle image");
		wateringcan = Resources.Load<Sprite>("ToolImages/watering can image");
		none = Resources.Load<Sprite> ("ToolImages/none image");
		springSeeds = Resources.Load<Sprite> ("ToolImages/springSeeds");
		summerSeeds = Resources.Load<Sprite> ("ToolImages/summerSeeds");
		fallSeeds = Resources.Load<Sprite> ("ToolImages/fallSeeds");
		winterSeeds = Resources.Load<Sprite> ("ToolImages/wintertreeSeeds");
		springTreeSeeds = Resources.Load<Sprite> ("ToolImages/springtreeSeeds");
		summerTreeSeeds = Resources.Load<Sprite> ("ToolImages/summertreeSeeds");
		fallTreeSeeds = Resources.Load<Sprite> ("ToolImages/falltreeSeeds");
		winterTreeSeeds = Resources.Load<Sprite> ("ToolImages/wintertreeSeeds");


	}
	
	// Update is called once per frame
	void Update () {
		changeImage ();
	}

	void changeImage(){
		if (playerTool.tool.Equals (PlayerActions.Tools.HOE)) {
			toolImage.sprite = hoe;
		} else if (playerTool.tool.Equals (PlayerActions.Tools.SICKLE)) {
			toolImage.sprite = sickle;
		} else if (playerTool.tool.Equals (PlayerActions.Tools.SEEDS)) {
			if (playerTool.seed.Equals (PlayerActions.Seeds.TURNIP) || playerTool.seed.Equals (PlayerActions.Seeds.CABBAGE)) {
				toolImage.sprite = springSeeds;
			} else if (playerTool.seed.Equals (PlayerActions.Seeds.ONION) || playerTool.seed.Equals (PlayerActions.Seeds.RADISH)) {
				toolImage.sprite = summerSeeds;
			} else if (playerTool.seed.Equals (PlayerActions.Seeds.CARROT) || playerTool.seed.Equals (PlayerActions.Seeds.SPINACH)) {
				toolImage.sprite = fallSeeds;
			} else if (playerTool.seed.Equals (PlayerActions.Seeds.DAIKONRADISH) || playerTool.seed.Equals (PlayerActions.Seeds.BROCCOLI)) {
				toolImage.sprite = winterSeeds;
			}else if (playerTool.seed.Equals (PlayerActions.Seeds.CHERRYTREE)) {
				toolImage.sprite = springTreeSeeds;
			}else if (playerTool.seed.Equals (PlayerActions.Seeds.PEACHTREE)) {
				toolImage.sprite = summerTreeSeeds;
			}else if (playerTool.seed.Equals (PlayerActions.Seeds.APPLETREE)) {
				toolImage.sprite = fallTreeSeeds;
			}else if (playerTool.seed.Equals (PlayerActions.Seeds.ORANGETREE)) {
				toolImage.sprite = winterTreeSeeds;
			}

		} else if (playerTool.tool.Equals (PlayerActions.Tools.NONE)) {
			toolImage.sprite = none;
		} else if (playerTool.tool.Equals (PlayerActions.Tools.WATERINGCAN)) {
			toolImage.sprite = wateringcan;
		}
	}
}
