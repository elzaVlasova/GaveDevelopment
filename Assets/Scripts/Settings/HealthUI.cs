using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {
	public static HealthUI current;

	public List <UI2DSprite> healthIcons;
	public Sprite usedHealth;
	Sprite unusedHealth;

	private int currentIndex = 2;

	void Awake(){
		current = this;
		unusedHealth = healthIcons [0].sprite2D;
	}

	// Use this for initialization
	/*void Start () {
		currentIndex = healthIcons.Count - 1;
		Debug.Log ("Start current " + currentIndex);
	}*/

	public void HealthLost () {
		healthIcons [currentIndex].sprite2D = usedHealth;
		currentIndex--;
		Debug.Log ("Current index:" + currentIndex);
		if (currentIndex < 0) {
			LevelController.current.onPauseClick ();
		}
	}

	public void RenewPanel() {
		for (int i = 3; i > 0; i--) {
			healthIcons [currentIndex].sprite2D = unusedHealth;
		}
	}
}
 