using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController : MonoBehaviour {

	public float delayTime = 1.0f;
	public float speed = 1.0f;
	public Vector3 posA;
	public Vector3 posB;

	void Awake(){
		//GetComponent<MeshRenderer>().enabled = false;
	}

	void OnEnable(){
		GetComponentInChildren<MeshRenderer>().enabled = false;
		transform.position = new Vector3(transform.position.x, posA.y, transform.position.z);
		StartCoroutine("SpawnAnimation");
		StartCoroutine("VisibleOn");
	}

	IEnumerator SpawnAnimation(){
		yield return new WaitForSeconds(delayTime);
	
		float startTime = Time.time;

		while(posA != posB){
			transform.position = Vector3.Lerp(posA,posB, (Time.time - startTime) * speed);
		
			yield return 1;
		}
	}

	IEnumerator VisibleOn(){
		yield return new WaitForSeconds(1.0f);
		GetComponentInChildren<MeshRenderer>().enabled = true;
		
	}
}
