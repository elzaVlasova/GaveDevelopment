using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	protected virtual void OnRabitHit (Rabbit rabbit){
	}

	void OnTriggerEnter2D(Collider2D collider){
		//if (!this.hideAnimation) {
		//Debug.Log ("Coins trigger enter");
			Rabbit rabbit = collider.GetComponent<Rabbit>();
			if(rabbit != null) {
				this.OnRabitHit (rabbit);

			}
		//}
	}
	public void CollectedHide() {
		Destroy(this.gameObject);
		}
	}

	
