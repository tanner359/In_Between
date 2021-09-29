using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player2AIController : MonoBehaviour
{
    public GameObject player1;

    public NavMeshAgent agent1;

    public Animator anim1;

    void Start()
    {
        //agent1 = GetComponent<NavMeshAgent>();

        agent1.speed = 0f;
    }

    private void Update()
    {
        if (agent1.remainingDistance < 0.3f)
        {
            agent1.speed = 0f;

            anim1.SetBool("isWalking", false);
        }
        if (agent1.remainingDistance > 0.3f)
        {
            agent1.speed = 3f;

            anim1.SetBool("isWalking", true);
        }

        //if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    agent1.speed = 4.75f;

        //    anim1.SetBool("isRunning", true);
        //}
        //if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    agent1.speed = 2f;

        //    anim1.SetBool("isRunning", false);
        //}

        agent1.SetDestination(player1.transform.position);
    }
}
