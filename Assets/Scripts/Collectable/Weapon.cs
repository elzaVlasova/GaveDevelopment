using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable {
	private float weapon_speed = 3f;
	private Vector2 directionVector = Vector2.left;

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyLater());
	}
		
	protected override void OnRabitHit(Rabbit rabbit){
		if (!LevelController.current.rabbitIsDead) {
			LevelController.current.OnRabbitDeath (rabbit);
		}
		CollectedHide ();
	}

	IEnumerator destroyLater(){
		yield return new WaitForSeconds (3.0f);
		Destroy (this.gameObject);
	}

	public void launch(float direction){
		this.directionVector *= direction;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (this.directionVector*weapon_speed*Time.deltaTime);
	}
}
