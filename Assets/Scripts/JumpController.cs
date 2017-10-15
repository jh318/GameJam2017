using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {

	public float jumpForce = 1000.0f;
	public float jumpInterval = 2.0f;

	float randomNumber = 0.0f;
	Rigidbody body;

	void OnDisable(){
		AudioManager.PlayEffect("smb_mariodie");
	}

	void Start(){
		body = GetComponent<Rigidbody>();
		StartCoroutine("JumpLoop");
	}	

	void Jump(){
		AudioManager.PlayEffect("smbJump");
		body.AddForce(transform.up * jumpForce);
	}

	IEnumerator JumpLoop(){
		while(true){
			yield return new WaitForSeconds(jumpInterval);
			Jump();
		}	
	}

	IEnumerator RandomlySetJumpInterval(float time){
		while(true){
			yield return new WaitForSeconds(time);
			jumpInterval = Random.Range(0.5f, 5.0f);
		}
	}
}
