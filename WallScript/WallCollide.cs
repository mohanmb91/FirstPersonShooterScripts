using UnityEngine;
using System.Collections;

public class WallCollide : MonoBehaviour {

	
	void OnTriggerEnter(Collider col){
		if (col.GetComponent<ReactiveTarget>()) {
			col.GetComponent<ReactiveTarget> ().ReactToHit ();
		}
	}
}
