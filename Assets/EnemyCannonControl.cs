using UnityEngine;
using System.Collections;

public class EnemyCannonControl : MonoBehaviour {

	public float inputAngleMax;
	public float inputStartAngle;
	public float turnSpeed;
	public bool isRotating;
	public bool isAiming;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Enemy>().player;
	}

	
	public bool inverse;
	// Update is called once per frame
	void Update () {
		if(isRotating){
			if(inverse){
				transform.localEulerAngles = new Vector3(0,0,inputStartAngle + (Mathf.PingPong(Time.time*turnSpeed,inputAngleMax))*-1);
			}else{
				transform.localEulerAngles  = new Vector3(0,0,inputStartAngle + Mathf.PingPong(Time.time*turnSpeed,inputAngleMax));
			}
		}
		if(isAiming){
			var dir = player.transform.position - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion lookAtQuat = Quaternion.AngleAxis(angle + 90, Vector3.forward);
			transform.rotation = Quaternion.Lerp(transform.rotation, lookAtQuat, 0.1f);
		}
	}
}
