using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : Movement
{
    public override Vector3 Velocity
    {
        get { return meshAgent.velocity; }
        set { meshAgent.velocity = value; }
    }

    NavMeshAgent meshAgent;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        meshAgent.speed = speedMax;
        meshAgent.angularSpeed = turnRate;
    }

    public override void ApplyForce(Vector3 force)
    {
        //
    }

    public override void MoveTowards(Vector3 target)
    {
        meshAgent.SetDestination(target);
    }

    public override void Stop()
    {
        meshAgent.isStopped = true;
    }
}
