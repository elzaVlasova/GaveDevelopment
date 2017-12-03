using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcGreen : MonoBehaviour {
	public AudioClip attackClip = null;
	AudioSource attackSourse = null;

	public AudioClip dieClip = null;
	AudioSource dieSourse = null;

	public Vector3 MoveBy;
	public float MoveSpeed = 2;

	Vector3 pointA;
	Vector3 pointB;

	Mode mode;



	public float speed = 1;

	bool isDead = false;

	Rigidbody2D myBody = null;
	SpriteRenderer myRenderer = null;
	public Animator animator = null;

	public enum Mode{GoToA,GoToB,Attack}



	// Use this for initialization
	void Start () {
		attackSourse = gameObject.AddComponent<AudioSource>();
		attackSourse.clip = attackClip;

		dieSourse = gameObject.AddComponent<AudioSource>();
		dieSourse.clip = attackClip;

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
		Vector3 rabbit_position = Rabbit.lastRabbit.transform.position;

		float pointLeft = Mathf.Min (pointA.x, pointB.x);
		float pointRight = Mathf.Max(pointA.x, pointB.x);

		Debug.Log("Left Point:" + pointLeft + "; Right Point" + pointRight);
		 

		if (rabbit_position.x > pointLeft && rabbit_position.x < pointRight) {
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

		//Debug.Log ("Target" + target);



		//3. Direction

		if (mode == Mode.Attack) {
			if (position.x < rabbit_position.x) {
				return 1;
			} else { return -1;
			}
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
		dieSourse.Play ();
		this.myBody.isKinematic = true;
		this.GetComponent<BoxCollider2D> ().enabled = false;
		StartCoroutine (DestroyOrcBody (1.0f));
	}

	IEnumerator DestroyOrcBody(float duration){

		yield return new WaitForSeconds (duration);
		Destroy (this.gameObject);

	}

	/*protected virtual void AttackRabbit(Rabbit rabbit){
		
	}*/

	void AttackRabbit(Rabbit rabbit){
		this.animator.SetTrigger ("attack");
		attackSourse.Play();

		LevelController.current.OnRabbitDeath(rabbit);
		mode = Mode.GoToA;
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

		if (!isDead) {
			Debug.Log ("Attack");
			this.AttackRabbit (rabbit);
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
}


