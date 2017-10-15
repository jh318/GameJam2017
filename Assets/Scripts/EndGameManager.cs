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
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("StartGameScene");
		}
	}
}
