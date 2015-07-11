using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
	public enum pickUPtype{
		shield
	}
	public pickUPtype pickUP;
	float i;
	//Transform Playerpos;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		SineMove ();
	}
	void SineMove(){
	
		transform.position += new Vector3(0,Mathf.Sin(Time.deltaTime),0);
		i+= Time.deltaTime;
	}


	void OnCollisionEnter (Collision c)
	{
		if (pickUP == pickUPtype.shield ) {
			Destroy(gameObject);
		}
	}
}
