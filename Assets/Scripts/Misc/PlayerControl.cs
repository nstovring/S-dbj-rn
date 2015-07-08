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

	//private BulletPhysics bulletPhysics;
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
		/*
		if (playerPhysics.grounded) {
			amountToMove.y= 0;
			if(Input.GetButtonDown("Jump")){

				amountToMove.y = jumpHeight;

			}
				}
*/

		if (playerPhysics.atWall) {
			targetSpeed =0;
			currentspeed = 0;
				}

		amountToMove.x = currentspeed;
		amountToMove.y = currentspeedy;
		playerPhysics.Move (amountToMove * Time.deltaTime);
		direct = playerPhysics.getDirect(10);

	



		Counter += Time.deltaTime;
		Debug.Log (fireRate);
		if (Input.GetButton ("Fire1") && Counter > fireRate) {
			Counter = 0;
			Shoot ();


				}
	
		}
		

	private void Shoot(){

		GameObject bullet = Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		Destroy (bullet, 2);
	
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
