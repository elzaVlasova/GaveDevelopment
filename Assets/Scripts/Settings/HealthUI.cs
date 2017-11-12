using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {
	public static HealthUI current;

	public List <UI2DSprite> healthIcons;
	public Sprite usedHealth;

	private int currentIndex = 2;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	/*void Start () {
		currentIndex = healthIcons.Count - 1;
		Debug.Log ("Start current " + currentIndex);
	}*/

	public void HealthLost () {
		healthIcons [currentIndex].sprite2D = usedHealth;
		currentIndex--;
		//Debug.Log ("Current index:" + currentIndex);
		if (currentIndex < 0) {
			LevelController.current.onPauseClick ();
		}
	}
}
 