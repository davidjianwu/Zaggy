﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For ui shit
using UnityEngine.UI;
//For playagain button
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	//references to objects
	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;

	void Awake() {
		if(instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		highScore1.text = "High Score: " + PlayerPrefs.GetInt ("highScore");
	}

	public void GameStart() {
		//Removes taptext after starts
		tapText.SetActive (false);
		//Display zigzag panel animation
		zigzagPanel.GetComponent<Animator>().Play ("PanelUp");

	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt ("score").ToString ();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString ();
		//Animation gets played automatically when set to active
		gameOverPanel.SetActive (true);

	}

	//PlayAgain Button implementation
	public void PlayAgain() {
		SceneManager.LoadScene (0);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
