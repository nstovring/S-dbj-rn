using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text life;
	public int lives = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string liv = " " + lives;
		life.text = liv;
	}

	public void subractLife(){
		lives = lives - 1;
	}
}
