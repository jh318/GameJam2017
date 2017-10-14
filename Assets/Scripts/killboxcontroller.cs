using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killboxcontroller : MonoBehaviour {


	public delegate void EnemyPassedLine(int lives);
	public static event EnemyPassedLine enemyPassedLine = delegate{};

	void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Enemies"){
			enemyPassedLine(1);
			c.gameObject.SetActive(false);
		}
		else if(c.gameObject.tag == "Bullet"){
			Debug.Log("bullet touched killbox");
			c.gameObject.SetActive(false);
		}
	}
}
