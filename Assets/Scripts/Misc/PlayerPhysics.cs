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
		grounded = false;
		atWall = false;

		for (int i = 0; i < 3; i++)
		{
			float dir = Mathf.Sign (deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/2 * i;
			float y = p.y + c.y + s.y/2 * dir;

			ray = new Ray(new Vector2(x,y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);
			if(Physics.Raycast(ray, out hit,Mathf.Abs (deltaY)+skin, collisionsMask)){
				float dst = Vector3.Distance(ray.origin, hit.point);

				if(dst > skin){
					deltaY = dst * dir - skin * dir;
				}
				else {
					deltaY = 0;
				}
				grounded = true;
				break;



			}
		}

	

		for (int i = 0; i <5; i++) {
			float dir1 = Mathf.Sign(deltaX);
			float x1 = p.x + c.x + s.x/2 * dir1;
			float y1 = (p.y + c.y - s.y/2) + s.y/4 * i;

			rayF = new Ray(new Vector2(x1,y1), new Vector2(dir1,0));
			Debug.DrawRay(rayF.origin, rayF.direction);

			if(Physics.Raycast(rayF, out hit, Mathf.Abs (deltaX), collisionsMask)){
				float dist = Vector3.Distance(rayF.origin, hit.point);
				if(dist > skin){
					deltaX =- dist+skin;
				}
				else 
				{
					deltaX = 0;
				}
				atWall = true;
				break;
			}
				}

	
		direct = moveAmount.x;
		Vector2 finalTransform = new Vector2(deltaX, deltaY);
		transform.Translate (finalTransform);
		e = Mathf.Sign (deltaX);
		}

	public float getDirect (float d){
		d = e;
		return d;
	}
	
}
