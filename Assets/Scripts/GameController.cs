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
	public p[] paths = new p[8];
	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
//		pickUP = GameObject.Find ("PickUpSpawner").GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		string liv = " " + lives;


		if (timePassed > minTime && timePassed < maxTime) {
			spawner.spawnTwo(paths[0], enemies[0],paths[1], enemies[0]);
			spawner.maxCurrentSpawn = 10;
		} 

		if (timePassed > 10 && timePassed < 15) {
			spawner.spawnOne(paths[2], enemies[1]);
			spawner.maxCurrentSpawn = 1;
		}

	}

	public void subractLife(){
		if(life != null){
		lives = lives - 1;
		}
	}
}
