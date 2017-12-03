/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFistToAttack : MonoBehaviour
{

	[SerializeField] private OrcFirst greenOrcScript;

	public bool RabbitClose;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.GetComponent<Rabbit>() != null)
		{

			if (collider.transform.position.y > transform.position.y + 0.4f)
			{
//				OrcFirst.Die();
			}
			else
			{
				OrcFirst.AttackRabbit();
				RabbitClose = true;
			}
		}

	}

	void OnTriggerExit2D()
	{
		RabbitClose = false;
	}
}
*/