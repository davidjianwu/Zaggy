using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "Ball") {
			//Calls FallDown functionm after 0.5 seconds after it is triggered.
			Invoke ("FallDown", 0.5f);	
		}
	}

	//Makes the paltforms fall down fixed 
	void FallDown() {
		GetComponentInParent<Rigidbody>().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		Destroy (transform.parent.gameObject, 2f);
	}
}
