using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

	public AudioClip spring;
	public AudioClip summer;
	public AudioClip fall;
	public AudioClip winter;

	// Use this for initialization
	void Start () {

	}

	void Update(){
		Debug.Log (this.GetComponent<AudioSource> ().isPlaying);
	}

	public void changeMusic(float season){
		if (season == 1f) {
			this.GetComponent<AudioSource> ().clip = spring;
		}if (season == 2f) {
			this.GetComponent<AudioSource> ().clip = summer;
		}if (season ==3f) {
			this.GetComponent<AudioSource> ().clip = fall;
		}if (season == 4f) {
			this.GetComponent<AudioSource> ().clip = winter;
		}

		this.GetComponent<AudioSource> ().Play ();
	}
}
