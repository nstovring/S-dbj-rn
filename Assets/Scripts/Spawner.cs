using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public float timePassed;
	public float spawnTime = 1f;
	public int maxCurrentSpawn = 10;
	public GameObject enemy;
	public int counter;
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
		Debug.Log (getAmount());
		/*
		if(pathModes == SpawnPaths.Horizontal){
			path = GameObject.FindGameObjectWithTag("horizontalPath").GetComponent<p>(); 
		}
		if(pathModes == SpawnPaths.easyPath){
			path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>(); 
		}
		if(pathModes == SpawnPaths.ZigZag){
			path = GameObject.FindGameObjectWithTag("zigzagPath").GetComponent<p>(); 
		}
		if(pathModes != SpawnPaths.Waiting){
			timePassed += Time.deltaTime;
			if (timePassed > spawnTime && maxCurrentSpawn >= 0) {
				GameObject clone = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<FollowPath>().Move(path);

//				GameObject clone1 = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
//				clone1.GetComponent<FollowPath>().Move(GameObject.FindGameObjectWithTag("zigzagPath").GetComponent<p>());
				//path.AddEnemy(clone.transform);
				maxCurrentSpawn--;
				timePassed = 0;
			}
		}
		*/

	}
	public void spawnOne(p path1, GameObject enemy, int amount){
		timePassed += Time.deltaTime;
		maxCurrentSpawn = amount;
		if (timePassed > spawnTime && counter < maxCurrentSpawn) {
			GameObject clone = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<FollowPath> ().Move (path1);
			counter++;
			timePassed = 0;

		}
	}

	public void spawnTwo(p path1, GameObject enemy1, p path2, GameObject enemy2,int amount){
			timePassed += Time.deltaTime;
		    maxCurrentSpawn = amount;
			
			if (timePassed > spawnTime && counter <= maxCurrentSpawn) {

				GameObject clone = Instantiate (enemy1, transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<FollowPath>().Move(path1);
				
				GameObject clone1 = Instantiate (enemy2, transform.position, Quaternion.identity) as GameObject;
				clone1.GetComponent<FollowPath>().Move(path2);
			    counter++;

				timePassed = 0;
			}


	}

	public void setAmount(int a){
		a = counter;
	}
	public int getAmount(){
		return counter;
	}
}
