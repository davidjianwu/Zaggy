using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//Make ball here so it can follow ball
	public GameObject ball;
	Vector3 offset;
	//make camera smooth
	public float lerpRate;

	public bool gameOver;

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOver) {
			Follow ();
		}
	}


	//Folow ball function
	void Follow() {
		//cannot modify this directly
		Vector3 pos = transform.position;
		Vector3 targetPos = ball.transform.position - offset;
		pos = Vector3.Lerp (pos,targetPos,lerpRate * Time.deltaTime);
		transform.position = pos;
	}
}
