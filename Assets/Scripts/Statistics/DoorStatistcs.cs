using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStatistcs : MonoBehaviour {

	public int level;
	public GameObject complited;
	public GameObject locked;

	public SpriteRenderer shadowFruit;
	public SpriteRenderer shadowCrystals;

	public Sprite fruitSprite;
	public Sprite crystalSprite;

	private LevelStatistics levelStatistics;

	void Awake(){
		levelStatistics = GameStats.GetLevelStatistics (level.ToString());
		if (levelStatistics == null) {
			levelStatistics = new LevelStatistics ();
		}
	}


	void Start(){
		if (this.level == 1 && GameStats.level1.levelPassed || this.level == 2 && GameStats.level2.levelPassed) {
			complited.SetActive (true);
		}else {complited.SetActive (false);}
		//levelStatistic
		if (levelStatistics.levelPassed) {
			complited.SetActive (true);
		}
		if (this.level == 1 && GameStats.level1.hasAllCrystals) {
			Debug.Log ("Crystals Sprite");
			shadowCrystals.sprite = crystalSprite;
		}
		if (this.level == 1 && GameStats.level1.hasAllFruits || this.level == 2 && GameStats.level2.hasAllFruits){
			shadowFruit.sprite = fruitSprite;
		}
		if (level == 2 && GameStats.IsSecondLevelOpened()) {
			locked.SetActive (false);
		}
	
	}



}
