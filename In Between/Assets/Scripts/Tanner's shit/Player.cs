using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;

    public GameObject currentCharacter;
    public GameObject model_root;

    [Range(0, 20)] public float movement_speed;
    [Range(0, 20)] public float jump_power;

    public Vector2 movement_direction;

    Player_Inputs inputs;
    Rigidbody rb;
    Animator animator;

    private void OnEnable()
    {
        if(inputs == null)
        {
            inputs = new Player_Inputs();
        }

        inputs.Player.Movement.performed += Movement;
        inputs.Player.Movement.canceled += Movement;
        inputs.Player.Jump.performed += Jump;
        inputs.Player.Sprint.performed += Sprint;
        inputs.Player.Sprint.canceled += Sprint;
        inputs.Player.ChangeCharacter.performed += ChangeCharacter;
        inputs.Player.Enable();
    }

    private void Start()
    {
        if (currentCharacter)
        {
            animator = currentCharacter.GetComponentInChildren<Animator>();
            rb = currentCharacter.GetComponent<Rigidbody>();
            mainCamera.Follow = currentCharacter.transform;
        }
        else { Debug.Log("Player script is missing a reference to a starting character"); }
    }

    private void FixedUpdate()
    {
       currentCharacter.transform.position += new Vector3(movement_direction.x, 0, movement_direction.y) * movement_speed * Time.deltaTime;
    }

    public void ChangeCharacter(InputAction.CallbackContext context)
    {
        IControllable[] c = GetComponentsInChildren<IControllable>();

        for(int i = 0; i < c.Length; i++)
        {
            if (c[i].IsControlled() == false)
            {
                currentCharacter.GetComponent<IControllable>().DisableControl();
                currentCharacter = c[i].EnableControl();
                rb = currentCharacter.GetComponent<Rigidbody>();
                animator = currentCharacter.GetComponentInChildren<Animator>();
                mainCamera.Follow = currentCharacter.transform;
                model_root = currentCharacter.GetComponent<AI>().model_root;
                break;
            }
        }
    }

    #region MOVEMENT
    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed) { animator.SetBool("isWalking", true); }
        else if (context.canceled) { animator.SetBool("isWalking", false); }

        movement_direction = context.ReadValue<Vector2>();

        Vector3 position = currentCharacter.transform.position + new Vector3(movement_direction.x, 0, movement_direction.y);

        model_root.transform.LookAt(new Vector3(position.x, model_root.transform.position.y, position.z), Vector3.up);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(transform.position, Vector3.down, 5f)){
            rb.velocity += new Vector3(0, jump_power, 0);
            animator.SetTrigger("jump");
        }
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed) { movement_speed *= 1.30f; animator.SetBool("isRunning", true); }
        else if (context.canceled) { movement_speed /= 1.30f; animator.SetBool("isRunning", false); } 
    }
    #endregion
    private void OnDisable()
    {
        inputs.Player.Disable();
    }
}
