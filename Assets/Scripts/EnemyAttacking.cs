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

	public delegate void ShootingMode();
	ShootingMode myShootingMode;

	public enum FireMode{
		Simple, Burst, Automatic, Spread 
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
		if(fireMode == FireMode.Burst){
			Burst ();
		}
		if(fireMode == FireMode.Spread){
			SpreadShot();
		}
	}

	void SimpleFire(){
		timePassed += Time.deltaTime;
		if(timePassed> fireRate){
		Shoot();
		timePassed = 0;
		}
	}

	float IntervalPassed = 0f;
	float burstFireRate = 2;
	int shots = 4;

	void Burst(){
		float burstInterval = 0.1f;
		timePassed += Time.deltaTime;
		//Debug.Log (shots);
		if(timePassed> burstFireRate){
			IntervalPassed +=Time.deltaTime;
			//Debug.Log(IntervalPassed);
			if(IntervalPassed> burstInterval){
			shots--;
			Shoot();
			IntervalPassed = 0;
			}
			if(shots<= 0){
			timePassed = 0;
			shots = 4;
			}
		}
	}

	public Transform[] spreadShotFiringPoints = new Transform[2];
	float spreadShotFireRate = 2;
	float spreadInterval = 0.1f;
	public int spreadShots = 50;
	void SpreadShot(){
		float burstInterval = 0.1f;
		timePassed += Time.deltaTime;
		//Debug.Log (shots);
		//spreadShotFiringPoints[0].eulerAngles = Vector3.Lerp(spreadShotFiringPoints[0].eulerAngles, new Vector3(0,0,180),0.1f );
		//spreadShotFiringPoints[1].eulerAngles = Vector3.Lerp(spreadShotFiringPoints[1].eulerAngles, new Vector3(0,0,-180f),0.1f);
		if(timePassed> spreadShotFireRate){
			spreadShotFiringPoints[0].eulerAngles = Vector3.Lerp(spreadShotFiringPoints[0].eulerAngles, new Vector3(0,0,180),0.01f );
			spreadShotFiringPoints[1].eulerAngles = Vector3.Lerp(spreadShotFiringPoints[1].eulerAngles, new Vector3(0,0,-180f),0.01f);
			/*foreach (Transform firingPoint in spreadShotFiringPoints){
				Quaternion rotation;
				//firingPoint.rotation = rotation.eulerAngles(new Vector3(0,0,90));
				firingPoint.eulerAngles = Vector3.Lerp(firingPoint.eulerAngles, new Vector3(0,0,90),0.01f);
				//firingPoint.RotateAround(firingPoint.transform.position,new Vector3(0,0,1),90*Time.deltaTime);
			}*/



			IntervalPassed +=Time.deltaTime;

			if(IntervalPassed> spreadInterval){
				spreadShots--;
				foreach (Transform firingPoint in spreadShotFiringPoints){
					GameObject clone = Instantiate (tempBullet, firingPoint.position, firingPoint.rotation)as GameObject;
					clone.GetComponent<Rigidbody>().AddForce(-firingPoint.up * 100* bulletSpeed);
				}
				IntervalPassed = 0;
			}
			if(spreadShots<= 0){
				timePassed = 0;
				spreadShots = 50;
			}
		}
	}


	void Shoot(){
		//GameObject clone;
		GameObject clone = Instantiate (tempBullet, bulletSpawn.position, bulletSpawn.rotation)as GameObject;
		//transform.TransformDirection()
		//clone.GetComponent<Rigidbody>().AddForce(0,-bulletSpeed*100,0);
		clone.GetComponent<Rigidbody>().AddForce(-transform.up * 100* bulletSpeed);

	}


}
