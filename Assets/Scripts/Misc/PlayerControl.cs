using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public GameObject Player;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	public float fireRate = 0.25f;
	private float targetSpeedY;
	private float currentspeed;
	private float currentspeedy;
	private float targetSpeed;
	private Vector2 amountToMove;
	private bool playerHit = false;
	public Animator anim;
	Animator shipAnim;

	public BulletManager bulletManager;
	public GameController gameController;
	private PlayerPhysics playerPhysics;
	public float timePassed= 0;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponentInChildren<Animator> ();
		shipAnim = GetComponent<Animator>();

		//	bulletPhysics = GetComponent <BulletPhysics> ();
		playerPhysics = GetComponent <PlayerPhysics> ();

	
	}
	
	// Update is called once per frame
	public Quaternion rotation = Quaternion.identity;
	void Update ()
	{

		Vector3 playerPos = Player.transform.position;
		targetSpeedY = Input.GetAxisRaw ("Vertical") * speed;
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		amountToMove.y = targetSpeedY;
		amountToMove.x = targetSpeed;
		playerPhysics.Move (amountToMove * Time.deltaTime);

		if (targetSpeedY >= 0.1f) {
			anim.SetInteger ("JetState", 0);
		} 
		if (targetSpeedY == 0) {
			anim.SetInteger ("JetState", 1);
		} 
		if(targetSpeedY <=-0.1f) {
			anim.SetInteger("JetState", 2);
		}

		if(targetSpeed >= 0.1f){
			shipAnim.SetInteger("Skew", 1);
			//Change sprite
		}else if(targetSpeed<= -0.1f){
			//Change sprite
			shipAnim.SetInteger("Skew", 2);
		}else{
			shipAnim.SetInteger("Skew", 0);
		}

		if (playerHit) {
			timePassed += Time.deltaTime;
			if (timePassed < .5f && timePassed > 0) {
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
			} else {
				timePassed = 0;
				playerHit = false;
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.white;
			}
			
		}

	



	
	
	}

	void OnCollisionEnter (Collision c)
	{
		if (c.transform.tag == "Enemy" || c.transform.tag == "enemyBullet") {
//			gameController.subractLife ();
			playerHit = true;
		
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
