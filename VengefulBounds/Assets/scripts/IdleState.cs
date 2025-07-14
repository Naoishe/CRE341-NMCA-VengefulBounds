using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public bool canSeePlayer;
    public ChaseState chaseState;

    //public NavMeshAgent agent;
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
        
    }

    
}
