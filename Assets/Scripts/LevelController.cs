using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	int coins;
	int fruits;
	int crystals;


	void Awake(){
		current = this;
	}


	public void SetStartPosition(Vector3 position){
		this.startingPosition = position;
	}

	public void OnRabbitDeath(Rabbit rabbit){
		rabbit.GetComponent<Animator> ().SetBool("die", true);
		rabbit.GetComponent<Rigidbody2D>().isKinematic = true;
		rabbit.GetComponent<BoxCollider2D> ().enabled = false;
		StartCoroutine (returnLater (rabbit));
		Debug.Log ("Death Is Here");
	}

	IEnumerator returnLater(Rabbit rabbit){
		yield return new WaitForSeconds (3);

		rabbit.transform.position = this.startingPosition;
		rabbit.MakeNormalScale ();
		rabbit.GetComponent<Rigidbody2D>().isKinematic = false;
		rabbit.GetComponent<BoxCollider2D> ().enabled = true;
		rabbit.GetComponent<Animator> ().SetBool("die", false);
	}

	public void addCoins(int quantity){
		this.coins += quantity;
	}

	public void addFruits(int quantity){
		this.fruits += quantity;
	}

	public void addCrystals(int quantity){
		this.crystals += quantity;
	}
}
