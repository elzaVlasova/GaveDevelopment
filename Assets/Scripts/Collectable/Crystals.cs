using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable{

	protected override void OnRabitHit (Rabbit rabit){
		LevelController.current.addCrystals (1);
		this.CollectedHide();
	}
}
