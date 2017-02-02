using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
	private CharacterController controller;
	private float speed;
	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 10.0f;

	void Start() {
		speed = 10.0f;
		controller = GetComponent<CharacterController> ();
	}
	void Update() {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		if (controller.isGrounded) {
			verticalVelocity = -gravity * Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpForce;
			}
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		Vector3 moveVector = Vector3.zero;
		moveVector.x = deltaX;
		moveVector.y = verticalVelocity;
		moveVector.z = deltaZ;

		//moveVector = Vector3.ClampMagnitude (moveVector,speed);
		controller.Move (moveVector * Time.deltaTime);
	}
}
/*
 * 
 * 
		movement = Vector3.ClampMagnitude(movement, speed);
//		if (Input.GetButton("space")){
//			movement.y = jumpSpeed;
//
//		}

		//movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);



public float speed = 6.0F;
	public float jumpSpeed = 300.0F;
	public float gravity = - 9.8F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
*/