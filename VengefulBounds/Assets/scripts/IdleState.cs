using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public bool canSeePlayer;
    public ChaseState chaseState;
    private bool runThis;

    public NavMeshAgent agent;
    public float range;
    public GameObject player;
    public GameObject ghoul;

    public Transform centrePoint;

    private float distance;
    public override State RunCurrentState()
    {
        if(canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            Roam();
            return this;
            
        }
    }

    private void Roam()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 10f)
        {
            canSeePlayer= true;

        }
        else
        {
            canSeePlayer=false;
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 centre, float range, out Vector3 result)
    {
        Vector3 randomPoint = centre + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
