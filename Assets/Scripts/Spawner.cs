using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public float timePassed;
	public float spawnTime = 1f;
	public int maxCurrentSpawn = 10;
	public GameObject enemy;
	public int counter = 0;
	bool isSpawning;
	// Use this for initialization
	public p path;

	public enum SpawnPaths
	{
		Clamp,
		Horizontal,
		Vertical,
		ZigZag,
		Waiting,
		easyPath
	}
	public SpawnPaths pathModes = SpawnPaths.easyPath;

	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void spawnOne(p path1, GameObject enemy, int amount, float spawnRate){
		spawnTime = spawnRate;
		timePassed += Time.deltaTime;
		maxCurrentSpawn = amount;
		//Debug.Log(counter);

		if (timePassed > spawnTime && counter < maxCurrentSpawn) {
			GameObject clone = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<FollowPath> ().Move (path1);
			counter++;
			timePassed = 0;
		} 
	}
	
	public void spawnTwo(p path1, GameObject enemy1, p path2, GameObject enemy2,int amount, float spawnRate){
		spawnTime = spawnRate;
			timePassed += Time.deltaTime;
		    maxCurrentSpawn = amount;
			
			if (timePassed > spawnTime && counter < maxCurrentSpawn) {

			GameObject clone = Instantiate (enemy1, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<FollowPath> ().Move (path1);
				
			GameObject clone1 = Instantiate (enemy2, transform.position, Quaternion.identity) as GameObject;
			clone1.GetComponent<FollowPath> ().Move (path2);
			counter++;

			timePassed = 0;
		} else if(counter == maxCurrentSpawn){
			//counter = 0;
			//Debug.Log ("fasfga");
		}

	}
	
}
