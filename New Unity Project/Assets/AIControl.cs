using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
public GameObject goal;
public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       agent =this.GetComponent<NavMeshAgent>(); 
	   agent.SetDestination(goal.transform.position);
    }
	void Update()
	{
	
	}
    // Update is called once per frame
    
}
