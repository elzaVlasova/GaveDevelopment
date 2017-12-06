using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelCoins : MonoBehaviour {
	public UILabel coinsLabel;

	void Start (){
		coinsLabel.text = GameStats.TotalCoins.ToString("0000");
	}
}
