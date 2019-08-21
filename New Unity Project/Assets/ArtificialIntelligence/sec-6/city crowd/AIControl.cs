﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;
	Animator anim;

	// Use this for initialization
	void Start () {
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
		anim = this.GetComponent<Animator>();
		anim.SetFloat("wOffset",Random.Range(0,1));
		//float sm=Random.Range(0.5f,2);
		//anim.SetFloat("speedMult",sm);
		//agent.speed *= sm;
		//anim.setTrigger("isWalking");
	}
	
	// Update is called once per frame
	void Update () {
	if(agent.remainingDistance < 1)
		{
			agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
		}
	}
}
