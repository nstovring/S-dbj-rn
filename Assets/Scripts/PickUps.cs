using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {
	public enum pickUPtype{
		shield
	}
	public pickUPtype pickUP;
	//Transform Playerpos;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision c)
	{
		if (pickUP == pickUPtype.shield ) {
			Destroy(gameObject);
		}
	}
}
