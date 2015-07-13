using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
	private Collider collider;
	private Vector3 s;
	private Vector3 c;
	public LayerMask collisionsMask;
	//float direct;
	float deltaX;
	float deltaY;

	void Start ()
	{
		collider = GetComponent<Collider> ();
		//s = collider.size;
		//c = collider.center;
	}

	void Update(){

	}

	public void Move (Vector2 moveAmount)
	{
		deltaY = moveAmount.y;
		deltaX = moveAmount.x;
		Vector2 p = transform.position;
		Vector2 finalTransform = new Vector2 (deltaX, deltaY);
		transform.Translate (finalTransform);

	}

	private float IncrementTowards (float n, float target, float a)
	{
		if (n == target) {
			return n;
		} else {
			float dir = Mathf.Sign (target - n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target;
		}
	}
}
