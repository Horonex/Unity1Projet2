using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour {

    [SerializeField] Transform patrol;
    public Transform player;
    Transform target;
    private Vector3 destination;
    private NavMeshAgent agent;
    public bool isDeadly;

	// Use this for initialization
	void Start () {
        SetTargetPatrol();
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(destination,target.position)>0.1)
        {
            destination = target.position;
            agent.destination = destination;
        }
	}

    public void SetTargetPlayer()
    {
        target = player;
    }

    public void SetTargetPatrol()
    {
        target = patrol;
    }
}
