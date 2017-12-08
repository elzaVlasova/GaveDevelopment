using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collectable {

	protected override void OnRabitHit (Rabbit rabbit){
		LevelController.current.addHealth ();
		this.CollectedHide ();
	}
}
