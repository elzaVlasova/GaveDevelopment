using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsUI : MonoBehaviour {

	public UILabel coinsLabel;
	// Use this for initialization
	void Start () {
		coinsLabel.text = "0000";
	}
	

	public void ChangeCoinsQuantity (int coinsQuantity) {
		coinsLabel.text = coinsQuantity.ToString ("0000");
	}
}
