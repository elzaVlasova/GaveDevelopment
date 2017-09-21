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
		rabbit.transform.position = this.startingPosition;	
		Debug.Log ("Death Is Here");
	}

}
