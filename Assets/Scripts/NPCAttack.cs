using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour {

	//The target player
	public Transform player;
	//At what distance will the enemy walk towards the player?
	public float walkingDistance = 25.0f;
	//In what time will the enemy complete the journey between its position and the players position
	public float smoothTime = 3.0f;
	//Vector3 used to store the velocity of the enemy
	private Vector3 smoothVelocity = Vector3.zero;
	//Call every frame
	private Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
		player = GameObject.Find ("Player").transform;

	}
	void Update()
	{
		NPCScript npc = GetComponent<NPCScript>();
		if (npc.dead == false) {
			//Look at the player
			transform.LookAt(player);
			//Calculate distance between player
			float distance = Vector3.Distance(transform.position, player.position);
			//If the distance is smaller than the walkingDistance
			if(distance < walkingDistance)
			{
				//Move the enemy towards the player with smoothdamp
				transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
			}
		}
		else {
			anim.SetBool ("dead", true);
		}
	}
}