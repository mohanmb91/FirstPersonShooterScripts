using UnityEngine;
using System.Collections;

public class hiteffect : MonoBehaviour {

	public float pushStrength = 6.0f, speedupStrength = 10.0f;


	void Start(){

	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody body = hit.collider.attachedRigidbody;
		if(body == null || body.isKinematic){
			return;
		}

		if(hit.moveDirection.y < -0.3f){
			return;
		}

		pushStrength = this.GetComponent<FPSInput> ().GetPlayerSpeed();

		Vector3 direction = new Vector3 (hit.moveDirection.x,0,hit.moveDirection.z);
		body.velocity = direction * pushStrength;
	}


}
