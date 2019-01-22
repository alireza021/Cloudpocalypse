using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarController : MonoBehaviour {
	public Transform player;
	public float distance = 2.0F;
	public bool inCar;
	private CharacterController carController;
	public GameObject user;
	public Transform playerpos;



	void Start(){
		carController = GetComponent<CharacterController> ();
		user = GameObject.Find ("Player");
		inCar = false;
		playerpos = GameObject.Find ("PlayerPos").transform;

	}

	void Update() {
		if (player) {
			Vector3 offset = player.position - transform.position;
			float sqrLen = offset.sqrMagnitude;
			if (Input.GetKeyDown ("q")) {
				if (sqrLen < distance * distance) {
					user.SetActive (false); 
					inCar = !inCar;

					carController.enabled = true;
					GetComponent<CarMotor>().enabled = true;
			}
			
			}
		
	}
		if (inCar == false) {
			
			user.SetActive (true);
			carController.enabled = false;
			GetComponent<CarMotor>().enabled = false;
			AudioSource carstart = GetComponent<AudioSource> ();
			carstart.Play ();

		}

		if (inCar == true) {

			user.transform.position = playerpos.position;

			
			}

		}


}

