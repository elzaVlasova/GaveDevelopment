using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Vector3 MoveBy;
	public float MoveSpeed = 2;
	public float wait = 0;

	Vector3 pointA;
	Vector3 pointB;

	bool going_to_a = false;


	void Start(){
		pointA = this.transform.position;
		//Debug.Log ("Point A: " + pointA);
		pointB = pointA + MoveBy;
		//Debug.Log ("Point B: " + pointB);
		//this.wait = 5;
		//Debug.Log ("Starting wait " + this.wait);
	}
		
	bool IsArrived (Vector3 pos, Vector3 target){
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance (pos, target) < 0.02f;
	}
		

	// Update is called once per frame
	void Update () {
		if (this.wait > 0) {
			this.wait -= Time.deltaTime;
			return;
		}


		Vector3 my_pos = this.transform.position;
		Vector3 target;

		if (going_to_a) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}

		Vector3 move = (target - my_pos).normalized;


		if (IsArrived(my_pos, target)) {
			//Debug.Log ("Wait" + wait);
			//Debug.Log ("Is arrived" + going_to_a);
			this.wait = 3;
			going_to_a = !going_to_a;
			move = new Vector3(0, 0, 0);
			//Debug.Log ("We changed the direction");
			return;
		}


		//Platform wait
		/*if (wait > 0) {
			wait -= Time.deltaTime;
			Debug.Log("Wait:" + wait);
		} else {
			Debug.Log("Zero");
			return;
		}*/
		this.transform.Translate ( move * Time.deltaTime * MoveSpeed);
	}
}
