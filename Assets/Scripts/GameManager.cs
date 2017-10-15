using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int startLives = 3;
	[HideInInspector]
	public int lives = 3;

    public Text scoreText;
    public int score;

    public Text livesText;
	public Text shotText;
	public Text gameOverText;

	[HideInInspector]
	public int maxShot = 20;
	[HideInInspector]
	public int currShot = 0;
	[HideInInspector]
	public int finalScore = 0;

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
		SceneManager.sceneLoaded += SceneLoaded;
		killboxcontroller.enemyPassedLine += OnEnemyPassedLine;
	}

	void OnDisable(){
	}

	void Start(){
		lives = startLives;
        score = 0;
        UpdateScore();
		currShot = maxShot;
		UpdateShot(0);
    }

	void Update(){
		if(lives <= 0){
			GameOver();
			Debug.Log("Out of Lives");
			StartCoroutine("EndGame");
		}
	}

	void OnEnemyPassedLine(int lifeDamage){
		Debug.Log("OnEnemyPassedLine");
		Debug.Log("Life Count: " + lives);
		MinusLives(1);
		// if(lives <= 0){
		// 	GameOver();
		// 	Debug.Log("Out of Lives");
		// 	StartCoroutine("EndGame");
		// }
	}

	IEnumerator EndGame(){
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("EndGameScene");
		StopAllCoroutines();
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode){
		currShot = maxShot;
		lives = startLives;
		GameObject hud = GameObject.Find("HUD");			
		scoreText = hud.transform.FindChild("Score").GetComponent<UnityEngine.UI.Text>();
		livesText = hud.transform.FindChild("Lives").GetComponent<UnityEngine.UI.Text>();
		shotText = hud.transform.FindChild("Shots").GetComponent<UnityEngine.UI.Text>();
		gameOverText = hud.transform.FindChild("GameOver").GetComponent<UnityEngine.UI.Text>();
		gameOverText.gameObject.SetActive(false);
		
		score = 0;
		currShot = 20;
		UpdateShot(0);
		UpdateScore();
		UpdateLives();
		Debug.Log("MAINSCENELOAD");
		//StartCoroutine("RestoreLivesCoroutine");
		
		if(scene.name == "MainGameScene"){
		
		}

		if(scene.name == "EndGameScreen"){

		}
	}

	IEnumerator FindHud(){
		yield return new WaitForSeconds(1.0f);
		GameObject hud = GameObject.Find("HUD");			
		scoreText = hud.transform.FindChild("Score").GetComponent<UnityEngine.UI.Text>();
		livesText = hud.transform.FindChild("Lives").GetComponent<UnityEngine.UI.Text>();
		shotText = hud.transform.FindChild("Shots").GetComponent<UnityEngine.UI.Text>();
	}

	void RestoreLivesToMax(){
		lives = 3;
        UpdateLives();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
		finalScore = score;
    }

    public void MinusLives(int newLives)
    {
        lives -= newLives;
        UpdateLives();
    }
    public void AddLives(int newLives)
    {
        lives += newLives;
        UpdateLives();
    }
    public void UpdateLives()
    {
		if(lives >= 0) livesText.text = "Lives: " + lives;
    }
	public void UpdateShot(int shotNum)
    {
		currShot += shotNum;
	    shotText.text = "Shots: " + currShot;
    }

	public void GameOver()
    {
		gameOverText.gameObject.SetActive(true);
    }
}
