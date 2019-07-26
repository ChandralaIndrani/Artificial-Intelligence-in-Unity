using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointsfollow :MonoBehaviour
{
//public GameObject[] waypoints;
public UnityStandardAssets.Utility.WaypointCircuit circuit;
int currentWP = 0;
float speed = 1.0f;
float accuracy = 1.0f;
float rotSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
     // waypoints = GameObject.FindGameObjectsWithTag("waypoints");  
    }

    // Update is called once per frame
    void LateUpdate()
    {
     if(circuit.Waypoints.Length == 0) return;
	 Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWp].position.x , this.transform.position.y, circuit.Waypoints[currentWp].position.z);
	 Vector3 direction=lookAtGoal - this.transform.position;
	 this.transform.rotation = Quaternion.Slerp(this.transform.rotation , Quaternion.LookRotation(direction) , Time.deltaTime*rotSpeed);
	 if(direction.magnitude < accuracy)
	 {
	 	 currentWP++;
		 if(currentWP>=circuit.Waypoints.Length)
		 {
		 	 currentWP = 0;
		 }
	 }
	 this.transform.Translate(0,0,speed*Time.delta);
	 }
}