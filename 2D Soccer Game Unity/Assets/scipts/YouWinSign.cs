using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWinSign : MonoBehaviour {

	public GameObject YouWinText;
	public Text secondsSurvivedUI;
	bool youWin;
	// Use this for initialization
	void onYouWin(){
		YouWinText.SetActive(true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		youWin = true;
	}
	void Start () {
		FindObjectOfType<playerController> ().OnGoal += onYouWin;
	} 
	
	// Update is called once per frame
	void Update () {
		if(youWin){
			if(Input.GetKeyDown(KeyCode.Space) == true){
				SceneManager.LoadScene(0);
			}
		}
	}

}
