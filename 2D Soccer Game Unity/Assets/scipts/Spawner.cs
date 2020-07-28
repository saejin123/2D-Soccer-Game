using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;
	Vector2 screenHalfSizeWorldUnits;
	public Vector2 spawnSizeMinMax;
	public float spawnAnglemax;
	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect*Camera.main.orthographicSize, Camera.main.orthographicSize);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawnTime){
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y,secondsBetweenSpawnsMinMax.x, difficulty.GetDifficultyPercent()); // Interpolation for the difficulty of the game, we got .y to .x because we want to go from a longer spawn time to a shorter spawn time to increase the difficutly
			// print(secondsBetweenSpawns); 
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			float spawnAngle; 
			float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);	
			float left_or_right = Random.Range(0,2);
			if(left_or_right < 0.5){
				Vector2 spawnposition = new Vector2(-screenHalfSizeWorldUnits.x,Random.Range(-screenHalfSizeWorldUnits.y+spawnSize,screenHalfSizeWorldUnits.y+spawnSize));
				spawnAngle = Random.Range(0,spawnAnglemax);
				GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab,spawnposition,Quaternion.Euler(Vector3.forward*spawnAngle)); // quaternion.identity means that there is no rotation
				newBlock.transform.localScale = Vector2.one*spawnSize;
			}
			else{
				Vector2 spawnposition = new Vector2(screenHalfSizeWorldUnits.x,Random.Range(-screenHalfSizeWorldUnits.y+spawnSize,screenHalfSizeWorldUnits.y+spawnSize));
				spawnAngle = Random.Range(-spawnAnglemax,0);
				GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab,spawnposition,Quaternion.Euler(Vector3.forward*spawnAngle)); // quaternion.identity means that there is no rotation
				newBlock.transform.localScale = Vector2.one*spawnSize;
			}
			
		}
	}

}
