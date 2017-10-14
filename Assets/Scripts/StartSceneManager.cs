using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("MainGameScene");
		}
	}
}
