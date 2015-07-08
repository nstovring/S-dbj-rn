﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	int health = 5;
	public FollowPath followPath;
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

	private p path;
	void Start () {
		followPath = GetComponent<FollowPath>();

		if(myType == MovementTypes.easy){
			//path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>();
			//followPath.Move(path);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Bullet"){
			Destroy(gameObject);
		}
	}
}
