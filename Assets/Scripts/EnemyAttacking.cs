using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttacking : MonoBehaviour {

	public Text lives;
	public float fireRate = 1f;
	public float bulletSpeed = 1;
	float timePassed;
	public Transform bulletSpawn;
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
		if(fireMode == FireMode.Simple){
				SimpleFire();
		}
		if(fireMode == FireMode.Burst){
			Burst ();
		}
	}

	void SimpleFire(){
		timePassed += Time.deltaTime;
		if(timePassed> fireRate){
		Shoot();
		timePassed = 0;
		}
	}
	float IntervalPassed = 0f;
	float burstFireRate = 2;
	int shots = 4;

	void Burst(){
		float burstInterval = 0.2f;
		timePassed += Time.deltaTime;
		//Debug.Log (shots);
		if(timePassed> burstFireRate){
			IntervalPassed +=Time.deltaTime;
			//Debug.Log(IntervalPassed);
			if(IntervalPassed> burstInterval){
			shots--;
			Shoot();
			IntervalPassed = 0;
			}
			if(shots<= 0){
			timePassed = 0;
			shots = 4;
			}
		}
	}

	void Shoot(){
		//GameObject clone;
		GameObject clone = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		//transform.TransformDirection()
		//clone.GetComponent<Rigidbody>().AddForce(0,-bulletSpeed*100,0);
		clone.GetComponent<Rigidbody>().AddForce(-transform.up * 100* bulletSpeed);

	}


}
