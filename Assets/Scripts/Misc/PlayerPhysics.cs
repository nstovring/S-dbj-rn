using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;
	public LayerMask collisionsMask;


	private float skin = .005f;
	public bool grounded;
	public bool atWall;
	float direct;
	float deltaX;
	float e;

	Ray ray;
	Ray rayF;
	RaycastHit hit;


	void Start(){
		collider = GetComponent<BoxCollider> ();
		s = collider.size;
		c = collider.center;


		}
	public void Move(Vector2 moveAmount){

	
		float deltaY = moveAmount.y;
		deltaX = moveAmount.x;
		Vector2 p = transform.position;


	

	
		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		transform.Translate (finalTransform);
		}

}
