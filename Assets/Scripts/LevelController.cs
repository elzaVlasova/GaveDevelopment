using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	public bool rabbitIsDead = false;

	public UILabel coinsLabel;
	public UILabel fruitsLabel;
	public GameObject settingsPrefab;

	public AudioClip music = null;
	AudioSource musicSourse = null;

	int coins;
	int fruits;
	int crystals;


	void Awake(){
		current = this;
	}

	void Start(){
//		coinsLabel.text = "0000";
//		fruitsLabel.text = "0";
		musicSourse = gameObject.AddComponent<AudioSource>();
		musicSourse.clip = music;
		musicSourse.loop = true;
		musicSourse.Play ();


	}


	public void onPauseClick(){
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
		Setting popup = obj.GetComponent<Setting>();
	}

	public void onPlayClick(){
		SceneManager.LoadScene ("ChooseLevel");
	}


	public void SetStartPosition(Vector3 position){
		this.startingPosition = position;
	}

	public bool isRabbitAlive(){
		return !rabbitIsDead;
	}

	public void OnRabbitDeath(Rabbit rabbit){
		/*rabbit.GetComponent<Animator> ().SetBool("die", true);
		rabbit.GetComponent<Rigidbody2D>().isKinematic = true;
		rabbit.GetComponent<BoxCollider2D> ().enabled = false;*/
		rabbit.OnDeathProcess ();
		StartCoroutine (returnLater (rabbit));
		rabbitIsDead = true;
		if (HealthUI.current != null) {
			HealthUI.current.HealthLost ();
		}
		//Debug.Log ("Death Is Here");
	}

	IEnumerator returnLater(Rabbit rabbit){
		yield return new WaitForSeconds (3);

		rabbitIsDead = false;

		rabbit.transform.position = this.startingPosition;
		rabbit.MakeNormalScale ();
		rabbit.GetComponent<Rigidbody2D>().isKinematic = false;
		rabbit.GetComponent<BoxCollider2D> ().enabled = true;
		rabbit.GetComponent<Animator> ().SetBool("die", false);
	}

	public void addCoins(int quantity){
		this.coins += quantity;
		coinsLabel.text = coins.ToString ("0000");

	}

	public void addFruits(int quantity){
		this.fruits += quantity;
		fruitsLabel.text = fruits.ToString ();
	}

	public void addCrystals(int quantity){
		this.crystals += quantity;

	}
}
