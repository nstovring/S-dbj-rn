using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{


	public GameObject player;
	// Use this for initialization
	
	// Update is called once per frame
	void Update ()
	{
	
		transform.position = Vector3.Lerp (transform.position, new Vector3 (Mathf.Clamp (player.transform.position.x, -0.5f, 0.5f), 0, -10), 0.1f);
		//transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -0.5f, 0.5f), 0, -10);


	}
}
