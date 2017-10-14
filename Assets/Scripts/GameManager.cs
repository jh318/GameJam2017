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
	public string restoreLifeScene = "";

    public Text scoreText;
    public int score;

    public Text livesText;


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
  
        score = 0;
        UpdateScore();

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
		GameObject hud = GameObject.Find("HUD");			
		scoreText = hud.transform.FindChild("Score").GetComponent<UnityEngine.UI.Text>();
		livesText = hud.transform.FindChild("Lives").GetComponent<UnityEngine.UI.Text>();
		SceneManager.sceneLoaded += SceneLoaded;
		Debug.Log("MAINSCENELOAD");
		if(scene.name == "MainGameScene"){
			RestoreLivesToMax();
			StartCoroutine("FindHud");
			killboxcontroller.enemyPassedLine += OnEnemyPassedLine;
		}

		

		//GameObject hudScore = GameObject.Find("Score");
		//scoreText = hudScore.GetComponent<Text>();
		//UpdateScore();


	//	GameObject hudLives = GameObject.Find("Lives");
		//livesText = hudLives.GetComponent<Text>();
		//UpdateLives();
	}

	IEnumerator FindHud(){
		yield return new WaitForSeconds(1.0f);
		GameObject hud = GameObject.Find("HUD");			
		scoreText = hud.transform.FindChild("Score").GetComponent<UnityEngine.UI.Text>();
		livesText = hud.transform.FindChild("Lives").GetComponent<UnityEngine.UI.Text>();
	}

	void RestoreLivesToMax(){
		lives = startLives;
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
    void UpdateLives()
    {
	    livesText.text = "Lives:" + lives;
    }
}
