using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	public AudioClip soundClip = null;
	AudioSource soundSourse = null;


	protected virtual void OnRabitHit (Rabbit rabbit){
	}

	void Start(){
		soundSourse = gameObject.AddComponent<AudioSource>();
		soundSourse.clip = soundClip;
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
		soundSourse.Play();
		}
	}

	
