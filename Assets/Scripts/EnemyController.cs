using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float forwardSpeed = 1.0f;
	public float sideSpeed = 1.0f;
	public float sideTime = 1.0f;
	public float randomNumberRollSeconds = 3.0f;
	public float leftClamp = -10.0f;
	public float rightClamp = 10.0f;

	int randomNumber = 0;

	void Start(){
		Transform transform = GetComponent<Transform>();
		StartCoroutine("RandomNumberGenerator", randomNumberRollSeconds);
	}

	void Update(){
		transform.position += Vector3.forward * -forwardSpeed;

		if(randomNumber == 1){
			randomNumber = 0;
			StopCoroutine("SwitchLane");				
			StartCoroutine("SwitchLane", sideTime);
		}
		else if(randomNumber == 2){
			randomNumber = 0;
			sideSpeed = sideSpeed * -1;
			StopCoroutine("SwitchLane");	
			StartCoroutine("SwitchLane", sideTime);	
		}

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftClamp, rightClamp), transform.position.y, transform.position.z);
	}

	IEnumerator SwitchLane(float time){
		while(time > 0.0f){
			transform.position += Vector3.right * sideSpeed;
			time -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator RandomNumberGenerator(float time){
		while(true){
			yield return new WaitForSeconds(time);
			randomNumber = Random.Range(0, 3);
			Debug.Log(randomNumber);
		}
	}
}
