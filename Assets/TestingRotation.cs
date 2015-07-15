using UnityEngine;
using System.Collections;

public class TestingRotation : MonoBehaviour {

	public float inputAngleMax;
	public float inputStartAngle;
	public float turnSpeed;
	// Use this for initialization
	void Start () {
	
	}
	//public bool reverse;
	void turnAngle(Vector3 Angle){

	}

	public bool inverse;
	// Update is called once per frame
	void Update () {
		if(inverse){
			transform.localEulerAngles = new Vector3(0,0,inputStartAngle + (Mathf.PingPong(Time.time*turnSpeed,inputAngleMax))*-1);
		}else{
			transform.localEulerAngles  = new Vector3(0,0,inputStartAngle + Mathf.PingPong(Time.time*turnSpeed,inputAngleMax));
		}
	}
}
