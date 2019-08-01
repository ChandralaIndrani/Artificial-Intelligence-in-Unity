using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour {

	public Transform goal;
	float speed = 0.5f;
	float accuracy = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		this.transform.LookAt(lookAtGoal);
		if(Vector3.Distance(transform.position,lookAtGoal) > accuracy)
			this.transform.Translate(0,0,speed*Time.deltaTime);
	}
}
