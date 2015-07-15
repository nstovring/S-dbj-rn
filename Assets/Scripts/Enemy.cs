using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int health = 5;
	public bool isBoss;
	public Image HealthBar;
	public float enemyDistance = 1;
	public FollowPath followPath;
	float timePassed;
	private bool enemyHit= false;
    public Sprite newSprite; 
	private SpriteRenderer spriteRenderer;
	public GameObject Explosion;
	
	public float stayTime = 10;
	public bool hasPowerUp;
	// Use this for initialization
	public Transform pickUp;
	public GameObject player;
	private p path;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		followPath = GetComponent<FollowPath>();
		player = GameObject.FindGameObjectWithTag("Player");
		if(isBoss){
		HealthBar = GameObject.FindGameObjectWithTag("HealthOverlay").GetComponent<Image>();
			//if(HealthBar != null){
			//Mask mask =  HealthBar.transform.parent.gameObject.AddComponent<Mask>();
			//mask.MaskEnabled();
			//}
		}
	}
	
	// Update is called once per frame
	public void ColorChange(){
		if(enemyHit){
			timePassed += Time.deltaTime;
			if(timePassed < .5f && timePassed > 0){
				gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.white, Color.red, 0.5f);
				gameObject.GetComponentInChildren<SpriteRenderer>().material.color =  Color.Lerp(Color.white, Color.red, 0.5f);

				//gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
			}
			else{
				timePassed = 0;
				enemyHit = false;
				gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
				gameObject.GetComponentInChildren<SpriteRenderer>().material.color = Color.white;

			}
		}
	}

	void Update () {
		//player = GameObject.FindGameObjectWithTag("Player");
		if(HealthBar != null){
			HealthBar.rectTransform.sizeDelta = new Vector2(760 * health/100, 100);
			//HealthBar.rectTransform.anchoredPosition = new Vector2(-731.085f * health/100, 100);

			//HealthBar.rectTransform.localScale = new Vector3(1* health/100, 1, 1);
			//HealthBar.rectTransform.sizeDelta = new Rect(HealthBar.rectTransform.position.x, HealthBar.rectTransform.position.y, 1546.17f * health/100, 100);
		}
	//	gameObject.GetComponent<Material>().SetColor(Color.white);
		ColorChange();
		stayTime -= Time.deltaTime;
		if(stayTime <= 0 && !exited){
			ExitLevel();
		}
		//LookAtPlayer();
		SineMove();
	}

	public float amplitude = 0.3f;
	public float frequency = 0.3f;
	void SineMove(){
		transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;
	}

	void LookAtPlayer(){
		var dir = player.transform.position - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}

	bool exited = false;
	public void ExitLevel(){
		p path = GameObject.FindGameObjectWithTag("exitPath").GetComponent<p>();
		followPath.Move(path);
		//Destroy(gameObject, 10);
		exited = true;
	}


	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Bullet"){
			enemyHit = true;
			}
			health--;
		if (health == 4 && health > 3) {
			spriteRenderer.sprite = newSprite;
		}
		if (health <= 3) {

		}
			if(health <= 0){
			GameObject Ex = Instantiate(Explosion, transform.position, transform.rotation)as GameObject;
			if(hasPowerUp){
				GameObject pickUpClone = Instantiate(pickUp,transform.position,Quaternion.identity) as GameObject;
			}
			if(isBoss){
				HealthBar.transform.parent.GetComponent<Image>().enabled = false;
			}
			Destroy(gameObject);
			Destroy (Ex, 0.5f);
			}
		}
	}
