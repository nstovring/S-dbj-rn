using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public GameObject Player;
	public GameObject Shield;
	public Sprite shieldAvailableS; 
	public Sprite Standard;
	public float speed = 8;
	public float fireRate = 0.25f;
	private float targetSpeedY;
	private float currentspeed;
	private float currentspeedy;
	private float targetSpeed;
	private Vector2 amountToMove;
	private SpriteRenderer spriteRenderer;
	private bool playerHit = false;
	public Animator anim;
	//public PickUps pickUP;
	Animator shipAnim;
	bool shieldAvailable;

	public BulletManager bulletManager;
	public GameController gameController;
	private PlayerPhysics playerPhysics;
	public float timePassed= 0;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		//anim = GetComponentInChildren<Animator> ();
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

		transform.position += new Vector3(targetSpeed,targetSpeedY,0) * Time.deltaTime;
		amountToMove.y = targetSpeedY;
		amountToMove.x = targetSpeed;

		if (targetSpeedY >= 0.1f) {
			anim.SetInteger ("JetState", 1);
		} 
		if (targetSpeedY == 0) {
			anim.SetInteger ("JetState", 0);
		} 
		if(targetSpeedY <=-0.1f) {
			anim.SetInteger("JetState", 2);
		}
		if(targetSpeed >= 0.1f){
			rotation.eulerAngles = new Vector3(0,0,-15);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f );
		}else if(targetSpeed<= -0.1f){
			rotation.eulerAngles = new Vector3(0,0,15);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  0.1f );
		}else{
			rotation.eulerAngles = new Vector3(0,0,0);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  0.1f );
		}

		if (playerHit) {
			timePassed += Time.deltaTime;
			if (timePassed < .5f && timePassed > 0) {
				//gameController.subractLife();
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
			} else {
				timePassed = 0;
				playerHit = false;
				gameObject.GetComponent<SpriteRenderer> ().material.color = Color.white;
			}
			
		}
		if (shieldAvailable == true) {
			spriteRenderer.sprite = shieldAvailableS;
		} else {
			spriteRenderer.sprite = Standard;
		}
		if (Input.GetKeyDown(KeyCode.Space)&& shieldAvailable == true) {
			GameObject sh = Instantiate( Shield, transform.position, transform.rotation)as GameObject;
			shieldAvailable = false;
		}
	}

	void OnCollisionEnter (Collision c)
	{
		if (c.transform.tag == "Shield") {
			shieldAvailable = true;
		}

		if (c.transform.tag == "Enemy" || c.transform.tag == "enemyBullet") {
//			gameController.subractLife ();
			playerHit = true;
		}
	}
}
