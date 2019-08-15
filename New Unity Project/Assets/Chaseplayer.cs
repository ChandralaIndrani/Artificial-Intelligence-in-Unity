using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Chaseplayer : MonoBehaviour
{
  GameObject Player;
  NavMeshAgent agent;
  // Start is called before the first frame update
    void Start()
    {
	Player = GameObject.FindWithTag("Player");
	agent = this.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);
    }
}
