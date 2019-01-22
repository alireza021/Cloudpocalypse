using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour {

	public Transform[] Waypoints;
	public float speed;
	public int curWaypoint;
	public bool doPatrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;

	private Animator anim;

	void Start () {
		anim = GetComponentInChildren<Animator> ();

	}

	void Update () {
		NPCScript npc = GetComponent<NPCScript>();
		if (npc.dead == false) {
			if (curWaypoint < Waypoints.Length) {
				Target = Waypoints [curWaypoint].position;
				MoveDirection = Target - transform.position;
				Velocity = GetComponent<Rigidbody> ().velocity;

				if (MoveDirection.magnitude < 1) {
					curWaypoint++;
				} else {
					Velocity = MoveDirection.normalized * speed;
				}
			} else {
				if (doPatrol) {
					curWaypoint = 0;
				} else {
					Velocity = Vector3.zero;
				}
			}
			GetComponent<Rigidbody> ().velocity = Velocity;
			transform.LookAt (Target);
		} else {
			anim.SetBool ("dead", true);
		}
	}
}
