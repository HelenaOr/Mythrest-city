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
		rileyLowFriendshipDialogs.Add ("I wish to go to town someday and meet new people, it would be amazing");
		rileyLowFriendshipDialogs.Add ("Why did you came here? You had a really good life back in the city, I can't understand you.");

		rileyMediumFriendshipDialogs.Add ("Since you came here life is a bit more interesting, you could have come here earlier");
		rileyMediumFriendshipDialogs.Add ("Someday I will travel to the city and see how people live and behave there.");
		rileyMediumFriendshipDialogs.Add ("Don't exhaust yourself with farm chores, you need to take a break sometimes.");

		rileyHighFriendshipDialogs.Add ("I was born in this village and always wanted to get out of here, but with you around here life is more interesting.");
		rileyHighFriendshipDialogs.Add ("Life here is calm, I wish I had appreciated it before.");
		rileyHighFriendshipDialogs.Add ("Do you like spending time with me? I have a lot of fun hanging out with you.");


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
		}

		return new List<string> ();
	}
	public List<string> GetDialogsForGifts(string npcName){

		if (npcName.Contains ("Emily")) {
			return emilyThanksDialogs;
		}
		return new List<string> ();
	}
}
