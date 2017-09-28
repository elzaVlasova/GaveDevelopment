using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable{

	protected override void OnRabitHit (Rabbit rabbit){
		if (rabbit.IsBig ()) {
			rabbit.MakeNormalScale();
		} else {
			LevelController.current.OnRabbitDeath (rabbit);
		}
		this.CollectedHide();
	}
}
