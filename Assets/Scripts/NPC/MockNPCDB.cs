using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockNPCDB : MonoBehaviour {

	public NPC Emily;
	public NPC Riley;
	public NPC Tyler;
	public NPC Lily;
	// Use this for initialization
	void Start () {
	
		Emily = new NPC("Emily","Lawrence",10,1,32,new int[]{0,4,27,29,30,31},new int[]{8,9,10,11,12,13,14,15,20,21,26,36,37,38,39},5);
		Riley = new NPC ("Riley", "Bates", 21, 4, 28, new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 26, 32, 33, 34, 35 }, new int[]{ 16, 17, 18, 19, 20, 21, 29, 31 }, 33);
		Tyler = new NPC ("Tyler", "Davis", 9, 3, 34, new int[]{ 16, 17, 18, 19, 20, 21, 32, 33, 34, 35 }, new int[]{ 0, 1, 2, 3, 4, 5, 6, 7 }, 28);
		Lily = new NPC("Lily","Davis",16,2,29,new int[]{26,27,28,29,30,31,2,3,33},new int[]{8,9,10,11,12,13,14,15,20,21,36,37,38,39}, 7);
	}

}
