using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarKill : MonoBehaviour {

	public Transform enemy;
	// Use this for initialization
	void Start () {
		enemy = GameObject.FindWithTag("Blood").transform;
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		Vector3 enemyposition = enemy.transform.position;

			NPCScript enemyHealth = enemy.GetComponent<Collider>().GetComponent<NPCScript>();

				enemyHealth.TakeDamage(enemyposition);



	}
}
