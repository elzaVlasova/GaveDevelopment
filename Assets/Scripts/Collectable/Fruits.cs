using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Collectable{

	public Type type;

	public enum Type
	{
		f1, f2, f3, f4, f5, f6
	}

	protected override void OnRabitHit (Rabbit rabbit){
		LevelController.current.addFruits (type);
		SpriteRenderer spriteRenderer= this.GetComponent<SpriteRenderer>();
		Color color = spriteRenderer.color;
		color.a = 0.5f;
		spriteRenderer.color = color;
		BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
		collider.enabled = false;
		//this.CollectedHide();
	}
		
}
