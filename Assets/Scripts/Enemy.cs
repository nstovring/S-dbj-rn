using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 5;
	public float enemyDistance = 1;
	public FollowPath followPath;
	// Use this for initialization

	public enum MovementTypes{
		Clamp,
		Horizontal,
		Vertical,
		ZigZag,
		Waiting,
		easy
	}

	public MovementTypes myType = MovementTypes.easy;

	private p path;
	void Start () {
		followPath = GetComponent<FollowPath>();

		if(myType == MovementTypes.easy){
			//path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>();
			//followPath.Move(path);
		}
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.right,out hit,enemyDistance) || Physics.Raycast(transform.position,-transform.right,out hit,enemyDistance)){
			if(hit.transform.tag == "Enemy"){
				followPath.Type = FollowPath.FollowType.Stop;
			}
		}else{
			followPath.Type = FollowPath.FollowType.MoveToward;
		}
	
	}
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Bullet"){
			health--;
			if(health <= 0){
			Destroy(gameObject);
			}
		}
	}
}
