using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour {

	public NPC myself;
	public int friendshipPoints;
	public static int maxFP = 3000;
	public bool firstTalked;
	public bool alreadygifted;
	public MockNPCDB NPCdatabase;
	public List<string> dialogs;
	public MockNPCDialog dialogDB;
	public bool gifting;
	public bool talking;
	public string dialogToSay;

	// Use this for initialization
	void Start () {
		NPCdatabase = FindObjectOfType (typeof(MockNPCDB)) as MockNPCDB;
		dialogDB = FindObjectOfType (typeof(MockNPCDialog)) as MockNPCDialog;
		if (this.name.Contains ("Emily")) {
			myself = NPCdatabase.Emily;
		} else if (this.name.Contains ("Riley")) {
			myself = NPCdatabase.Riley;
		} else if (this.name.Contains ("Tyler")) {
			myself = NPCdatabase.Tyler;
		} else if (this.name.Contains ("Lily")) {
			myself = NPCdatabase.Lily;
		}
		friendshipPoints = myself.friendship;
		alreadygifted = myself.gifted;
		firstTalked = myself.talked;

	}
	

	public void Talk(int itemCode){
		talking = true;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (true);
		Time.timeScale = 0.0f;
		Transform canvas = this.transform.Find ("TalkCanvas");

		if (itemCode == -1) {
			if (firstTalked == false) {
				friendshipPoints += 100;
			}
			dialogs = dialogDB.GetDialogs (myself.name,friendshipPoints);
			int random = Random.Range (0, 3);
			dialogToSay = dialogs [random];
			canvas.transform.Find ("TalkPanel").Find("TalkText").GetComponent<Text> ().text = dialogToSay;

		} else {
			if (!alreadygifted) {
				dialogs = dialogDB.GetDialogsForGifts (myself.name);
				int actualfp = friendshipPoints;
				if (howLiked(itemCode) == "favourite") {
					friendshipPoints += 800;
					dialogToSay = dialogs [0];
				}
				if (howLiked(itemCode) == "liked") {
						friendshipPoints += 300;
						dialogToSay = dialogs [1];

					}
				
				if (howLiked(itemCode) == "disliked") {
						friendshipPoints -= 300;
						dialogToSay = dialogs [2];
					}
				
				if (howLiked(itemCode) == "horror") {
					friendshipPoints -= 800;
					dialogToSay = dialogs [3];
				}if (howLiked(itemCode) == "neutral") {
					friendshipPoints += 50;
					dialogToSay = dialogs [4];
				}


				canvas.transform.Find ("TalkPanel").Find ("TalkText").GetComponent<Text> ().text = dialogToSay;
				alreadygifted = true;


			} else {
				dialogs = dialogDB.GetDialogsForGifts (myself.name);
				dialogToSay = dialogs [5];
				canvas.transform.Find ("TalkPanel").Find ("TalkText").GetComponent<Text> ().text = dialogToSay;
			}

		}
		if (friendshipPoints < 0) {
			friendshipPoints = 0;
		}

		myself.friendship = friendshipPoints;


	}

	string howLiked(int itemCode){
		if (myself.favouriteItem == itemCode) {
			return "favourite";
		}
		foreach (int i in myself.likedItems) {
			if (i == itemCode) {
				return "liked";
			}
		}
		foreach (int i in myself.dislikedItems) {
			if (i == itemCode) {
				return "disliked";
			}
		}
		if (myself.horrorItem == itemCode) {
			return "horror";
		}
		return "neutral";
	}

	public void closeDialog(){
		firstTalked = true;
		myself.gifted = alreadygifted;
		myself.talked = true;
		talking = false;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

}
