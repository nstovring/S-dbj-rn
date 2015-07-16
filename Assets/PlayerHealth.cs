using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int Credits;
	public float deathTime = 3;
	public float invincibleTime = 10;
	PlayerControl pControl;
	GameController gControl;
	SpriteRenderer sRenderer;
	BulletManager bManager;
	Collider collider;
	public bool isInvincible;
	delegate void lifeBehaviour();

	lifeBehaviour myLife;

	// Use this for initialization
	void Start () {
		pControl = GetComponent<PlayerControl>();
		gControl = GetComponent<GameController>();
		sRenderer = GetComponent<SpriteRenderer>();
		bManager = GetComponent<BulletManager>();
		collider =GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myLife != null){
		myLife();
		}
	}

	void Alive(){
		sRenderer.enabled = true;
		isInvincible = false;
		sRenderer.color = new Color(255,255,255);
	}
	public float speed;
	public float respawnTimePassed;
	void Respawn(){
		respawnTimePassed += Time.deltaTime;
		pControl.enabled = true;
		sRenderer.enabled = true;
		bManager.enabled = true;
		collider.enabled = true;
		pControl.anim.transform.GetComponent<SpriteRenderer>().enabled = true;
		sRenderer.color = new Color(255,255,Mathf.PingPong(255,Time.time* speed));
		if(respawnTimePassed >= invincibleTime){
			respawnTimePassed = 0;
			myLife = Alive;
		}
	}
	public float deathTimePassed;
	void Dead(){
		pControl.enabled = false;
		sRenderer.enabled = false;
		bManager.enabled = false;
		collider.enabled = false;
		pControl.anim.transform.GetComponent<SpriteRenderer>().enabled = false;
		deathTimePassed += Time.deltaTime;
		if(deathTimePassed >= deathTime){
			deathTimePassed = 0;
			myLife = Respawn;
		}
	}

	void GameOver(){

	}

	void OnCollisionEnter (Collision c)
	{	
		if (c.transform.tag == "Enemy" && !isInvincible || c.transform.tag == "enemyBullet" && !isInvincible) {
			//gControl.subractLife ();
			isInvincible = true;
			myLife = Dead;
			Debug.Log ("I got hit ");
			//pControl.SetPlayerHit(true);
		}
	}
}
