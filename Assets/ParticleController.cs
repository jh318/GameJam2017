using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	void OnEnable(){
		StartCoroutine("SetInactive");
	}

	IEnumerator SetInactive(){
		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
	}
}
