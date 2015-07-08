using UnityEngine;
using System.Collections;

public class EnemyAttacking : MonoBehaviour {

	float fireRate = 1f;
	public GameObject tempBullet;

	public enum FireMode{
		Simple, Burst, Automatic 
	}

	public FireMode fireMode = FireMode.Simple;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot(){

	}


}
