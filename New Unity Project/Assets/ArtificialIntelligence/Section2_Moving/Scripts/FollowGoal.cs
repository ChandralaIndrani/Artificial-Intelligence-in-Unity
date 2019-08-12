using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour {
    Transform goal;
	float speed = 2.0f;
    float accuracy = 1.0f;
	float rotSpeed = 2.0f;
	public GameObject wpManager;
	GameObject[] wps;
	GameObject currentNode;
	int currentWP = 0;
	Graph g;

 

	// Use this for initialization
	void Start () {
	wps=wpManager.GetComponent<WPManager>().waypoints;
	g = wpManager.GetComponent<WPManager>().graph;
	currentNode=wps[7];
		}
	public void GoToHeli()
	{
		g.AStar(currentNode,wps[8]);
		currentWP = 0;
	}
	public void GoToRuin()
	{
	g.AStar(currentNode , wps[0]);
	currentWP = 0;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	if(g.getPathLength() == 0 ||currentWP == g.getPathLength())
	 return;
	 currentNode = g.getPathPoint(currentWP);
	 {
	 	 currentWP++;

	 }
	 if(currentWP < g.getPathLength())
	 {
	 	 goal = g.getPathPoint(currentWP).transform;
		 Vector3 LookAtGoal = new Vector3(goal.position.x , this.transform.position.y, goal.position.z);
		 Vector3 direction = LookAtGoal - this.transform.position ;
		 this.transform.rotation = Quaternion.Slerp(this.transform.rotation , Quaternion.LookRotation(direction) , Time.deltaTime*rotSpeed);
	 }
	}
}
