using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	public float range = 10f;
	public Text countText;


	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	public int points = 0; 

	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> ();
		gunLight = GetComponent<Light> ();
		countText.text = "0";



	}
	

	void Update () {

		timer += Time.deltaTime;

		if (Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets) {
			Shoot ();
		} 
		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			DisableEffects ();
		}

	}

	public void DisableEffects (){
		gunLine.enabled = false;
		gunLight.enabled = false;

	}

	void Shoot(){
		
		timer = 0f;

		gunLight.enabled = true;
		gunLine.enabled = true;
		AudioSource gunshot = GetComponent<AudioSource> ();
		gunshot.Play ();

		gunLine.SetPosition (0, transform.position);
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			NPCScript enemyHealth = shootHit.collider.GetComponent<NPCScript>();
			Rigidbody enemyBody = shootHit.collider.GetComponent<Rigidbody> ();


				enemyHealth.TakeDamage(shootHit.point);
				enemyHealth.ApplyForce (enemyBody, shootHit);
				countText.text = points.ToString ();

			gunLine.SetPosition (1, shootHit.point);
			}
			else {
				gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
			}

		}
	}

