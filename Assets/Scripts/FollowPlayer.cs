using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform myTransform;
	public Transform target;
	public float closeDistance = 2.0F;
	public bool isFollowing;


	void Start () {
	}

	void Update() {
		if (Input.GetKeyDown ("e")) {
			isFollowing = !isFollowing;
		}

		if(isFollowing){
			if (target) {
				Vector3 offset = target.position - transform.position;
				float sqrLen = offset.sqrMagnitude;
				if (sqrLen < closeDistance * closeDistance) {
					transform.LookAt (target);
				} else {
					transform.Translate (Vector3.forward * 5 * Time.deltaTime);
					transform.LookAt (target);
				}
		
			}
			}
		
}
}