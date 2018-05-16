using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockShopDB : MonoBehaviour {

	public ShopItem turnipSeeds;
	public ShopItem cabbageSeeds;
	public ShopItem cherryTreeSeeds;

	public ShopItem carrotSeeds;
	public ShopItem onionSeeds;
	public ShopItem peachTreeSeeds;

	public ShopItem radishSeeds;
	public ShopItem spinachSeeds;
	public ShopItem appleTreeSeeds;

	public ShopItem daikonradishSeeds;
	public ShopItem broccoliSeeds;
	public ShopItem orangeTreeSeeds;

	public ShopItem vegetableSmoothie;
	public ShopItem fruitSmoothie;
	public ShopItem wine;
	public ShopItem bracelet;
	public ShopItem book;
	public ShopItem photo;

	public List<ShopItem> items;
	// Use this for initialization
	void Start () {

		turnipSeeds = new ShopItem ("Turnip seeds", "Amazing turnip seeds which can be grown in spring.\n\nHavest time: 5 days.",8, 150, ShopItem.itemTypes.SEED);
		cabbageSeeds = new ShopItem ("Cabbage seeds", "Amazing cabbage seeds which can be grown in spring.\n\nHarvest time: 8 days.",9, 320, ShopItem.itemTypes.SEED);
		cherryTreeSeeds = new ShopItem ("Cherry tree seeds", "Amazing cherry tree seeds. Trees do not need to be watered. Cherries are grown during spring.\n\nRipening time: 56 days\nCollection time: 3 days", 36, 1700, ShopItem.itemTypes.SEED);

		carrotSeeds = new ShopItem ("Carrot seeds", "Amazing carrot seeds which can be grown in fall.\n\nHarvest time: 7 days.",10, 140, ShopItem.itemTypes.SEED);
		spinachSeeds = new ShopItem ("Spinach seeds", "Amazing cabbage seeds which can be grown in fall.\n\nHarvest time: 7 days.",13, 280, ShopItem.itemTypes.SEED);
		appleTreeSeeds = new ShopItem ("Apple tree seeds", "Amazing apple tree seeds. Trees do not need to be watered. Apples are grown during fall.\n\nRipening time: 62 days\nCollection time: 4 days", 38, 2000, ShopItem.itemTypes.SEED);

		radishSeeds = new ShopItem ("Radish seeds", "Amazing radish seeds which can be grown in summer.\n\nHarvest time: 6 days.",12, 220, ShopItem.itemTypes.SEED);
		onionSeeds = new ShopItem ("Onion seeds", "Amazing onion seeds which can be grown in summer.\n\nHarvest time: 5 days.",11, 160, ShopItem.itemTypes.SEED);
		peachTreeSeeds = new ShopItem ("Peach tree seeds", "Amazing peach tree seeds. Trees do not need to be watered. Peaches are grown during summer.\n\nRipening time: 53 days\nCollection time: 4 days", 37, 2000, ShopItem.itemTypes.SEED);

		daikonradishSeeds= new ShopItem ("Daikon radish seeds", "Amazing daikon radish seeds which can be grown in winter.\n\nHarvest time: 8 days.",14, 220, ShopItem.itemTypes.SEED);
		broccoliSeeds = new ShopItem ("Broccoli seeds", "Amazing broccoli seeds which can be grown in winter. Harvest time:\n\n7 days.",15, 300, ShopItem.itemTypes.SEED);
		orangeTreeSeeds = new ShopItem ("Orange tree seeds", "Amazing orange tree seeds. Trees do not need to be watered. Oranges are grown during winter.\n\nRipening time: 58 days\nCollection time: 5 days", 39, 2100, ShopItem.itemTypes.SEED);

		vegetableSmoothie = new ShopItem ("Vegetable smoothie", "Fresh and nutritive, the best remedy for fatigue in hot days!.", 26, 3000, ShopItem.itemTypes.EDIBLE);
		fruitSmoothie = new ShopItem ("Fruit smoothie", "Sweet smoothie which can help you recovering your stamina.", 27, 2700, ShopItem.itemTypes.EDIBLE);
		wine = new ShopItem ("Wine", "Refined wine made ony with the best grapes of the village.", 28, 250, ShopItem.itemTypes.EDIBLE);

		bracelet = new ShopItem ("Bracelet", "Girls usually like this bracelet, it is a good gift.", 29, 1200, ShopItem.itemTypes.NOTEDIBLE);
		book = new ShopItem ("Book", "Nothing like a good book to read in cold days. You can give it as a gift.", 30, 570, ShopItem.itemTypes.NOTEDIBLE);
		photo = new ShopItem ("Photo", "A colorful photo which you can gift.", 31, 210, ShopItem.itemTypes.NOTEDIBLE);

		items.Add (turnipSeeds);
		items.Add (cabbageSeeds);
		items.Add (cherryTreeSeeds);

		items.Add (carrotSeeds);
		items.Add (spinachSeeds);
		items.Add (peachTreeSeeds);

		items.Add (onionSeeds);
		items.Add (radishSeeds);
		items.Add (appleTreeSeeds);

		items.Add (daikonradishSeeds);
		items.Add (broccoliSeeds);
		items.Add (orangeTreeSeeds);

		items.Add (vegetableSmoothie);
		items.Add (fruitSmoothie);
		items.Add (wine);
		items.Add (bracelet);
		items.Add (book);
		items.Add (photo);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
