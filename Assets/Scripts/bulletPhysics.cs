using UnityEngine;
using System.Collections;

public class bulletPhysics : MonoBehaviour {
	GameObject Bullet;

	public enum BulletTypes{
		type1, type2, type3
	}

	public float velocity;
	public BulletTypes bulletTypes;
	// Use this for initialization
	void Start () {
	if (bulletTypes == BulletTypes.type1) {
			setVelocity(3);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setVelocity(float v){
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * v*100);
		Destroy (gameObject, 3);
}

	void OnCollisionEnter(Collision other){
		Destroy(gameObject);
	}


}
