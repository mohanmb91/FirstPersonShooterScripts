using UnityEngine;
using System.Collections;

public class HotSpotRoom1 : MonoBehaviour {

	// Use this for initialization

	void Start () {

	}

	void OnTriggerEnter(Collider col){
		if (col.GetComponent<PlayerCharacter>()) {
//			PlayerCharacter player =  col.GetComponent<PlayerCharacter> ();
//			player.HotSpot1Teleport(transform);
			Messenger.Broadcast (GameEvent.ROOM_CHANGED);
	}
	}
}
