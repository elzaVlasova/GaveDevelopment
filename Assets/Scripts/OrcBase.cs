using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBase : MonoBehaviour {
	public GameObject prefab;
	//public Transform launchPoint = this.transform;


	public Vector3 MoveBy;
	public float MoveSpeed = 2;
	float attackDirection;

	Vector3 pointA;
	Vector3 pointB;

	Mode mode;



	public float speed = 1;

	bool isDead = false;

	Rigidbody2D myBody = null;
	SpriteRenderer myRenderer = null;
	public Animator animator = null;
	public float shootTime;

	public enum Mode{GoToA,GoToB,Attack}



	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
		myRenderer = this.GetComponent<SpriteRenderer>();

		pointA = this.transform.position;
		pointB = pointA + MoveBy;

		Debug.Log ("Point A: " + pointA + "; Point B:" + pointB);
		//launchCarrot (1);

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
		Vector3 rabbit_position = Rabbit.lastRabbit.transform.position;

		if (rabbit_position.x > Mathf.Min (pointA.x, pointB.x) && rabbit_position.y < Mathf.Max (pointA.x, pointB.x)) {
			mode = Mode.Attack;
			Debug.Log ("Mode attack" );
		}

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



		//3. Direction

		if (mode == Mode.Attack) {
			Debug.Log ("Attack");
			if (position.x < rabbit_position.x) {
				attackDirection = 1;
			} else { attackDirection = -1;
			}
			AttackRabbit (Rabbit.lastRabbit, attackDirection);
			return 0;
		}

		if (position.x < target.x) {
			return 1;
		} else if (position.x > target.x) {
			return -1;
		} else {
			return 0;
		}
	}

	void OnOrcDeath(){
		Debug.Log ("On orc death");
		isDead = true;
		this.animator.SetBool("die", true);
		this.myBody.isKinematic = true;
		this.GetComponent<BoxCollider2D> ().enabled = false;
		StartCoroutine (DestroyOrcBody (3.0f));
	}

	IEnumerator DestroyOrcBody(float duration){
		
		yield return new WaitForSeconds (duration);
		Destroy (this.gameObject);
		
	}

	/*protected virtual void AttackRabbit(Rabbit rabbit){
		
	}*/



	void AttackRabbit(Rabbit rabbit, float attackDirection){
		this.animator.SetTrigger ("attack");



		if (attackDirection > 0) {
			myRenderer.flipX = true;
		} else { myRenderer.flipX = false;
		}

		StartCoroutine (ShootWeapon (attackDirection * (-1)));
		//LevelController.current.OnRabbitDeath(rabbit);
	}

	IEnumerator ShootWeapon(float direction){
		yield return new WaitForSeconds (3f);
		launchCarrot (direction);

	}

	void OnCollideWithRabbit(Rabbit rabbit){
		Debug.Log ("Collided");
		float rabbit_y = rabbit.transform.position.y;
		float orc_y = this.transform.position.y;


		if (rabbit_y > orc_y && rabbit_y - orc_y > 0.4f) {
			this.OnOrcDeath (); 
			Debug.Log ("Death");
			return;
		} 

	}
		

	void OnTriggerEnter2D (Collider2D collider){
		Rabbit rabbit = collider.GetComponent<Rabbit> ();

		if (rabbit != null) {
			OnCollideWithRabbit(rabbit);
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

	void launchCarrot (float direction){
		Vector3 launchPos = this.transform.position;

		GameObject obj = Instantiate (this.prefab, launchPos, Quaternion.identity);
		obj.transform.position = this.transform.position + Vector3.up;

		Weapon carrot = obj.GetComponent<Weapon> ();
		carrot.launch(direction);
	}

	float getRabbitDirection(Rabbit rabbit){

		if (rabbit.transform.position.x < this.transform.position.x) {
			return 1;
		} else {
			return -1;
		}
	}
}


