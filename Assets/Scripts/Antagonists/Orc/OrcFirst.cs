/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFirst : Orc
{
	[SerializeField] private OrcFistToAttack attackRadius;
	[SerializeField] private AudioSource AttackAudio;

	public override void AttackRabbit()
	{
		if (!_isAttacking && !_isDying)
			StartCoroutine(Attacking());
	}

	private IEnumerator Attacking()
	{
		_isAttacking = true;
		myAnimator.SetBool("Attack", true);
		//if (SoundManager.)
		//{
			AttackAudio.Play();
		//}
		yield return new WaitForSeconds(.2f);
		if (attackRadius.RabbitClose)
		{
			LevelController.current.OnRabbitDeath(Rabbit.lastRabbit);
		}
		_isAttacking = false;

	}

}
*/