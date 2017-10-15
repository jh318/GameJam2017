using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostColor : MonoBehaviour {



	void Start(){
		GetComponentInChildren<Renderer>().material.color = new Color(Random.Range(0.0f,2.0f), Random.Range(0.0f,2.0f),Random.Range(0.0f,2.0f),Random.Range(0.0f,2.0f));
	}
}
