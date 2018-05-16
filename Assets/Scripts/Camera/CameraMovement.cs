using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	float smoothing = 5f;
	public Vector3 offset;



	void Awake(){


		DontDestroyOnLoad (this);

		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}


	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCameraPos = player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCameraPos, smoothing * Time.deltaTime);
	}
}
