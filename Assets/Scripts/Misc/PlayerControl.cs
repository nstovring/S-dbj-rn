using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject Player;
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public float fireRate;

	private float currentspeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	public GameObject Bullet;
	public Transform bulletSpawn;

//	private BulletPhysics bulletPhysics;
	private PlayerPhysics playerPhysics;
	float direct;

	// Use this for initialization
	void Start () {

	//	bulletPhysics = GetComponent <BulletPhysics> ();
		playerPhysics = GetComponent <PlayerPhysics> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 playerPos = Player.transform.position;
		Debug.Log (playerPos);
	
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentspeed = IncrementTowards (currentspeed, targetSpeed, acceleration);

		if (playerPhysics.grounded) {
			amountToMove.y= 0;
			if(Input.GetButtonDown("Jump")){

				amountToMove.y = jumpHeight;

			}
				}

		if (playerPhysics.atWall) {
			targetSpeed =0;
			currentspeed = 0;
				}

		amountToMove.x = currentspeed;
		amountToMove.y -= gravity *Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
		direct = playerPhysics.getDirect(10);

	



		float nextFire = 0.0f;
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Shoot ();

				}
	
		}
		

	private void Shoot(){

		GameObject clone = Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		if (direct > 0) {
						clone.GetComponent<Rigidbody>().AddForce (clone.transform.right * 1500);
				} else {
			clone.GetComponent<Rigidbody>().AddForce (clone.transform.up * 1500);
				}
		Destroy (clone, 2);
	
		}


		private float IncrementTowards(float n, float target, float a)
		{
			if (n == target){
				return n;
			}
			else {
				float dir = Mathf.Sign(target - n);
				n += a * Time.deltaTime * dir;
				return (dir == Mathf.Sign(target-n))? n: target;

			}
		}
	
}
