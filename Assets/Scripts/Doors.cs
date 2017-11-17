using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {

	public Scene nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		//if (!this.hideAnimation) {
		//Debug.Log ("Coins trigger enter");
		Rabbit rabbit = collider.GetComponent<Rabbit>();
		if(rabbit != null) {
			SceneManager.LoadScene ("Level1");

		}

}
}