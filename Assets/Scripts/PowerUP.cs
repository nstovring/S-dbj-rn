using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour {

	public enum powerUp{
		shield
	}
	public powerUp powerUP;
	Transform Playerpos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (powerUP == powerUp.shield) {
			shield ();
		}
	}

	public void shield(){
		transform.RotateAround (transform.position, new Vector3 (0, 0, 1),Time.deltaTime*100);	
		Playerpos = GameObject.Find ("Player").GetComponent<Transform> ();
		transform.position = Playerpos.position;
	}

	
	void OnCollisionEnter (Collision c)
	{
		// if (c.transform.tag == "Enemy" || c.transform.tag == "enemyBullet" && powerUP == powerUp.shield) {

			
		}
	}



