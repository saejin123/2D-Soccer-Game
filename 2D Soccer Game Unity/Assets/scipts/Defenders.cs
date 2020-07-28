using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	public Transform targetTransform;
	float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range(1,3);
	}
	
	// Update is called once per frame
	void Update () {
		if(targetTransform != null){
			Vector3 displacementFromTarget = targetTransform.position - transform.position;
			Vector3 directionToTarget = displacementFromTarget.normalized;
			Vector3 velocity = directionToTarget*speed;
			transform.Translate(velocity*Time.deltaTime);
		}
	}
}
