using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text highscoreText;
	// Use this for initialization
	void Start () {
		highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetFloat ("Highscore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
