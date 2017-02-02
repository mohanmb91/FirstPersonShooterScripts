using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			CameraSwitch currentCamera = other.GetComponent<CameraSwitch> ();
			if (!currentCamera.isFPS()) {
				Messenger.Broadcast (GameEvent.PLAYER_TOOK_HEALTH);
				Destroy (this.gameObject);	
			}
		}

	}
}
