using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable{

	protected override void OnRabitHit (Rabbit rabbit){
		LevelController.current.addFruits (1);
		SpriteRenderer spriteRenderer= this.GetComponent<SpriteRenderer>();
		Color color = spriteRenderer.color;
		color.a = 0.5f;
		spriteRenderer.color = color;
		BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
		collider.enabled = false;
		//this.CollectedHide();
	}
		
}
