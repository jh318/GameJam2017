using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public string nameOfObjectToSpawn;
	public float spawnRadius;
	public float spawnTime;
	public float offsetY = 0.0f;

	void Start(){
		//StartCoroutine("SpawnCoroutine");
	}

	void OnEnable(){
		StartCoroutine("SpawnCoroutine");
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, spawnRadius);
	}

	IEnumerator SpawnCoroutine(){
		while(enabled){
			yield return new WaitForEndOfFrame();
			//EnemyController enemy = SpawnEnemy();
			GameObject enemy = Spawner.Spawn(nameOfObjectToSpawn);
			enemy.transform.position = transform.position + (Vector3)Random.insideUnitSphere * spawnRadius;
			enemy.transform.position = new Vector3(enemy.transform.position.x, offsetY, enemy.transform.position.z);
			yield return new WaitForSeconds(spawnTime);
		}
	}
}
