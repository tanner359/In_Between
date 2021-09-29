using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour, IControllable
{
    public NavMeshAgent agent;

    public Animator animator;

    public Transform followTarget;

    public bool Is_Controlled;

    void Start()
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
    }

    public bool IsControlled()
    {
        return Is_Controlled;
    }


    public void AI_Behaviour(bool isEnabled)
    {
        if (!isEnabled) { return; }
        if (agent.remainingDistance < 0.3f)
        {
            agent.speed = 0f;

            animator.SetBool("isWalking", false);
        }
        if (agent.remainingDistance > 0.3f)
        {
            agent.speed = 3f;

            animator.SetBool("isWalking", true);
        }

        agent.SetDestination(followTarget.position);
    }
}
