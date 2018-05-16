using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockCropDB : MonoBehaviour {

	public Crops turnip;
	public Crops cabbage;
	public Crops cherry;

	public Crops onion;
	public Crops radish;
	public Crops peach;

	public Crops carrot;
	public Crops spinach;
	public Crops apple;

	public Crops daikonRadish;
	public Crops broccoli;
	public Crops orange;

	public List<Crops> allCrops = new List<Crops>();
	// Use this for initialization
	void Start () {

		//SPRING CROPS//
		turnip = new Crops ("Turnip","Amazing turnip, a spring crop. You can eat it or sell it.",3, 1, 2, 1,50,0,"SPRING");
		cabbage = new Crops ("Cabbage","Amazing cabbage, a spring crop. You can eat it or sell it.",5, 2, 3, 2,106,1, "SPRING");
		cherry = new Crops ("Cherry", "Amazing cherry, a spring fruit. You can eat it or sell it", 7, 20, 31, 3, 425, 32, "SPRING");

		//SUMMER CROPS//
		onion = new Crops("Onion","Amazing onion, a summer crop. You can eat it or sell it.",2,1,2,1,53,2, "SUMMER");
		radish = new Crops ("Radish","Amazing radish, a summer crop. You can eat it or sell it.",4, 2, 1, 2,73,3, "SUMMER");
		peach = new Crops ("Peach", "Amazing peach, a summer fruit. You can eat it or sell it", 8, 17, 32, 4,487, 33, "SUMMER");

		//FALL CROPS//
		carrot = new Crops ("Carrot","Amazing carrot, a fall crop. You can eat it or sell it.",2, 2, 3, 1,46,4,"FALL");
		spinach = new Crops ("Spinach","Amazing spinach, a fall crop. You can eat it or sell it.",3, 1, 3, 2,93,5, "FALL");
		apple = new Crops ("Apple", "Amazing apple, a fall fruit. You can eat it or sell it", 6, 24, 33, 4, 500, 34, "FALL");

		//WINTER CROPS//
		daikonRadish = new Crops ("Daikon Radish","Amazing daikon radish, a winterg crop. You can eat it or sell it.",5,2,3,2,73,6,"WINTER");
		broccoli = new Crops ("Broccoli","Amazing broccoli, a winter crop. You can eat it or sell it.",3, 2, 1, 3,100,7, "WINTER");
		orange = new Crops ("Orange", "Amazing orange, a winter fruit. You can eat it or sell it", 8, 31, 24, 5, 525, 35, "WINTER");

		allCrops.Add (turnip);
		allCrops.Add (cabbage);
		allCrops.Add (onion);
		allCrops.Add (radish);
		allCrops.Add (carrot);
		allCrops.Add (spinach);
		allCrops.Add (daikonRadish);
		allCrops.Add (broccoli);

		allCrops.Add (cherry);
		allCrops.Add (peach);
		allCrops.Add (apple);
		allCrops.Add (orange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
