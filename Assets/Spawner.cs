using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public float timePassed;
	public float spawnTime = 1f;
	public int maxCurrentSpawn = 10;
	public GameObject enemy;
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
		if(pathModes == SpawnPaths.Horizontal){
			path = GameObject.FindGameObjectWithTag("horizontalPath").GetComponent<p>(); 
		}
		if(pathModes == SpawnPaths.easyPath){
			path = GameObject.FindGameObjectWithTag("easyPath").GetComponent<p>(); 
		}
		if(pathModes != SpawnPaths.Waiting){
			timePassed += Time.deltaTime;
			if (timePassed > spawnTime && maxCurrentSpawn >= 0) {
				GameObject clone = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<FollowPath>().Move(path);
				timePassed = 0;
			}
		}
	}
}
