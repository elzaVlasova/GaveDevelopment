using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Orc : MonoBehaviour
{

	[SerializeField] private float moveBy;
	[SerializeField] private float speedWalk;
	[SerializeField] private float speedRun;

	private Mode mode;
	Rigidbody2D myBody = null;
	SpriteRenderer myRenderer = null;
	public Animator myAnimator = null;

	private Vector3 pointA;
	private Vector3 pointB;
	protected Vector3 rabbit_pos;
	protected bool _isAttacking = false;
	protected bool _isDying = false;

	public enum Mode
	{
		GoToA,
		GoToB,
		Attack
	}

	void Awake()
	{
		myBody = this.GetComponent<Rigidbody2D>();
		myAnimator = this.GetComponent<Animator> ();
		myRenderer = this.GetComponent<SpriteRenderer>();
		mode = Mode.GoToB;
	}

	void Start()
	{
		pointA = transform.position;
		pointB = new Vector3(pointA.x + moveBy, pointA.y, pointA.z);
	}

	void FixedUpdate()
	{
		if (_isAttacking || _isDying)
		{
			return;
		}

		if (RabbitIsNear() && mode != Mode.Attack)
		{
			mode = Mode.Attack;
		}
		else if (mode == Mode.Attack && !RabbitIsNear())
		{
			mode = Mode.GoToA;
		}

		float xSpeed = GetDirection();

		if (Mathf.Abs(xSpeed) > 0)
		{
			ApplyMovement(xSpeed);
		}

		if (xSpeed < 0)
		{
			myRenderer.flipX = false;
		}
		else if (xSpeed > 0)
		{
			myRenderer.flipX = true;
		}

		if (IsArrived() && mode != Mode.Attack)
		{
			Debug.Log("arrived");
			mode = mode == Mode.GoToA ? Mode.GoToB : Mode.GoToA;
		}

		//if user pushed orc out of bounds
		KeepInBounds();
	}

	private void KeepInBounds()
	{
		if (transform.position.x < pointA.x)
		{
			mode = Mode.GoToB;
		}
		else if (transform.position.x > pointB.x)
		{
			mode = Mode.GoToA;
		}
	}

	private void ApplyMovement(float xSpeed)
	{
		Vector2 vel = myBody.velocity;
		if (mode == Mode.Attack)
		{
			vel.x = xSpeed * speedRun;
			myAnimator.SetBool("Walk", false);
			myAnimator.SetBool("Run", true);
			myAnimator.SetBool("Attack", false);
		}
		else
		{
			vel.x = xSpeed * speedWalk;
			myAnimator.SetBool("Walk", true);
			myAnimator.SetBool("Run", false);
			myAnimator.SetBool("Attack", false);
		}
		myBody.velocity = vel;
	}
	protected bool RabbitIsNear()
	{
		rabbit_pos = Rabbit.lastRabbit.transform.position;
		return rabbit_pos.x >= pointA.x && rabbit_pos.x <= pointB.x;
	}

	public abstract void AttackRabbit();

	float GetDirection()
	{
		if (mode == Mode.Attack)
		{
			if (transform.position.x < rabbit_pos.x)
			{
				return 1;
			}
			else
			{
				return -1;
			}
		}


		if (mode == Mode.GoToA)
		{
			return -1; //Move left
		}
		else if (mode == Mode.GoToB)
		{
			return 1; //Move right
		}
		return 0; //No movement
	}

	bool IsArrived()
	{
		if (mode == Mode.GoToA)
		{
			return IsNearPoint(transform.position, pointA);
		}
		else if (mode == Mode.GoToB)
		{
			return IsNearPoint(transform.position, pointB);
		}
		else return false;
	}

	public void Die()
	{
		if (_isDying)
		{
			return;
		}
		myAnimator.SetBool("Die", true);
		_isDying = true;
		Destroy(this.gameObject, 0.7f);
	}
	bool IsNearPoint(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		pos.y = 0;
		target.y = 0;
		return Vector3.Distance(pos, target) < 0.1f;
	}
}
