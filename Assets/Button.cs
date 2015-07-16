using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {


	public Sprite[] image = new Sprite[2];
	SpriteRenderer spriterend;
	// Use this for initialization
	void Start () {
		spriterend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	spriterend.sprite = image [0];	
	}
}
