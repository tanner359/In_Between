using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    float ghostNum = 1;
    float flashNum = 1;

    public Material material1;
    public Material material2;

    public Animator anim1;

    public GameObject player1;
    public GameObject flashlight;

    Rigidbody rb;

    public VariableJoystick leftStick;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //PlayerMovementMobile();

        //movement

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //Vector3 movementMobile = new Vector3(leftStick.Horizontal, 0, leftStick.Vertical);
        //////////////////////////////////////////////////////////////////////////////////////


        //transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);

        //transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);


        if (moveVertical != 0 || moveHorizontal != 0/* || leftStick.Vertical != 0 || leftStick.Horizontal != 0*/)
        {
            anim1.SetBool("isWalking", true);
        }
        if (moveVertical == 0 && moveHorizontal == 0/* || leftStick.Vertical == 0 || leftStick.Horizontal == 0*/)
        {
            anim1.SetBool("isWalking", false);
        }

        //inputs

        //GhostControl();
        FlashlightControl();

        if (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.LeftShift)/* || CrossPlatformInputManager.GetButtonDown("run")*/)
        {
            GetComponent<AdvancedWalkerController>().movementSpeed = 5.5f;

            anim1.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button2) || Input.GetKeyUp(KeyCode.LeftShift)/* || CrossPlatformInputManager.GetButtonUp("run")*/)
        {
            GetComponent<AdvancedWalkerController>().movementSpeed = 2.5f;

            anim1.SetBool("isRunning", false);
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Space)/* || CrossPlatformInputManager.GetButtonDown("jumpMobile")*/)
        {
            anim1.SetTrigger("jump");
        }
    }

    void FlashlightControl()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.F)/* || CrossPlatformInputManager.GetButtonDown("flashlight")*/)
        {
            flashNum++;
        }
        if (flashNum > 1)
        {
            flashNum = 0;
        }
        if (flashNum == 0)
        {
            flashlight.SetActive(true);
        }
        if (flashNum == 1)
        {
            flashlight.SetActive(false);
        }
    }

    //void GhostControl()
    //{
    //    if (Input.GetKeyUp(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.G))
    //    {
    //        ghostNum++;
    //    }
    //    if (ghostNum > 1)
    //    {
    //        ghostNum = 0;
    //    }
    //    if (ghostNum == 0)
    //    {
    //        gameObject.layer = 7;
    //        player1.GetComponent<SkinnedMeshRenderer>().material = material2;
    //    }
    //    if (ghostNum == 1)
    //    {
    //        gameObject.layer = 0;
    //        player1.GetComponent<SkinnedMeshRenderer>().material = material1;
    //    }
    //}

    void PlayerMovementMobile()
    {
        //float speed = 2;
        //float rotationSpeed = 5;

        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(leftStick.Horizontal, 0, leftStick.Vertical);
        //transform.Translate(movement * speed * Time.deltaTime, Space.World);

        ////var step = rotationSpeed * Time.deltaTime;

        //if (leftStick.Vertical > 0 || leftStick.Horizontal > 0)
        //{
        //    GetComponent<AdvancedWalkerController>().movementSpeed = 5.5f;

        //    anim1.SetBool("isWalking", true);

        //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetUp.rotation, step);
        //}
    }
}
