using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public Vector3 goal = new Vector3(5,0,4);
	public float speed=0.1f;

	void Start () {
		
	}
	
	void Update () 
	{
		this.transform.Translate(goal*speed*Time.deltaTime);
	}
}
