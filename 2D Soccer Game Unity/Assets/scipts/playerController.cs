using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float speed = 4;
	public event System.Action OnPlayerDeath;
	public event System.Action OnGoal;
	public float screenhalfwidth;
	public GameObject goalkeepers;
	Vector2 velocity;
	//Rigidbody myRigidbody;
	float halfplayerwidth;
	// Use this for initialization
	void Start () {
		//myRigidbody = GetComponent<Rigidbody2D> ();
		halfplayerwidth = transform.localScale.x/2f;
		screenhalfwidth = Camera.main.aspect*Camera.main.orthographicSize-halfplayerwidth; // orthographicsize is screen height/2
	}
	 
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		Vector2 input = new Vector2(inputX,inputY);
		Vector2 direction = input.normalized;
		velocity = direction*speed;
		transform.Translate(velocity*Time.deltaTime);
		if(transform.position.x <= -screenhalfwidth){ // this is bad bc if you change the size of the game camera you would always have to update this -> very inefficent -> can do this now since the variable is set to the main camera's settings
			transform.position = new Vector2(-screenhalfwidth, transform.position.y);
		}
		if(transform.position.x >= screenhalfwidth){
			transform.position = new Vector2(screenhalfwidth, transform.position.y);
		}

		if(transform.position.y <= -Camera.main.orthographicSize+halfplayerwidth){
			transform.position = new Vector2(transform.position.x,-Camera.main.orthographicSize+halfplayerwidth);
		}

		if(transform.position.y >= Camera.main.orthographicSize-halfplayerwidth){
			transform.position = new Vector2(transform.position.x,Camera.main.orthographicSize-halfplayerwidth);
		}

	}
	void OnTriggerEnter(Collider triggerCollider){ // called automatically by the physics engine
		if(triggerCollider.tag == "Falling Block"){
			// FindObjectOfType<GameOver> ().onGameOver(); // kinda strange to have this here so the soln is an event
			if(OnPlayerDeath != null){
				OnPlayerDeath();
			}
			Destroy (gameObject);
		}
		if(triggerCollider.tag == "GoalLine"){
			if(OnGoal != null){ // change this to "you win"
				OnGoal();
		}
			Destroy (gameObject);
		}
	}
	//void FixedUpdate(){
	//	myRigidbody.position = velocity*Time.fixedDeltaTime;
	//}
}
