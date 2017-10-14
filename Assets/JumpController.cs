using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

	public float jumpHeight = 5.0f;
	public float jumpSpeed = 1.0f;
	public float jumpTime = 2.0f;
	public float jumpInterval = 2.0f;
	public float jumpIntervalChangeTime = 5.0f;

	float randomNumber = 0.0f;
	Rigidbody body;

	void Start(){
		body = GetComponent<Rigidbody>();		
		//StartCoroutine("Jump", jumpTime);
		//StartCoroutine("RandomlySetJumpInterval", jumpIntervalChangeTime);
		//StartCoroutine("JumpLoop");
	//	JumpBody();
		//StartCoroutine("Wait");
	}

	void Update(){
		
	}


	IEnumerator Jump(){
		while(jumpTime > 0.0f){
			transform.position += Vector3.up * jumpSpeed;
			jumpTime -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		yield return StartCoroutine("Fall");	
	}

	void JumpBody(){
		body.AddForce(transform.up * 100);
	}

	IEnumerator Fall(){
		while(jumpTime > 0.0f){
			transform.position += Vector3.down * jumpSpeed;
			jumpTime -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator RandomlySetJumpInterval(float time){
		while(true){
			yield return new WaitForSeconds(time);
			jumpInterval = Random.Range(0.5f, 5.0f);
		}
	}

	IEnumerator JumpLoop(){
		while(true){
			yield return new WaitForSeconds(jumpInterval);
			yield return StartCoroutine("Jump");
		}	
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(2.0f);
		JumpBody();
	}
}
