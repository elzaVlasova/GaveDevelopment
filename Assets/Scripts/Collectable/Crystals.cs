using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Collectable{
	public AudioClip soundsClip = null;
	AudioSource soundsSourse = null;

	public Type type;

	public enum Type
	{
		GREEN, BLUE, RED

	}


	protected override void OnRabitHit (Rabbit rabit){
		LevelController.current.addCrystals (this.type);
		this.CollectedHide();
 	    CrystalsUI.current.putOnPanel (this);
	}
}
