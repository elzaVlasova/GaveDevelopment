using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooms : Collectable{

	protected override void OnRabitHit (Rabbit rabbit){
		if (!rabbit.IsBig()) {
			rabbit.MakeBigger ();
		}
		this.CollectedHide();
	}
}