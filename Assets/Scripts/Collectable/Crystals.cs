using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable{
	public Type type;

	public enum Type
	{
		GREEN, BLUE, RED

	}


	protected override void OnRabitHit (Rabbit rabit){
		LevelController.current.addCrystals (1);
		this.CollectedHide();
 	    CrystalsUI.current.putOnPanel (this);
	}
}
