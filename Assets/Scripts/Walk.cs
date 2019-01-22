using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	private Animator anim;
	private float vert;

	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		PlayerMotor checker = GameObject.Find ("Player").GetComponent<PlayerMotor> ();
		HealthBar checker2 = GameObject.Find ("Player").GetComponent<HealthBar> ();
		vert = Input.GetAxisRaw ("Vertical");
		anim.SetFloat ("walk", vert);
		if (checker.running == false) {
			anim.SetBool ("run", false);
		}
		if (checker.running == true) {
			anim.SetBool ("run", true);
		}
		if (checker2.currentHealth <= 0) {
			anim.SetBool ("dead", true);
		
		}
			
	}
}
