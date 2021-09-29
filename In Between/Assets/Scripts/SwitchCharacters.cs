using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CMF;
using UnityStandardAssets.CrossPlatformInput;

public class SwitchCharacters : MonoBehaviour
{
    public static float ghostNum;

    public GameObject player1;
    public GameObject player1ModelRoot;
    public GameObject player1AICollider;

    public GameObject player2;
    public GameObject player2ModelRoot;
    public GameObject player2AICollider;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam1Far;
    public GameObject cam2Far;
    void Start()
    {
        ghostNum = 1f;
    }

    void Update()
    {
        SwitchChar();
    }


    void SwitchChar()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.G)/* || CrossPlatformInputManager.GetButtonDown("ghostSwitch")*/)
        {
            ghostNum++;
            player1.transform.rotation = Quaternion.identity;
            player1ModelRoot.transform.rotation = Quaternion.identity;
            player2.transform.rotation = Quaternion.identity;
            player2ModelRoot.transform.rotation = Quaternion.identity;
        }


        if (ghostNum > 1)
        {
            ghostNum = 0;
        }


        if (ghostNum == 0)
        {

            player2.gameObject.layer = 7;

            if (CameraSwitch.inContact2)
            {
                cam2Far.SetActive(true);
                cam2.SetActive(false);
                cam1.SetActive(false);
            }
            if (!CameraSwitch.inContact2)
            {
                cam2.SetActive(true);
                cam1.SetActive(false);
            }

            //player1.transform.rotation = Quaternion.identity;
            //player1ModelRoot.transform.rotation = Quaternion.identity;
            player1.tag = "Untagged";
            player1AICollider.SetActive(true);
            player1.GetComponent<Rigidbody>().isKinematic = true;
            player1ModelRoot.GetComponent<SmoothPosition>().enabled = false;
            player1ModelRoot.GetComponent<TurnTowardControllerVelocity>().enabled = false;
            player1.GetComponent<Mover>().enabled = false;
            player1.GetComponent<AdvancedWalkerController>().enabled = false;
            player1.GetComponent<PlayerController>().enabled = false;
            player1.GetComponent<NavMeshAgent>().enabled = true;

            player2.tag = "Player";
            player2.transform.rotation = Quaternion.identity;
            player2AICollider.SetActive(false);
            player2.GetComponent<Rigidbody>().isKinematic = false;
            player2ModelRoot.GetComponent<SmoothPosition>().enabled = true;
            player2ModelRoot.GetComponent<TurnTowardControllerVelocity>().enabled = true;
            player2.GetComponent<Mover>().enabled = true;
            player2.GetComponent<AdvancedWalkerController>().enabled = true;
            player2.GetComponent<PlayerController>().enabled = true;
            player2.GetComponent<NavMeshAgent>().enabled = false;
        }
        if (ghostNum == 1)
        {
            if (CameraSwitch.inContact1)
            {
                cam1Far.SetActive(true);
                cam1.SetActive(false);
                cam2.SetActive(false);
            }
            if (!CameraSwitch.inContact1)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }

            //player2.transform.rotation = Quaternion.identity;
            //player2ModelRoot.transform.rotation = Quaternion.identity;
            player2.tag = "Untagged";
            player2AICollider.SetActive(true);
            player2.GetComponent<Rigidbody>().isKinematic = true;
            player2ModelRoot.GetComponent<SmoothPosition>().enabled = false;
            player2ModelRoot.GetComponent<TurnTowardControllerVelocity>().enabled = false;
            player2.GetComponent<Mover>().enabled = false;
            player2.GetComponent<AdvancedWalkerController>().enabled = false;
            player2.GetComponent<PlayerController>().enabled = false;
            player2.GetComponent<NavMeshAgent>().enabled = true;

            player1.tag = "Player";
            player1.transform.rotation = Quaternion.identity;
            player1AICollider.SetActive(false);
            player1.GetComponent<Rigidbody>().isKinematic = false;
            player1ModelRoot.GetComponent<SmoothPosition>().enabled = true;
            player1ModelRoot.GetComponent<TurnTowardControllerVelocity>().enabled = true;
            player1.GetComponent<Mover>().enabled = true;
            player1.GetComponent<AdvancedWalkerController>().enabled = true;
            player1.GetComponent<PlayerController>().enabled = true;
            player1.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
