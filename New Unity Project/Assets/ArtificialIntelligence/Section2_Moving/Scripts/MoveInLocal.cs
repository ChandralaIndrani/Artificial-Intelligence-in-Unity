using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInLocal : MonoBehaviour {

	public Transform goal;
	public float speed = 2.0f;
	float accuracy = 1.0f;
	float rotSpeed=0.4f;

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
	Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);
 Vector3 direction = lookAtGoal - this.transform.position;
 this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotSpeed);
		Debug.DrawRay(this.transform.position,direction,Color.red);
		//if(Vector3.Distance (transform.position,lookAtGoal) > accuracy)
			this.transform.Translate(0,0,speed*Time.deltaTime);
			}
	

}
