using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float timePassed;
	public float spawnTime = 1f;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timePassed+= Time.deltaTime;
		if(timePassed > spawnTime){
			Instantiate(enemy, transform.position, Quaternion.identity);
			timePassed = 0;
		}
	}
}
