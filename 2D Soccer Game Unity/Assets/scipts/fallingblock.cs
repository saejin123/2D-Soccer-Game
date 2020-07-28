using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingblock : MonoBehaviour {
	float speed;
	float visibleHeightThreshold;
	public Vector2 speedMinMax;
	// Use this for initialization
	void Start () {
		speed = Mathf.Lerp(speedMinMax.x,speedMinMax.y,difficulty.GetDifficultyPercent()); // linear interpolation: we do .x to .y because we want the speed to increase
		visibleHeightThreshold = -Camera.main.orthographicSize-transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down*speed*Time.deltaTime,Space.Self);
		if(transform.position.y < visibleHeightThreshold){
			Destroy(gameObject);
		}
	}
}
