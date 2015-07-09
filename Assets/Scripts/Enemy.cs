﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 5;
	public float enemyDistance = 1;
	public FollowPath followPath;
	float timePassed;
	private bool enemyHit= false;
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
		followPath = GetComponent<FollowPath>();
		player = GameObject.FindGameObjectWithTag("Player");
		if(myType == MovementTypes.easy){
			//path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>();
			//followPath.Move(path);
		}
	}
	
	// Update is called once per frame
	float stayTime = 10;

	void Update () {
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
	//	gameObject.GetComponent<Material>().SetColor(Color.white);

		stayTime -= Time.deltaTime;
		if(stayTime <= 0 && !exited){
			ExitLevel();
		}

		LookAtPlayer();
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.right,out hit,enemyDistance) || Physics.Raycast(transform.position,-transform.right,out hit,enemyDistance)){
			if(hit.transform.tag == "Enemy"){
				followPath.Type = FollowPath.FollowType.Stop;
			}
		}else{
			followPath.Type = FollowPath.FollowType.MoveToward;
		}
		SineMove();
	}

	float i;
	void SineMove(){
		transform.position += new Vector3(0,Mathf.Sin(Time.deltaTime),0);
		i+= Time.deltaTime;
	}

	void LookAtPlayer(){
		var dir = player.transform.position - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

		//transform.rotation = new 
		//transform.LookAt(player.transform);
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
			if(health <= 0){
			Destroy(gameObject);
			}
		}
	}
