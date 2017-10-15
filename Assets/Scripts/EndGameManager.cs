using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

	public Text finalSCore;

	void Start(){
		finalSCore.text = "Final Score: " + GameManager.instance.finalScore;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton7)){
			SceneManager.LoadScene("StartGameScene");
		}
	}
}
