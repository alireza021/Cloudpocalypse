using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {

	ParticleSystem hitParticles;

	private GameObject objSpawn;
	private int SpawnerID;
	public bool dead= false;
	public GameObject point;




	void Start () {
		objSpawn = (GameObject) GameObject.FindWithTag ("Spawner");
		hitParticles = GameObject.Find("hitParticles").GetComponent<ParticleSystem> ();
		point = GameObject.Find ("point");

	}
	

	void Update () {
		
	}

	public void TakeDamage(Vector3 hitPoint){
		if (!dead) {
			hitParticles.transform.position = hitPoint;
			hitParticles.Play ();
		
			dead = true;
			PlayerShooting pointcount = GameObject.Find("Player").GetComponentInChildren<PlayerShooting>();
			pointcount.points++;

			Invoke ("removeMe", 4.0f);

		}
	}

	public void ApplyForce(Rigidbody body, RaycastHit hit) {
		//Vector3 direction = transform.TransformDirection (Vector3.back);
		body.AddForceAtPosition(hit.transform.up * 300, hit.point);
	}
	void removeMe ()
	{
		objSpawn.BroadcastMessage("killEnemy", SpawnerID);
		Destroy(gameObject);
	}
	void setName(int sName)
	{
		SpawnerID = sName;
	}


}
