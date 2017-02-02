using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	private Vector3 tempPos;
	void Start() {
		_health = 5;

	}



	public void Hurt(int damage) {
		_health -= damage;
	//	Debug.Log("Health: " + _health);
	}

	public void consumedHealth(){
		_health += 1;
	}

	public void HotSpot1Teleport(){
		tempPos = transform.position;
		tempPos.x = -120.0f;
		tempPos.y = -25.91f;
		tempPos.z = 275.01f;
		transform.Rotate(0, 90, 0,Space.World);
		transform.position = tempPos;
	}

	public void HotSpot2Teleport(){
			tempPos = transform.position;
		tempPos.x = -120.0f;
		tempPos.y = 3.86f;
		tempPos.z = 442.9f;
			transform.Rotate(0, 270, 0,Space.World);
			transform.position = tempPos;
	}
}
