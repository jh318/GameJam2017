using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killboxcontroller : MonoBehaviour {


	public delegate void EnemyPassedLine(int lives);
	public static event EnemyPassedLine enemyPassedLine = delegate{};

	void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Enemies"){
			Debug.Log("Enemy touched killbox");
			enemyPassedLine(1);
		}
	}
}
