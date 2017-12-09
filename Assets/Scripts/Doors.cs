using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {

	public int level;
	
	public GameObject winWindow;
	public Scenario scenario;

	public enum Scenario
	{
		ToLevel1, ToLevel2, ToMenuLevel1, ToMenuLevel2

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
		Rabbit rabbit = collider.GetComponent<Rabbit>();
		if(rabbit != null) {
			switch (scenario) {
			case Scenario.ToLevel1:
				SceneManager.LoadScene ("Level1");
				break;
			case Scenario.ToLevel2:
				SceneManager.LoadScene ("Level2");
				break;
			case Scenario.ToMenuLevel1:
				//winWindow.SetActive (true);
				LevelController.current.onWinPopup(winWindow, 1);
				GameStats.SetSecondLevelOpen (true);
				GameStats.level1.levelPassed = true;
				break;
			case Scenario.ToMenuLevel2:
				LevelController.current.onWinPopup(winWindow, 2);
				GameStats.level2.levelPassed = true;
				break;
			}

		}

}
}