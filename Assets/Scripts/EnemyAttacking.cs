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

	void Burst(){
		float burstFireRate = 3;
		float burstInterval = 0.1f;
		float IntervalPassed = 0f;
		int shots = 4;
		timePassed += Time.deltaTime;
		if(timePassed> burstFireRate){
			IntervalPassed +=Time.deltaTime;
			if(timePassed> burstInterval){
			Shoot();
			IntervalPassed = 0;
				shots--;
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
