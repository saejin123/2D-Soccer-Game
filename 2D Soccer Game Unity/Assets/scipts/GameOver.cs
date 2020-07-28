﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
	bool gameOver;
	// Use this for initialization
	void Start () {
		FindObjectOfType<playerController> ().OnPlayerDeath += onGameOver; 
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver){
			if(Input.GetKeyDown(KeyCode.Space) == true){
				SceneManager.LoadScene(0);
			}
		}
	}
	void onGameOver(){
		gameOverScreen.SetActive(true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		gameOver = true;
	}
}
