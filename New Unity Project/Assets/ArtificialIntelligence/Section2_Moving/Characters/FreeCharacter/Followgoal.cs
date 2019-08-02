using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour {

	public Transform goal;
	float speed = 100.0f;
	float rotSpeed=10.0f;

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
	Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);
 Vector3 direction = lookAtGoal - this.transform.position;
 this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotSpeed);
 this.transform.Translate(0,0,speed*Time.deltaTime);
		//Debug.DrawRay(this.transform.position,direction,Color.red);
		//if(Vector3.Distance (transform.position,lookAtGoal) > accuracy)
			//this.transform.Translate(0,0,speed*Time.deltaTime);
			}
	

}
