using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text life;
	public GameObject[] enemies = new GameObject[2];
	public int EnemyID= 1;
	public int lives = 3;
	float timePassed;
	public Spawner spawner;
	public Spawner pickUP;
	public int minTime = 5;
	public int maxTime =10;
	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
//		pickUP = GameObject.Find ("PickUpSpawner").GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		spawner.enemy = enemies[EnemyID];
		timePassed += Time.deltaTime;
		string liv = " " + lives;


		if (timePassed > minTime && timePassed < maxTime) {
			EnemyID = 0;
			spawner.pathModes = Spawner.SpawnPaths.easyPath;
			spawner.maxCurrentSpawn = 5;
		} else {
			spawner.pathModes = Spawner.SpawnPaths.Waiting;		}

		if (timePassed > 10 && timePassed < 15) {
			EnemyID = 1;
			spawner.enemy = enemies[EnemyID];
			spawner.pathModes = Spawner.SpawnPaths.easyPath;
			spawner.maxCurrentSpawn = 5;
		}
	}

	public void subractLife(){
		if(life != null){
		lives = lives - 1;
		}
	}
}
