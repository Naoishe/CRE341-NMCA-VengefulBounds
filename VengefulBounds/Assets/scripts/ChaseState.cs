using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    private float distance;
    public Vector3 attractedPoint;
    public NavMeshAgent agent;
    public float range;
    public GameObject player;
    public GameObject ghoul;

    //public Transform centrePoint;
    public override State RunCurrentState()
    {
        if(isInAttackRange)
        {
            return attackState;
        }
        else
        {
            Chase();
            return this;
        }
    }

    private void Chase()
    {
        attractedPoint=player.transform.position;
        Vector3 aimedPoint;
        if (TargetPoint(attractedPoint, out aimedPoint))
        {
            Debug.DrawRay(aimedPoint, Vector3.up, Color.blue, 1.0f);
            agent.SetDestination(aimedPoint);
        }
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2f)
        {
            isInAttackRange= true;

        }
        else
        {
            isInAttackRange = false;
        }
    }

    bool TargetPoint(Vector3 passedInPoint, out Vector3 result)
    {
        Vector3 targetPoint = passedInPoint;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
