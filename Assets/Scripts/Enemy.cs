using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public FollowPath followPath;
	// Use this for initialization
	void Start () {
		followPath = GetComponent<FollowPath>();
		followPath.Move();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Bullet"){
			Destroy(gameObject);
		}
	}
}
