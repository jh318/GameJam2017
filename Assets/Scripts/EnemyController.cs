using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed = 1.0f;

	void Start(){
		Transform transform = GetComponent<Transform>();
	}

	void Update(){
		transform.position += Vector3.forward * -speed;
	}
}
