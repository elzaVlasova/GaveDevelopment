	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

	public float speed = 1;

	Rigidbody2D myBody = null;
	Transform heroParent = null;

	bool isGrounded = false;
	bool JumpActive = false;

	float JumpTime = 0f;

	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;


	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		LevelController.current.SetStartPosition(transform.position);
		this.heroParent = this.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static void SetNewParent(Transform obj, Transform new_par){
		if (obj.transform.parent != new_par) {
			Vector3 pos = obj.transform.position;

			obj.transform.parent = new_par;
			obj.transform.position = pos;
		}
	}

	void FixedUpdate() {
		//Показує силу, з якою користувач натискає на "джойстик"
		float value = Input.GetAxis("Horizontal");

		//Керування кроликом за допомогою клавіатури
		// speed (встановленна за замовчуванням швидківсть кролика)
		// value (ініціалізована вище сила давлення користувача на джойстик)

		Animator animator = GetComponent<Animator> ();

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = speed * value;
			myBody.velocity = vel;
			animator.SetBool ("run", true);
		} else {
			animator.SetBool ("run", false);
		}

		if (this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}

		//Зміна напрямку кролика зі зміною напрямку руху
		// FlipX в компоненті SpriteRenderer

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (value>0){
			sr.flipX=false;
		} else if (value<0){
			sr.flipX=true;
		}


		// Не розумію чому
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.3f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");

		RaycastHit2D hit = Physics2D.Linecast (from, to, layer_id);

		if (hit) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}

		if (hit.transform != null && hit.transform.GetComponent<MovingPlatform> () != null) {
			SetNewParent (this.transform, hit.transform);
		} else {
			SetNewParent (this.transform, this.heroParent);
		}

		Debug.DrawLine (from, to, Color.red);

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			this.JumpActive = true;
		}

		if (this.JumpActive) {
			if (Input.GetButton("Jump")){
				this.JumpTime += Time.deltaTime; 

			if (this.JumpTime < this.MaxJumpTime) {
				Vector2 vel = this.myBody.velocity;
				vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
				myBody.velocity = vel;
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			} 
		}
		} 
	}
}
