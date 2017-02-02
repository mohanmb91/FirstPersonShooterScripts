using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public float speed;
	public float distance;
	public GameObject player;

	void Start () {
		this.setSpeed(GameObject.FindGameObjectWithTag ("GameController").GetComponent<SceneController>().getEnemySlider().value);
		player = GameObject.FindGameObjectWithTag ("Player");
		distance = Vector3.Distance (player.transform.position, this.transform.position);
	}

	void Update () {
		if (this.GetComponent<AvoidBlockAI>().getIsAlive ()) {
			distance = Vector3.Distance (player.transform.position, this.transform.position);
			Vector3 direction = player.transform.position - this.transform.position;
			if (distance < 24) {
				direction.y = 0;
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 0.1f);
			}
			transform.Translate (0, 0, speed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}
	}




	public void setSpeed(float newSpeed){
		this.speed = newSpeed;
	}
	public float getSpeed(){
		return this.speed;
	}
	public void setDistance(float newDistance){
		this.distance = newDistance;
	}
	public float getDistance(){
		return this.distance;
	}


}
