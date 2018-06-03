using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockNPCDialog : MonoBehaviour {

	public List<string> emilyLowFriendshipDialogs;
	public List<string> emilyMediumFriendshipDialogs;
	public List<string> emilyHighFriendshipDialogs;
	public List<string> emilyThanksDialogs;

	public List<string> rileyLowFriendshipDialogs;
	public List<string> rileyMediumFriendshipDialogs;
	public List<string> rileyHighFriendshipDialogs;
	public List<string> rileyThanksDialogs;

	public List<string> lilyLowFriendshipDialogs;
	public List<string> lilyMediumFriendshipDialogs;
	public List<string> lilyHighFriendshipDialogs;
	public List<string> lilyThanksDialogs;

	public List<string> tylerLowFriendshipDialogs;
	public List<string> tylerMediumFriendshipDialogs;
	public List<string> tylerHighFriendshipDialogs;
	public List<string> tylerThanksDialogs;

	// Use this for initialization
	void Start () {
		//EMLILY//
		emilyLowFriendshipDialogs.Add ("Everything good today? I hope so. Let me know if you need some help, I will help you."); 
		emilyLowFriendshipDialogs.Add("I'm a little tired today, lets talk later. But don't worry, I'm feeling better than some years ago.");
		emilyLowFriendshipDialogs.Add ("The air here is good for my health, it's cleaner than city air.");

		emilyMediumFriendshipDialogs.Add ("I always like this village, but since you arrived here I like it more.");
		emilyMediumFriendshipDialogs.Add ("It's good to have you around here, you are helping us all.");
		emilyMediumFriendshipDialogs.Add("You want to know what was I like before we met?, I was a really sickly kid, my parents brought me here for my sake.");

		emilyHighFriendshipDialogs.Add ("I like you very much, you should have come earlier.");
		emilyHighFriendshipDialogs.Add ("I haven't seen my parents for such a long time... I think they had another son while I was here.");
		emilyHighFriendshipDialogs.Add ("Hello, how is it going? Everything ok? Need something? Oh, you just wanted to say hello?");

		emilyThanksDialogs.Add ("Oh my god! Is that a cherry? For my? It's my fovourite thing in the world!");//0
		emilyThanksDialogs.Add("Thank you very much! I like it.");//1
		emilyThanksDialogs.Add ("... Why did you gave my this?");//2
		emilyThanksDialogs.Add ("You hate my so much that you gave me a spinach? What's wrong with you!?");//3
		emilyThanksDialogs.Add("Well, this is not bad.");//4
		emilyThanksDialogs.Add("I would feel bad receiving another gift, please keep it");//5

		//RILEY//
		rileyLowFriendshipDialogs.Add ("Ey, having a good day? I'm bored as ever in this small village.");
		rileyLowFriendshipDialogs.Add ("I wish to go to town someday and meet new people, it would be amazing.");
		rileyLowFriendshipDialogs.Add ("Why did you came here? You had a really good life back in the city, I can't understand you.");

		rileyMediumFriendshipDialogs.Add ("Since you came here life is a bit more interesting, you could have come here earlier.");
		rileyMediumFriendshipDialogs.Add ("Someday I will travel to the city and see how people live and behave there.");
		rileyMediumFriendshipDialogs.Add ("Don't exhaust yourself with farm chores, you need to take a break sometimes.");

		rileyHighFriendshipDialogs.Add ("I was born in this village and always wanted to get out of here, but with you around here life is more interesting.");
		rileyHighFriendshipDialogs.Add ("Life here is calm, I wish I had appreciated it before.");
		rileyHighFriendshipDialogs.Add ("Do you like spending time with me? I have a lot of fun hanging out with you.");

		rileyThanksDialogs.Add ("You really get me well uh, I really love wine, thanks.");//0
		rileyThanksDialogs.Add ("My thanks are in order, I like this.");//1
		rileyThanksDialogs.Add ("You have no taste.");//2
		rileyThanksDialogs.Add ("Come on, I'm allergic to peach, do you want to kill me!?");//3
		rileyThanksDialogs.Add ("Since it's a gift I will accept it.");//4
		rileyThanksDialogs.Add("Didn't you gift me something already? I can't accept it.");//5

		//LILY//
		lilyLowFriendshipDialogs.Add("Hello, how is your day going? Don't exhaust yourself too much.");
		lilyLowFriendshipDialogs.Add ("Tyler is my son, he is a good kid. He likes you, speak to him once in a while.");
		lilyLowFriendshipDialogs.Add ("This village is as peaceful as ever, I love being here.");

		lilyMediumFriendshipDialogs.Add ("My husband is working in another town, Tyler and I miss him greatly.");
		lilyMediumFriendshipDialogs.Add ("You are a good kid, I'm glad you came here.");
		lilyMediumFriendshipDialogs.Add ("Things have become livelier since you came here, it's pretty good. Thank you.");

		lilyHighFriendshipDialogs.Add ("You have a brilliant future, I can tell by simply looking at you.");
		lilyHighFriendshipDialogs.Add ("I don't know what will I do when Tyler grows up, he's a whole to me.");
		lilyHighFriendshipDialogs.Add ("The village has become a better place with you here, it's a pleasure helping you out.");

		lilyThanksDialogs.Add("Is that a bracelet!? I LOVE IT. Thank you very much dear.");
		lilyThanksDialogs.Add("I really like it, thank you");
		lilyThanksDialogs.Add("Guess I should say thanks");
		lilyThanksDialogs.Add ("What are you thinking giving me somthing like that!");
		lilyThanksDialogs.Add ("Broccoly? Really? What's your problem kid...");
		lilyThanksDialogs.Add ("I can't accept anything more today.");

		//TYLER//

		tylerLowFriendshipDialogs.Add("My mother runs this town shops, you should go and check it.");
		tylerLowFriendshipDialogs.Add("I like going to the town square, the fountain is pretty.");
		tylerLowFriendshipDialogs.Add("My father is out of town, sometimes he sends letters.");

		tylerMediumFriendshipDialogs.Add("Ey! wanna play with me? It would be amazing!");
		tylerMediumFriendshipDialogs.Add("Yesterday we received a letter from father, he says he is ok and that he misses us.");
		tylerMediumFriendshipDialogs.Add ("How was your life in town? Awful you say? How bad...");
	
		tylerHighFriendshipDialogs.Add("Dou you need help? Is everything ok? Why don't you play with me?");
		tylerHighFriendshipDialogs.Add("I like this village, and since you came here things are livelier.");
		tylerHighFriendshipDialogs.Add("Can I go to your farm? Please, please, please!");

		tylerThanksDialogs.Add("An apple!? Realy!? THANK YOU VERY MUCH!");
		tylerThanksDialogs.Add("Thank you! I really like this.");
		tylerThanksDialogs.Add("Weeeeel this is ok I suppose.");
		tylerThanksDialogs.Add("Aw... really? I suppose I will accept it.");
		tylerThanksDialogs.Add("Wine!? Oh come on, I'm a minor you know!?");
		tylerThanksDialogs.Add("Mother told me to not accept so many things in one day.");

	}

	public List<string> GetDialogs(string npcName, int FP){

		if (npcName.Contains ("Emily")) {
			if (FP <= 1000) {
				return emilyLowFriendshipDialogs;
			} else if (FP > 1000 && FP <= 2000) {
				return emilyMediumFriendshipDialogs;
			} else {
				return emilyHighFriendshipDialogs;
			}
		}if (npcName.Contains ("Riley")) {
			if (FP <= 1000) {
				return rileyLowFriendshipDialogs;
			} else if (FP > 1000 && FP <= 2000) {
				return rileyMediumFriendshipDialogs;
			} else {
				return rileyHighFriendshipDialogs;
			}
		}if (npcName.Contains ("Lily")) {
			if (FP <= 1000) {
				return lilyLowFriendshipDialogs;
			} else if (FP > 1000 && FP <= 2000) {
				return lilyMediumFriendshipDialogs;
			} else {
				return lilyHighFriendshipDialogs;
			}
		}if (npcName.Contains ("Tyler")) {
			if (FP <= 1000) {
				return tylerLowFriendshipDialogs;
			} else if (FP > 1000 && FP <= 2000) {
				return tylerMediumFriendshipDialogs;
			} else {
				return tylerHighFriendshipDialogs;
			}
		}

		return new List<string> ();
	}
	public List<string> GetDialogsForGifts(string npcName){

		if (npcName.Contains ("Emily")) {
			return emilyThanksDialogs;
		}if (npcName.Contains ("Riley")) {
			return rileyThanksDialogs;
		}if (npcName.Contains ("Lily")) {
			return lilyThanksDialogs;
		}if (npcName.Contains ("Tyler")) {
			return tylerThanksDialogs;
		}
		return new List<string> ();
	}
}
