using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController playerController;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	public float rotateSpeed;
	public bool running;


	private float vert;



	void Start () {
		playerController = GetComponent<CharacterController> ();
		running = false;

	
	}
	

	void Update () {

		if (playerController.isGrounded) {
			moveDirection = new Vector3(0 , 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			transform.Rotate (0, Input.GetAxisRaw ("Horizontal") * rotateSpeed, 0);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		playerController.Move(moveDirection * Time.deltaTime);
	

		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = 9;
			running = true;
		} else {
			speed = 5;
			running = false;
		}







	}


}
