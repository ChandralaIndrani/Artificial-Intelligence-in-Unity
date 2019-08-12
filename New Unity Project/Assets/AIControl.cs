using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       agent =this.GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    
}
