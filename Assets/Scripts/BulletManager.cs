using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour
{
	public enum fireModes{
		semi, full, shotgun
	}
	public fireModes fireMode;
	float Counter;
	public float fireRate = 0.15f;
	public GameObject Bullet;
	private bulletPhysics bulletPhysics;
	public Transform bulletSpawn;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	public int fullSpeed = 5;
	float time = 0;
	int roundTime;
	bool lastShot = true;
	public float bulletSpeed = 0;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		time += Time.deltaTime*fullSpeed;
		roundTime = Mathf.RoundToInt(time);
		if (fireMode == fireModes.semi) {
			semi ();
		}
		if (fireMode == fireModes.full) {
			full();
		}
		if (fireMode == fireModes.shotgun) {
			shotgun();
		}

			
		}



	private void semi(){

		if (Input.GetButtonDown ("Fire1") /*&& Counter > fireRate*/) {
			GameObject clone = Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		}
	}
	private void full(){
		Counter += Time.deltaTime;
		if (Input.GetButton ("Fire1") && roundTime > time) {

			if(roundTime %2 ==1 && lastShot == true){
			GameObject clone = Instantiate (Bullet, bulletSpawn1.position, bulletSpawn.rotation)as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (transform.up *bulletSpeed*100);
				lastShot = false;
			}
			if(roundTime %2 == 0 && lastShot == false){
			GameObject clone1 = Instantiate (Bullet, bulletSpawn2.position, bulletSpawn.rotation)as GameObject;
			clone1.GetComponent<Rigidbody> ().AddForce (transform.up *bulletSpeed*100);
				lastShot = true;
			}
			}
		}

	private void shotgun (){
		Counter += Time.deltaTime;
		if (Input.GetButtonDown ("Fire1") && Counter > fireRate){
			GameObject clone = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (new Vector3(.7f, 1,0) *300);
			clone.transform.Rotate(0,0,-30);
			GameObject clone1 = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone1.GetComponent<Rigidbody> ().AddForce (new Vector3(-.7f, 1,0) *300);
			clone1.transform.Rotate(0,0,30);
			GameObject clone2 = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone2.GetComponent<Rigidbody> ().AddForce (new Vector3(0, 1,0) *500);
			Counter = 0;

		}
	}


	
}