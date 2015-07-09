using UnityEngine;
using System.Collections;

public class bulletPhysics : MonoBehaviour {
	GameObject Bullet;
	public float bulletSpeed = 2f;
	int type;

	public enum BulletTypes{
		type1, type2, type3
	}

	public float velocity;
	public BulletTypes bulletTypes;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame

	public void setVelocity(float v){

		//gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * v*100);
		Destroy (gameObject, 3);
}

	void OnCollisionEnter(Collision other){
		Destroy(gameObject);
	}


}
