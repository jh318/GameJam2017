using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int startLives = 3;
	[HideInInspector]
	public int lives = 3;
	public string restoreLifeScene = "";

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
	}

	void OnEnable(){
		killboxcontroller.enemyPassedLine += OnEnemyPassedLine;
		SceneManager.sceneLoaded += SceneLoaded;
	}

	void OnDisable(){
		killboxcontroller.enemyPassedLine -= OnEnemyPassedLine;		
		SceneManager.sceneLoaded -= SceneLoaded;
	}

	void Start(){
		lives = startLives;
	}

	void OnEnemyPassedLine(int lifeDamage){
		Debug.Log("OnEnemyPassedLine");
		lives -= lifeDamage;
		Debug.Log("Life Count: " + lives);
		if(lives <= 0){
			Debug.Log("Out of Lives");
			StartCoroutine("EndGame");
		}
	}

	IEnumerator EndGame(){
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("EndGameScene");
		StopAllCoroutines();
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log("MAINSCENELOAD");
		if(scene.name == restoreLifeScene){
			RestoreLivesToMax();
		}
	}

	void RestoreLivesToMax(){
		lives = startLives;
	}
}
