using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text life;
	public int lives = 3;
	float timePassed;
	public Spawner spawner;
	public Spawner pickUP;
	public int minTime = 5;
	public int maxTime =10;
	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
		pickUP = GameObject.Find ("PickUpSpawner").GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		string liv = " " + lives;

		if (timePassed > 2 && timePassed < 3) {
			pickUP.pathModes = Spawner.SpawnPaths.Horizontal;
			//pickUP.maxCurrentSpawn = 1;
		} else {
			pickUP.pathModes = Spawner.SpawnPaths.Waiting;
		}

		if (timePassed > minTime && timePassed < maxTime) {
			spawner.pathModes = Spawner.SpawnPaths.easyPath;
			spawner.maxCurrentSpawn = 5;
		} else {
			spawner.pathModes = Spawner.SpawnPaths.Waiting;		}
	}

	public void subractLife(){
		if(life != null){
		lives = lives - 1;
		}
	}
}
