using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int lives = 3;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		
		DontDestroyOnLoad(gameObject);
	}

	void OnEnable(){
		killboxcontroller.enemyPassedLine += OnEnemyPassedLine;
	}

	void OnEnemyPassedLine(int lifeDamage){
		Debug.Log("OnEnemyPassedLine");
		lives -= lifeDamage;
		if(lives <= 0){
			Debug.Log("Out of Lives");
			StartCoroutine("EndGame");
		}
	}

	IEnumerator EndGame(){
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("EndGameScene");
	}
}
