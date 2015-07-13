using UnityEngine;
using System.Collections;

public class bulletPhysics : MonoBehaviour {
	GameObject Bullet;
	public float bulletSpeed = 2f;
	int type;

	public enum BulletTypes{
		straight, sine, type3
	}

	public float velocity;
	public BulletTypes bulletType;
	float time;
	// Use this for initialization
	void Start () {
		time = 0;
		Destroy (gameObject, 5);
	}
	// Update is called once per frame

	void Update(){
		if(bulletType == BulletTypes.sine){
			SineMove();
		}
		time += Time.deltaTime;
	}
	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	public int reverse = 1;
	void SineMove(){
		GetComponent<Rigidbody>().AddForce(amplitude*(Mathf.Sin(2*Mathf.PI*frequency*time) - Mathf.Sin(2*Mathf.PI*frequency*(time - Time.deltaTime)))*transform.right * reverse);
	}

	public void setVelocity(float v){

	}

	void OnCollisionEnter(Collision other){
		Destroy(gameObject);
	}


}
