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
	}

	void SimpleFire(){
		timePassed += Time.deltaTime;
		if(timePassed> fireRate){
		Shoot();
		timePassed = 0;
		}
	}

/*	void SimpleFire(){
		timePassed += Time.deltaTime;
		if(timePassed> fireRate){
			Shoot();
			timePassed = 0;
		}
	}
*/
	void Shoot(){
		//GameObject clone;
		GameObject clone = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		clone.GetComponent<Rigidbody>().AddForce(0,-bulletSpeed*100,0);
	}


}
