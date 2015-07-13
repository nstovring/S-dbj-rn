using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	public enum layer {
		ground, sky, top
	}

	public layer layers;
	bool instantiated= true;
	// Use this for initialization
	void Start () {
	
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
		if(transform.position.y <= -12 && instantiated){
			Instantiate(gameObject, new Vector3(0,27,0),Quaternion.identity);
			instantiated = false;
		}
	}
	void sky(){
		transform.position -= new Vector3(0,Time.deltaTime*5,0);
		gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color (1f,1f,1f,.5f);
		if(transform.position.y <= -12 && instantiated){
			Instantiate(gameObject, new Vector3(0,27,0),Quaternion.identity);
			gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color (1f,1f,1f,.5f);
			instantiated = false;
			//SpriteRenderer.color = new Color(1f,1f,1f,.5f);
		
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
