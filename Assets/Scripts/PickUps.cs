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
		transform.position -= new Vector3(0,Time.deltaTime,0);
	}
	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	void SineMove(){
		transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;
	}


	void OnCollisionEnter (Collision c)
	{
		if (pickUP == pickUPtype.shield ) {
			Destroy(gameObject);
		}
	}
}
