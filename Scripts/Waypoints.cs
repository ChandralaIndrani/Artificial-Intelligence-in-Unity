using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
public GameObject[] waypoints;
int currentWp = 0;
float speed = 1.0f;
float accuracy = 1.0f;
float rotSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
      waypoints = GameObject.FindGameObjectsWithTag("waypoints");  
    }

    // Update is called once per frame
    void Update()
    {
     if(waypoints.Length == 0) return;
	 Vector3 lookAtGoal = new Vector3(waypoints[currentWp].transform.position.x , this.transform.position.y, waypoints[currentWp].transform.position.z);
	 Vector3 direction=lookAtGoal - this.transform.position;
	 this.transform.rotation = Quaternion.Slerp(this.transform.rotation , Quaternion.LookRotation(direction) , Time.deltaTime*rotSpeed);
	 if(direction.magnitude < accuracy)
	 {
	 	 currentWp++;
		 if(currentWp >=waypoints.Length)
		 {
		 	 currentWp = 0;
		 }
	 }
	 this.transform.Translate(0,0,speed*Time.deltaTime);
    }
}
