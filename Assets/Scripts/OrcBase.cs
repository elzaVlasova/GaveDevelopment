using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBase : MonoBehaviour {
	public Vector3 MoveBy;
	public float MoveSpeed = 2;

	Vector3 pointA;
	Vector3 pointB;

	Mode mode;

	bool going_to_a = false;


	public float speed = 1;

	bool isDead;

	Rigidbody2D myBody = null;
	SpriteRenderer myRenderer = null;
	public static Animator animator = null;

	public enum Mode{GoToA,GoToB,Attack}



	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
		myRenderer = this.GetComponent<SpriteRenderer>();

		pointA = this.transform.position;
		pointB = pointA + MoveBy;

		Debug.Log ("Point A: " + pointA + "; Point B:" + pointB);
	}

	// Update is called once per frame
	void Update () {

	}

	protected virtual bool shouldPatrolAb(){
		return true;
	}

	public bool isArrived(Vector3 current, Vector3 target){
		current.z = 0;
		target.z = 0;

		current.y = 0;
		target.y = 0;

		return Vector3.Distance (current, target) < 0.01f;
	}

	float getDirection(){

		if (isDead) {
			return 0; 
		}

		Vector3 position = this.transform.position;

		// 1. Task
		if (shouldPatrolAb()) {
			if(mode == Mode.GoToA && isArrived(position, this.pointA)){
				mode = Mode.GoToB;
			}
			if(mode == Mode.GoToB && isArrived(position, this.pointB)){
				mode = Mode.GoToA;
			}
		}

		// 2. Point
		Vector3 target = pointA;
		if (mode == Mode.GoToA) {
			target = this.pointA;
		} else if (mode == Mode.GoToB) {
			target = this.pointB;
		}

		//Debug.Log ("Target" + target);

		//3. Direction
		if (position.x < target.x) {
			return 1;
		} else if (position.x > target.x) {
			return -1;
		} else {
			return 0;
		}
	}


	void FixedUpdate ()
	{
		//Direction

		float value = this.getDirection ();

		if (value != 0) {
			animator.SetBool ("walk", true);
		}

		//Walk
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = speed * value;
			myBody.velocity = vel;
			
			//Flip Image
			if (value > 0) {
				myRenderer.flipX = true;
			} else if (value < 0) {
				myRenderer.flipX = false;
			}



		} 
	}
}


