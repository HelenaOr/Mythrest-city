using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour {
	public Vector3 startPosition;
	public Vector3 finalPosition;
	NavMeshAgent _nav;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		startPosition = this.transform.position;
		_nav = GetComponent<NavMeshAgent> ();
		Vector3 randomDirection = Random.insideUnitSphere*100.0f;
		randomDirection += startPosition;
		NavMeshHit hit;

		NavMesh.SamplePosition (randomDirection, out hit,100.0f, 1);

		this.finalPosition = hit.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Mathf.Approximately(finalPosition.x,this.transform.position.x) && !Mathf.Approximately(finalPosition.z,this.transform.position.z)) {
			anim.SetBool ("isWalking", true);
			Movement (this.startPosition,this.finalPosition);
		} else {
			anim.SetBool ("isWalking", false);
			StartCoroutine (recalculatePoint ());

		}
		
	}


	void Movement(Vector3 startPosition, Vector3 finalPosition){
		
		_nav.destination = finalPosition;
	}

	IEnumerator recalculatePoint(){

		yield return new WaitForSeconds (2.0f);
		Vector3 randomDirection = Random.insideUnitSphere*100.0f;
		randomDirection += startPosition;
		NavMeshHit hit;
		NavMesh.SamplePosition (randomDirection, out hit,100.0f, 1);
		this.startPosition = this.transform.position;
		this.finalPosition = hit.position;
	}

	public void stop(){
		_nav.isStopped = true;
	}

	public void resume(){
		_nav.isStopped = false;
	}
}
