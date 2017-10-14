using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagController : MonoBehaviour {

	public float angle = 30.0f;
	public float zigZagSpeed = 1.0f;
	bool leftRight = true;
	Rigidbody body;

	void Start(){
		body = GetComponent<Rigidbody>();
		StartCoroutine("ZigZagLane", 10.0f);
	}

	void Update(){
		// if(leftRight){
		// 	transform.position = new Vector3(transform.position.x + zigZagSpeed, transform.position.y, transform.position.z);
		// 	Debug.Log("Going Right");
		// }
		// else if(!leftRight){
		// 	transform.position = new Vector3(-zigZagSpeed, transform.position.y, transform.position.z);
		// 	Debug.Log("Going Left");
		// } 
		// if(transform.position.x >= 10){
		// 	StopCoroutine("ZigZagLane");
		// 	StartCoroutine("ZigZagLane", 99.0f);
		// }
		// else if(transform.position.x <= 10){
		// 	zigZagSpeed *= -1;
		// 	StopCoroutine("ZigZagLane");
		// 	StartCoroutine("ZigZagLane", 99.0f);
		// }

	}

	IEnumerator ZigZag(){
		while(true){
			body.velocity = Vector3.right * zigZagSpeed;
			leftRight = false;
			yield return new WaitForSeconds(3.0f);
			body.velocity = Vector3.right * -zigZagSpeed;
			leftRight = true;
		}	
	}

	IEnumerator ZigZagLane(float time){
		while(time > 0.0f){
			transform.position += Vector3.right * zigZagSpeed;
			time -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}
