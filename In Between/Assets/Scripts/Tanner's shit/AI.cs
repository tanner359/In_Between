using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour, IControllable
{
    public NavMeshAgent agent;

    public Animator animator;

    public Transform followTarget;

    public GameObject model_root;

    public bool Is_Controlled;

    private void Start()
    {
        agent.speed = 0f;
    }

    private void Update()
    {
        AI_Behaviour(Is_Controlled);
    }

    public GameObject EnableControl()
    {
        Is_Controlled = true;
        return gameObject;
    }

    public void DisableControl()
    {
        Is_Controlled = false;
        agent.isStopped = false;
    }

    public bool IsControlled()
    {
        return Is_Controlled;
    }


    public void AI_Behaviour(bool isEnabled)
    {
        if (isEnabled) {
            agent.isStopped = true; 
            return; 
        }
        else if (agent.remainingDistance < 3f)
        {
            agent.speed = 0f;

            animator.SetBool("isWalking", false);
        }
        else if (agent.remainingDistance > 3f)
        {
            agent.speed = 5f;

            animator.SetBool("isWalking", true);
        }

        agent.SetDestination(followTarget.position);

    }
}
