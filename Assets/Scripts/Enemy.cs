﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 5;
	public float enemyDistance = 1;
	public FollowPath followPath;
	float timePassed;
	private bool enemyHit= false;
    public Sprite newSprite; 
	private SpriteRenderer spriteRenderer;
	public GameObject Explosion;
	// Use this for initialization

	public enum MovementTypes{
		Clamp,
		Horizontal,
		Vertical,
		ZigZag,
		Waiting,
		easy
	}

	public MovementTypes myType = MovementTypes.easy;
	private GameObject player;
	private p path;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		followPath = GetComponent<FollowPath>();
		player = GameObject.FindGameObjectWithTag("Player");
		if(myType == MovementTypes.easy){
			//path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>();
			//followPath.Move(path);
		}
	}
	
	// Update is called once per frame
	public void ColorChange(){
		if(enemyHit){
			timePassed += Time.deltaTime;
			if(timePassed < .5f && timePassed > 0){
				gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
			}
			else{
				timePassed = 0;
				enemyHit = false;
				gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
			}
		}
	}

	float stayTime = 10;

	void Update () {
	//	gameObject.GetComponent<Material>().SetColor(Color.white);
		ColorChange();
		stayTime -= Time.deltaTime;
		if(stayTime <= 0 && !exited){
			ExitLevel();
		}
		//LookAtPlayer();
		SineMove();
	}

	float i;
	float amplitude = 0.3f;
	float frequency = 0.3f;
	void SineMove(){
		//transform.position += new Vector3(0,Mathf.Sin(Time.deltaTime),0);
		i+= Time.deltaTime;

		transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;
	}

	void LookAtPlayer(){
		var dir = player.transform.position - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}

	bool exited = false;
	public void ExitLevel(){
		p path = GameObject.FindGameObjectWithTag("exitPath").GetComponent<p>();
		followPath.Move(path);
		exited = true;
	}


	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Bullet"){
			enemyHit = true;
			}
			health--;
		if (health == 4 && health > 3) {
			spriteRenderer.sprite = newSprite;
		}
		if (health <= 3) {

		}
			if(health <= 0){
			GameObject Ex = Instantiate(Explosion, transform.position, transform.rotation)as GameObject;
			Destroy(gameObject);
			Destroy (Ex, 0.5f);
			}
		}
	}
