using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	public bool rabbitIsDead = false;

	public UILabel coinsLabel;
	public GameObject settingsPrefab;

	int coins;
	int fruits;
	int crystals;


	void Awake(){
		current = this;
	}

	void Start(){
		coinsLabel.text = "0000";
	}


	public void onPauseClick(){
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
		Setting popup = obj.GetComponent<Setting>();
	}


	public void SetStartPosition(Vector3 position){
		this.startingPosition = position;
	}

	public bool isRabbitAlive(){
		return !rabbitIsDead;
	}

	public void OnRabbitDeath(Rabbit rabbit){
		rabbit.GetComponent<Animator> ().SetBool("die", true);
		rabbit.GetComponent<Rigidbody2D>().isKinematic = true;
		rabbit.GetComponent<BoxCollider2D> ().enabled = false;
		StartCoroutine (returnLater (rabbit));
		rabbitIsDead = true;
		Debug.Log ("Death Is Here");
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
	}

	public void addCrystals(int quantity){
		this.crystals += quantity;
	}
}
