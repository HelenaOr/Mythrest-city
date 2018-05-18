using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour {

	public NPC myself;
	public int friendshipPoints;
	public static int maxFP = 3000;
	public bool firstTalked;
	public MockNPCDB NPCdatabase;
	public List<string> dialogs;
	public MockNPCDialog dialogDB;
	public bool gifted;
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
		gifted = myself.gifted;
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
			string dialogToSay = dialogs [random];
			canvas.transform.Find ("TalkPanel").Find("TalkText").GetComponent<Text> ().text = dialogToSay;

		} else {
			if (!gifted) {
				string dialogToSay ="Tanks";
				canvas.transform.Find ("TalkPanel").Find("TalkText").GetComponent<Text> ().text = dialogToSay;
				gifted = true;
				myself.gifted = true;
				if (myself.favouriteItem == itemCode) {
					friendshipPoints += 800;

				}
				foreach (int i in myself.likedItems) {
					if (i == itemCode) {
						friendshipPoints += 300;
						break;
					}
				}
				foreach (int i in myself.dislikedItems) {
					if (i == itemCode) {
						friendshipPoints -= 300;
						break;
					}
				}
				if (myself.horrorItem == itemCode) {
					friendshipPoints -= 800;
				}
			}

		}
		myself.friendship = friendshipPoints;


	}
	public void closeDialog(){
		firstTalked = true;
		myself.talked = true;
		talking = false;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

}
