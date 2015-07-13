using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAttacking : MonoBehaviour {

	public float fireRate = 1f;
	public float bulletSpeed = 1;
	float timePassed;
	public Transform bulletSpawn;
	public GameObject tempBullet;
	public GameObject[] bulletTypes;
	public Transform MainCannon;
	GameObject player;
	public delegate void ShootingMode();
	ShootingMode myShootingMode;

	public enum FireMode{
		Simple, Burst, Automatic, Spread, BurstAndSpread, BurstNoCannon, SineWave 
	}

	public FireMode fireMode = FireMode.Simple;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		if(fireMode == FireMode.Simple){
			myShootingMode = SimpleFire;
		}
		if(fireMode == FireMode.Burst){
			myShootingMode = Burst;
		}
		if(fireMode == FireMode.Spread){
			myShootingMode =SpreadShot;
		}
		if(fireMode == FireMode.BurstAndSpread){
			myShootingMode +=SpreadShot;
			myShootingMode +=Burst;
		}

		if (fireMode == FireMode.BurstNoCannon){
			myShootingMode = burstNoCannon;
		}
		if (fireMode == FireMode.SineWave){
			myShootingMode = SineWave;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(myShootingMode != null && transform.position.y < 8.1&& transform.position.y > -10 && transform.position.x < 15 && transform.position.x > -15){
			myShootingMode();
		}
	}
	float sineFireRate = 0.1f;
	void SineWave(){
		timePassed += Time.deltaTime;
		if(timePassed> sineFireRate){
			SineShoot();
			timePassed = 0;
		}
	}

	void SimpleFire(){
		timePassed += Time.deltaTime;
		if(timePassed> fireRate){
			Shoot(MainCannon);
		timePassed = 0;
		}
	}

	float burstIntervalPassed = 0f;
	float burstFireRate = 2;
	int burstShots = 4;

	void Burst(){
		LookAtPlayer(MainCannon);
		float burstInterval = 0.05f;
		timePassed += Time.deltaTime;
		//Debug.Log (shots);
		if(timePassed> burstFireRate){
			burstIntervalPassed +=Time.deltaTime;
			//Debug.Log(IntervalPassed);
			if(burstIntervalPassed> burstInterval){
				burstShots--;
			Shoot(MainCannon);
				burstIntervalPassed = 0;
			}
			if(burstShots<= 0){
			timePassed = 0;
				burstShots = 4;
			}
		}
	}

	public Transform[] spreadShotFiringPoints = new Transform[2];
	float spreadShotFireRate = 5;
	float spreadInterval = 0.1f;
	float spreadIntervalPassed = 0f;
	float spreadTimePassed;
	public int spreadShots = 10;
	private float angle;
	//private int maxShots = spreadShots;
	int direction = 1;
	void SpreadShot(){
		float burstInterval = 0.1f;
		spreadTimePassed += Time.deltaTime;
		if(spreadTimePassed> spreadShotFireRate){
			spreadIntervalPassed +=Time.deltaTime;
			if(spreadIntervalPassed> spreadInterval){
				spreadShots--;
				foreach (Transform firingPoint in spreadShotFiringPoints){
					Shoot(firingPoint);
				}
				spreadIntervalPassed = 0;
			}
			if(spreadShots<= 0){
				spreadTimePassed = 0;
				spreadShots = 10;
			}
		}
	}

	void burstNoCannon(){
		LookAtPlayer();
		float burstInterval = 0.1f;
		timePassed += Time.deltaTime;
		//Debug.Log (shots);
		if(timePassed> burstFireRate){
			burstIntervalPassed +=Time.deltaTime;
			//Debug.Log(IntervalPassed);
			if(burstIntervalPassed> burstInterval){
				burstShots--;
				Shoot();
				burstIntervalPassed = 0;
			}
			if(burstShots<= 0){
				timePassed = 0;
				burstShots = 4;
			}
		}
	}
	void LookAtPlayer(){
		var dir = player.transform.position - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}
	void LookAtPlayer(Transform cannon){
		var dir = player.transform.position - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		cannon.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}
	void Shoot(Transform cannon){
		GameObject clone = Instantiate (tempBullet, cannon.position, cannon.rotation)as GameObject;
		clone.GetComponent<Rigidbody>().AddForce(-cannon.up * 100* bulletSpeed);
	}
	void Shoot(){
		GameObject clone = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		clone.GetComponent<Rigidbody>().AddForce(-transform.up * 100* bulletSpeed);
	}
	void SineShoot(){
		GameObject clone = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		clone.GetComponent<bulletPhysics>().bulletType = bulletPhysics.BulletTypes.sine;
		clone.GetComponent<bulletPhysics>().reverse = -1;
		clone.GetComponent<Rigidbody>().AddForce(-transform.up * 100* bulletSpeed);

		GameObject clone1 = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		clone1.GetComponent<bulletPhysics>().bulletType = bulletPhysics.BulletTypes.sine;
		clone1.GetComponent<Rigidbody>().AddForce(-transform.up * 100* bulletSpeed);
	}
}
