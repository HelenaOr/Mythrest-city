using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NPC {

	public string name;
	public string surname;
	public int birthdayDay;
	public int birthdayMonth;
	public int friendship;
	public int favouriteItem;
	public int[] likedItems;
	public int[] dislikedItems;
	public int horrorItem;

	public bool gifted;
	public bool talked;

	public NPC(string name, string surname, int birthdayDay, int birthdayMonth,int favouriteItem, int [] likedItems, int[] dislikedItems, int horrorItem){
		this.name = name;
		this.surname = surname;
		this.birthdayDay = birthdayDay;
		this.birthdayMonth = birthdayMonth;
		this.favouriteItem = favouriteItem;
		this.likedItems = likedItems;
		this.dislikedItems = dislikedItems;
		this.horrorItem = horrorItem;
	}
}
