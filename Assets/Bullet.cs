using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnEnable(){
		Shooting.instance.currShotCount++;
	}

	void OnDisable(){
		Shooting.instance.currShotCount--;
	}
}
