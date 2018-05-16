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
	}
	

	public void Talk(){
		talking = true;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (true);
		Time.timeScale = 0.0f;
		Transform canvas = this.transform.Find ("TalkCanvas");
		if (firstTalked == false) {
			friendshipPoints += 100;
		}
		dialogs = dialogDB.GetDialogs (myself.name,friendshipPoints);
		int random = Random.Range (0, 3);
		string dialogToSay = dialogs [random];

		canvas.transform.Find ("TalkPanel").Find("TalkText").GetComponent<Text> ().text = dialogToSay;

	}
	public void closeDialog(){
		firstTalked = true;
		talking = false;
		this.transform.Find ("TalkCanvas").gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

	public void recieveGift(int itemCode){
		Debug.Log (itemCode);
		if (myself.favouriteItem == itemCode) {
			friendshipPoints += 800;
			return;
		}
		foreach (int i in myself.likedItems) {
			if (i == itemCode) {
				friendshipPoints += 300;
				return;
			}
		}
		foreach (int i in myself.dislikedItems) {
			if (i == itemCode) {
				friendshipPoints -= 300;
				return;
			}
		}
		if (myself.horrorItem == itemCode) {
			friendshipPoints -= 800;
			return;
		}
		//friendshipPoints += 100;
		
	}
}
