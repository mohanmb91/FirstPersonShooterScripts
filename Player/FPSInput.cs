using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed;
	public float gravity = -9.8f;
	public float jumpSpeed = 8.0F;
	//public float gravity = 20.0F;
	private CharacterController _charController;
	public GameObject player;
	private float verticalVelocity;
	void Start() {
		speed = 10.0f;

		_charController = GetComponent<CharacterController>();
	}

	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		if (speed < 9.0f) {
			player.GetComponent<Animation> ().CrossFade ("walk", 1.0f);
		} else {
			player.GetComponent<Animation> ().CrossFade ("run", 1.0f);
		}
//		/* start */
//		if (_charController.isGrounded) {
//			//verticalVelocity = -gravity * Time.deltaTime;
//			if (Input.GetKeyDown (KeyCode.Space)) {
//				verticalVelocity = jumpSpeed;
//				movement.y = verticalVelocity;
//			} 
//		} else {
//			verticalVelocity -= gravity * Time.deltaTime;
//		}
//		movement *= Time.deltaTime;
//
//		movement = transform.TransformDirection(movement);
//		_charController.Move(movement);
//		/*end*/

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	public float GetPlayerSpeed(){
		return speed;
	}
	public void setPlayerSpeed(float newPlayerSpeed){
		this.speed = newPlayerSpeed;
	}

}
