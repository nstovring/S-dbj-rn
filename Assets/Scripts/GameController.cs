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
		string liv = " " + lives;
		if (resetCounter) {
			spawner.counter = 0;
		}

		if (timePassed > minTime && timePassed < maxTime) {
			resetCounter = false;
			spawner.spawnTwo(paths[0], enemies[0],paths[1], enemies[0], 1);
		} 

		if (timePassed > 10 && timePassed < 15) {
			resetCounter = false;
			spawner.spawnOne(paths[2], enemies[1], 2);
		}

	}

	public void subractLife(){
		if(life != null){
		lives = lives - 1;
		}
	}
}
