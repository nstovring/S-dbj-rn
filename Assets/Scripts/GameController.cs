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
	bool resetCounter = false;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
//		pickUP = GameObject.Find ("PickUpSpawner").GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		//string liv = " " + lives;

		if (timePassed > 0 && timePassed < 10f ) { 
			spawner.spawnTwo(paths[0], enemies[0],paths[1], enemies[0], 2,1);
			return;
		}

		if (timePassed > 11 && timePassed < 15) {
			spawner.spawnOne(paths[1], enemies[1], 2,1);
			return;
		}

		if (timePassed > 17 && timePassed < 21) {
			spawner.spawnTwo (paths [0], enemies [0], paths [1], enemies [0], 2,1);
			return;
		}
		spawner.counter = 0;
	}

	public void subractLife(){
		if(life != null){
		lives = lives - 1;
		}
	}

}
