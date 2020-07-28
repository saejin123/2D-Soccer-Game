using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour {
	public Transform targetTransform;
	// Use this for initialization
	void Start () {
		
	}
	float speed = 2;
	// Update is called once per frame
	void Update () {
		if(targetTransform != null){
			Vector3 displacementFromTarget = targetTransform.position - transform.position;
			Vector3 directionToTarget = displacementFromTarget.normalized;
			Vector3 velocity = directionToTarget*speed;
			if(displacementFromTarget.magnitude < 3){
				transform.Translate(velocity*Time.deltaTime);
			}
		}
	}
}
