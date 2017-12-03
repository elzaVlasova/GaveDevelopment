using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {

	public Scenario scenario;

	public enum Scenario
	{
		ToLevel1, ToLevel2, ToMenu

	}

	public Scene nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		//if (!this.hideAnimation) {
		Debug.Log ("Trigger enter");
		Rabbit rabbit = collider.GetComponent<Rabbit>();
		if(rabbit != null) {
			switch (scenario) {
			case Scenario.ToLevel1:
				SceneManager.LoadScene ("Level1");
				break;
			case Scenario.ToLevel2:
				SceneManager.LoadScene ("New Scene");
				break;
			case Scenario.ToMenu:
				LevelController.current.winWindow.SetActive (true);
				Debug.Log ("On Win Popup");
				break;
			}

		}

}
}