using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour
{
	public enum fireModes{
		semi, full, shotgun
	}
	public fireModes fireMode;
	float Counter;
	public float fireRate = 0.25f;
	public GameObject Bullet;
	private bulletPhysics bulletPhysics;
	public Transform bulletSpawn;
	public Transform bulletSpawn1;
	public Transform bulletSpawn2;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
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
		if (Input.GetButton ("Fire1") && Counter > fireRate) {
			GameObject clone = Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (transform.up *500);
			Counter = 0;
			}
		}

	private void shotgun (){
		if (Input.GetButtonDown ("Fire1") ){
			GameObject clone = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone.GetComponent<Rigidbody> ().AddForce (new Vector3(.7f, 1,0) *500);
			clone.transform.Rotate(0,0,-30);
			GameObject clone1 = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone1.GetComponent<Rigidbody> ().AddForce (new Vector3(-.7f, 1,0) *500);
			clone1.transform.Rotate(0,0,30);
			GameObject clone2 = Instantiate(Bullet, bulletSpawn.position,bulletSpawn.rotation) as GameObject;
			clone2.GetComponent<Rigidbody> ().AddForce (new Vector3(0, 1,0) *500);

		}
	}

	private float IncrementTowards (float n, float target, float a)
	{
		if (n == target) {
			return n;
		} else {
			float dir = Mathf.Sign (target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target;
			
		}
	}
	
}