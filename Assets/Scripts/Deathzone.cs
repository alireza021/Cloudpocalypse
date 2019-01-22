using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player"){
			HealthBar die = GameObject.Find ("Player").GetComponent<HealthBar> ();
			die.Die ();

		}
	}
}
