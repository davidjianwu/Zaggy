using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;

	//SerializeField is so you can see the speed variable even though it is private in the unity editor
	[SerializeField]
	private float speed;
	bool started;
	bool gameOver;
	Rigidbody rb;

	void Awake() {
		//attach rigidbody to this componet
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization bascially happens without doing anything 
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!started) {
			if(Input.GetMouseButtonDown (0) && !gameOver) {
				//Ball move in x direction in this speed
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				//will take care of everything
				GameManager.instance.StartGame ();
			}
		}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		//if ray not colliding with anyother game object
		if(!Physics.Raycast(transform.position,Vector3.down,1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);


			//When gameover set gameOver in camerafollow.cs to true so it doesnt follow ball
			Camera.main.GetComponent<CameraFollow>().gameOver = true;

			GameManager.instance.GameOver ();
		}
			
		//whenever we click our left mosue button
		if(Input.GetMouseButtonDown(0) && !gameOver) {
			SwitchDirection ();
		}
	}

	void SwitchDirection() {
		//ball is moving in z direction
		if(rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		}
		else if(rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	//if we collide wih a gameObject with tag Diamond, Destory it
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Diamond") {
			//Must instantiate col.gameObject first otherwise it will be destoryed then no access
			//Quaternion.identy means no rotation, particle instantiates where our diamond is,
			//Store it so we can delete it later
			GameObject part = Instantiate (particle, col.gameObject.transform.position,Quaternion.identity) as GameObject;

			Destroy (col.gameObject);

			//after 1 second particle is destoried
			Destroy (part, 1f);

		}
	}
}
