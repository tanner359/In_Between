using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;

    public GameObject currentCharacter;

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
        transform.position += new Vector3(movement_direction.x, 0, movement_direction.y) * movement_speed * Time.deltaTime;
    }

    public void ChangeCharacter(InputAction.CallbackContext context)
    {
        IControllable[] c = GetComponentsInChildren<IControllable>();
        foreach(IControllable i in c)
        {
            if(i.IsControlled() == false)
            {
                currentCharacter.GetComponent<IControllable>().DisableControl();
                currentCharacter = i.EnableControl();
                rb = currentCharacter.GetComponent<Rigidbody>();
                animator = currentCharacter.GetComponentInChildren<Animator>();
            }
        }
    }

    #region MOVEMENT
    public void Movement(InputAction.CallbackContext context)
    {
        movement_direction = context.ReadValue<Vector2>();      
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
