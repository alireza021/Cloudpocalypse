using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor : MonoBehaviour {

	private CharacterController carController;
	public float forwardSpeed;
	public float rotateSpeed;
	public bool boost;
	ParticleSystem boostParticles;
	ParticleSystem boostParticles2;

	void Start () {
		carController = GetComponent<CharacterController> ();
		boostParticles = GameObject.Find("Afterburner").GetComponent<ParticleSystem> ();
		boostParticles2 = GameObject.Find("Afterburner (1)").GetComponent<ParticleSystem> ();
		boost = false;
	}


	void Update ()
	{	if (Input.GetKey (KeyCode.LeftShift)) {
			forwardSpeed = 33;
			boost = true;
			boostParticles.Play ();
			boostParticles2.Play ();
	} else {
		forwardSpeed = 10;
		boost = false;
		boostParticles.Stop ();
		boostParticles2.Stop ();
	}
		
		float speed = forwardSpeed * Input.GetAxis ("Vertical");
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		carController.SimpleMove (speed * forward);
		if (speed != 0) {
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);

		}
	}
}
