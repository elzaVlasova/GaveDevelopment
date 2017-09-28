using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable{

	protected override void OnRabitHit (Rabbit rabbit){
		LevelController.current.addFruits (1);
		this.CollectedHide();
	}
}
