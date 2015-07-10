using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	bool instantiated= true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(0,Time.deltaTime,0);
		if(transform.position.y <= -12 && instantiated){
			Instantiate(gameObject, new Vector3(0,27,0),Quaternion.identity);
			instantiated = false;
		}
	}
}
