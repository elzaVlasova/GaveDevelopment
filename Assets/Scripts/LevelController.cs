using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	void Awake(){
		current = this;
	}


	public void SetStartPosition(Vector3 position){
		this.startingPosition = position;
	}

	public void OnRabbitDeath(Rabbit rabbit){
		rabbit.GetComponent<Animator> ().SetBool("die", true);

		StartCoroutine (returnLater (rabbit));
		Debug.Log ("Death Is Here");
	}

	IEnumerator returnLater(Rabbit rabbit){
		yield return new WaitForSeconds (1);

		rabbit.transform.position = this.startingPosition;	
		rabbit.GetComponent<Animator> ().SetBool("die", false);
	}

}
