using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	void Update () {

		HealthBar health = GameObject.Find ("Player").GetComponent<HealthBar> ();
		if (Input.GetKeyDown (KeyCode.Escape) && health.currentHealth != 0) {
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
				GameObject.Find ("Player").GetComponentInChildren<PlayerShooting> ().enabled = false;
				Camera.main.GetComponent<CameraScript> ().enabled = false;
				Cursor.visible = true;
				AudioListener.pause = true;

			} else {
				GameObject.Find ("Player").GetComponentInChildren<PlayerShooting> ().enabled = true;
				canvas.gameObject.SetActive (false);
				Camera.main.GetComponent<CameraScript> ().enabled = true;
				Cursor.visible = false;
				Time.timeScale = 1;
				AudioListener.pause = false;
			}
		
		}
	}
}
