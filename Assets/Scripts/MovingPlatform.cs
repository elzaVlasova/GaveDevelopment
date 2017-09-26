using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Vector3 MoveBy;
	public float MoveSpeed = 2;

	Vector3 pointA;
	Vector3 pointB;

	bool going_to_a = false;

	void Start(){
		pointA = this.transform.position;
		Debug.Log ("Point A: " + pointA);
		pointB = pointA + MoveBy;
		Debug.Log ("Point B: " + pointB);
	}
		
	bool IsArrived (Vector3 pos, Vector3 target){
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance (pos, target) < 0.02f;
	}
		

	// Update is called once per frame
	void Update () {
		Vector3 my_pos = this.transform.position;
		Vector3 target;

		if (going_to_a) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}
	

		Vector3 move = (target - my_pos).normalized;
		this.transform.Translate ( move * Time.deltaTime * MoveSpeed);

		if (IsArrived(my_pos, target)) {
			going_to_a = !going_to_a;
			move = new Vector3(0, 0, 0);
			Debug.Log ("We changed the direction");
			return;
		}
	}
}
