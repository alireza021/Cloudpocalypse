using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private const float Y_ANGLE_MIN = 5.0f;
	private const float Y_ANGLE_MAX = 50.0f;

	public Transform lookAt;
	public Transform camTransform;



	private float distance = 26.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;


	private void Start() {
		
		camTransform = transform;
		Cursor.visible = false;

	}

	private void Update(){

		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

		CarController check = GameObject.Find("Car").GetComponent<CarController> ();
		if (check.inCar) {
			lookAt = GameObject.Find ("Car").transform;
		} else {
			lookAt = GameObject.Find ("Player").transform;
		}
	}

	private void LateUpdate(){
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	
	}
}
