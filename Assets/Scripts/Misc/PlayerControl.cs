using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject Player;
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public float Counter;
	public float fireRate = 0.25f;
	private float targetSpeedY;


	private float currentspeed;
	private float currentspeedy;
	private float targetSpeed;
	private Vector2 amountToMove;

	public GameObject Bullet;
	public Transform bulletSpawn;

	public GameController gameController;
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

		targetSpeedY = Input.GetAxis ("Vertical") * speed;
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentspeed = IncrementTowards (currentspeed, targetSpeed, acceleration);
		currentspeedy = IncrementTowards (currentspeedy, targetSpeedY, acceleration);

				
		amountToMove.x = currentspeed;
		amountToMove.y = currentspeedy;
		playerPhysics.Move (amountToMove * Time.deltaTime);

	



		Counter += Time.deltaTime;
		Debug.Log (fireRate);
		if (Input.GetButton ("Fire1") && Counter > fireRate) {
			Counter = 0;
			Shoot ();


				}
	
		}

	void OnCollisionEnter(Collision c)
	{
		if (c.transform.tag == "Enemy") {
			gameController.subractLife();
		}
	}
		

	private void Shoot(){


		GameObject clone = Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;

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
