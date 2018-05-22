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
		string dialogToSay;

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
				dialogToSay = dialogs [4];
				int actualfp = friendshipPoints;
				while (friendshipPoints == actualfp) {
					if (myself.favouriteItem == itemCode) {
						friendshipPoints += 800;
						dialogToSay = dialogs [0];
					}
					foreach (int i in myself.likedItems) {
						if (i == itemCode) {
							friendshipPoints += 300;
							dialogToSay = dialogs [1];
							break;
						}
					}
					foreach (int i in myself.dislikedItems) {
						if (i == itemCode) {
							friendshipPoints -= 300;
							dialogToSay = dialogs [2];
							break;
						}
					}
					if (myself.horrorItem == itemCode) {
						friendshipPoints -= 800;
						dialogToSay = dialogs [3];
					}
					friendshipPoints += 50;
					canvas.transform.Find ("TalkPanel").Find ("TalkText").GetComponent<Text> ().text = dialogToSay;
				}


			} else {
				dialogToSay = dialogs [5];
				canvas.transform.Find ("TalkPanel").Find ("TalkText").GetComponent<Text> ().text = dialogToSay;
			}

		}
		if (friendshipPoints < 0) {
			friendshipPoints = 0;
		}

		myself.friendship = friendshipPoints;


	}
	public void closeDialog(){
		firstTalked = true;
		alreadygifted = true;
		myself.gifted = true;
		myself.talked = true;
		talking = false;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

}
