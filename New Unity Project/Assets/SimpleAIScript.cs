using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIScript : MonoBehaviour {
	public Transform goal;
	//public text readout;
	public float acceleration = 5f;
	public float deceleration = 5f;
	public float minSpeed = 0.0f;
	public float maxSpeed = 100.0f;
	public float brakeAngle=20.0f;
public float rotSpeed = 1.0f;
	float speed = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
	Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);
	Vector3 direction = lookAtGoal - this.transform.position;
	if(Vector3.Angle(goal.forward,this.transform.forward) > brakeAngle && speed>10)
	{
	//this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotSpeed);
	speed = Mathf.Clamp(speed - (deceleration*Time.deltaTime),minSpeed,maxSpeed);

	}
	else
	{
	speed = Mathf.Clamp(speed + (acceleration*Time.deltaTime),minSpeed,maxSpeed);

	}

	this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotSpeed);
	//speed = Mathf.Clamp(speed + (acceleration*Time.deltaTime),minSpeed,maxSpeed);
	this.transform.Translate(0,0,speed);
	//AnalougeSpeedConverter.ShowSpeed(speed,0,100);
	//readout.text="" + speed;
	}
	}
