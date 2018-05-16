using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Rendering;

public class SoilOutline : MonoBehaviour {

	public Shader outline;
	public Shader standardShader;
	// Use this for initialization
	void Start () {
		standardShader = this.GetComponent<MeshRenderer> ().material.shader;
	}


	public void OnMouseOver(){
		if (this.GetComponent<SoilCollision> ().collision) {
			this.GetComponent<MeshRenderer> ().material.shader = outline;
			this.GetComponent<MeshRenderer> ().material.renderQueue = -1;
		}

	}

	public void OnMouseExit(){
		this.GetComponent<MeshRenderer> ().material.shader = standardShader;
		this.GetComponent<MeshRenderer> ().material.renderQueue = -1;
	}

}
