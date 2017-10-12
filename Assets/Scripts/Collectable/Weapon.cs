using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyLater());
	}

	IEnumerator destroyLater(){
		yield return new WaitForSeconds (3.0f);
		Destroy (this.gameObject);
	}

	void launchCarrot(float direction){
		GameObject obj.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
