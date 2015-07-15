using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {
	float placement;


	public enum layer {
		ground, sky, top
	}

	public layer layers;
	public Sprite[] sprite = new Sprite[2];

	bool instantiated= true;


	// Use this for initialization
	void Start () {
		if (layers == layer.sky){
			placement = Random.Range (-15, 16);
			GetComponent<SpriteRenderer> ().sprite = sprite [Random.Range (0, sprite.Length-1)];
		}
	
	}
	void Update () {
		if (layers == layer.ground){
			bottom ();
		}
		if (layers == layer.sky){
			sky ();
		}
		if (layers == layer.top){
			top();
		}
	}

	void bottom(){
		transform.position -= new Vector3(0,Time.deltaTime,0);
		if(transform.position.y <= -35 && instantiated){
			Instantiate(gameObject, new Vector3(0,27,0),Quaternion.Euler(0,180,0));
			//transform.Rotate(0,180,0);
			instantiated = false;
		}
	}
	void sky(){
		transform.position -= new Vector3(0,Time.deltaTime*7,0);
		if(transform.position.y <= 15 && instantiated){
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color (1f,1f,1f,.2f);
			Instantiate(gameObject, new Vector3(placement,27,0),Quaternion.identity);
			instantiated = false;
			Destroy (gameObject, 10);
		
		}
	}

	void top (){
		transform.position -= new Vector3(0,Time.deltaTime*10,0);
		if(transform.position.y <= -12 && instantiated){
			Instantiate(gameObject, new Vector3(0,27,0),Quaternion.identity);
			instantiated = false;
		}
	}
}
