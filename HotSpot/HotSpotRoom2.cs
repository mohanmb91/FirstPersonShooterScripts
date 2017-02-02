using UnityEngine;
using System.Collections;

public class HotSpotRoom2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
//		void Update () {
//			Ray ray = new Ray(transform.position, transform.forward);
//			RaycastHit hit;
//			if (Physics.SphereCast(ray, 0.75f, out hit)) {
//				GameObject hitObject = hit.transform.gameObject;
//				if (hitObject.GetComponent<PlayerCharacter>()) {
//					PlayerCharacter player =  hitObject.GetComponent<PlayerCharacter> ();
//				player.HotSpot2Teleport(transform);
//				Messenger.Broadcast (GameEvent.ROOM_CHANGED);
//				}
//			}
//		}


	void OnTriggerEnter(Collider col){
		if (col.GetComponent<PlayerCharacter>()) {
			//PlayerCharacter player =  col.GetComponent<PlayerCharacter> ();
			//player.HotSpot2Teleport(transform);
			Messenger.Broadcast (GameEvent.ROOM_CHANGED);
		}
	}
}
