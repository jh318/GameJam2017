using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnEnable(){
		Shooting.instance.currShotCount++;
		GameManager.instance.UpdateShot(-1);
	}

	void OnDisable(){
		Shooting.instance.currShotCount--;
		GameManager.instance.UpdateShot(1);		
	}
}
