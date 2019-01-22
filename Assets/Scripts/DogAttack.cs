using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour {


	private GameObject[] targets;
	public Transform myTransform;
	private Animator anim;
	public Transform enemy;
	public float closeDistance = 0.5F;
	public bool isAttacking;


	void Start () {
		targets = GameObject.FindGameObjectsWithTag("Blood");
		anim = GetComponentInChildren<Animator> ();

	}
	

	void Update () {
		
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject target in targets) {
			if (target != null) {
				Vector3 diff = target.transform.position - position;
				float curDistance = diff.sqrMagnitude;
				if (curDistance < distance) {
					closest = target;
					distance = curDistance;
					enemy = closest.transform;
				}
			}
		}
			

		FollowPlayer follow = GetComponent<FollowPlayer> ();
		Vector3 enemyposition = enemy.transform.position;
			if (Input.GetKey (KeyCode.G)) {
				if (enemy) {
					follow.isFollowing = false;
					Vector3 offset = enemy.position - myTransform.position;
					float sqrLen = offset.sqrMagnitude;
					if (sqrLen < closeDistance * closeDistance) {
						myTransform.LookAt (enemy);
						anim.SetBool ("attack", true);
					NPCScript enemyHealth = enemy.GetComponent<Collider>().GetComponent<NPCScript>();
					if (enemyHealth != null) {
							enemyHealth.TakeDamage(enemyposition);
					}
					} else {
						anim.SetBool ("attack", false);
						myTransform.Translate (Vector3.forward * 8 * Time.deltaTime);
						myTransform.LookAt (enemy);
					}


				}
			}


	}
}





