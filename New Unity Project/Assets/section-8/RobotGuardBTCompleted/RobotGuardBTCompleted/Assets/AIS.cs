using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Panda;

public class AIS : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawn;
    public Slider healthBar;   
    public GameObject bulletPrefab;

    NavMeshAgent agent;
    public Vector3 destination; // The movement destination.
    public Vector3 target;      // The position to aim to.
    float health = 100.0f;
    float rotSpeed = 5.0f;

    float visibleRange = 80.0f;
    float shotRange = 40.0f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = shotRange - 5; //for a little buffer
        InvokeRepeating("UpdateHealth",5,0.5f);
    }

    void Update()
    {
        Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.value = (int)health;
        healthBar.transform.position = healthBarPos + new Vector3(0,60,0);
    }

    void UpdateHealth()
    {
       if(health < 100)
        health ++;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "bullet")
        {
            health -= 10;
        }
    }
	[Task]
	public void PickDestination(float x,float z)
	{
		Vector3 dest = new Vector3(x,0,z);
		agent.SetDestination(dest);
		Task.current.Succeed();
	}
	[Task]
	public void PickRandomDestination()
	{
		Vector3 dest = new Vector3(Random.Range(-100,100),0,Random.Range(-100,100));
		agent.SetDestination(dest);
		Task.current.Succeed();
}
[Task]
public void MoveToDestination()
{
	if(Task.isInspected)
	Task.current.debugInfo = string.Format("t={0:0.00}",Time.time);
	if(agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
	{
		Task.current.Succeed();
	}
	}
	[Task]
	public void TargetPLayer()
	{
		target = player.transform.position;
		Task.current.Succeed();
	}
	[Task]
	public void LookAtTarget()
	{
		Vector3 direction= target - this.transform.position;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime*rotSpeed);
		//Debug.Log(Vector3.Angle(this.transform.forward,direction));
		if(Task.isInspected)
		Task.current.debugInfo = string.Format("angle={0}", Vector3.Angle(this.transform.forward,direction));
		if(Vector3.Angle(this.transform.forward,direction)<5.0f)
		{
			Task.current.Succeed();
		}
    }
		[Task]
		public void Fire()
		{
		GameObject bullet = GameObject.Instantiate(bulletPrefab,bulletSpawn.transform.position,bulletSpawn.transform.rotation);
		bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*2000);
		//return true;
		}

}


