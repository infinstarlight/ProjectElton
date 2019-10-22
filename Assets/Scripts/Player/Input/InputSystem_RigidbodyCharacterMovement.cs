using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputSystem_RigidbodyCharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 10.0f;
    public float SprintSpeed = 20.0f;

    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask GroundLayer;


    private Rigidbody rb;
    private PlayerStatsScript playerStats;

    [SerializeField]
    private bool bIsGounded = true;

    [SerializeField]
    private int CurrentJumpCount = 0;
    [SerializeField]
    private int MaxJumpCount = 2;
    public Transform groundChecker;
    float translation;
    private Vector2 moveVector;
    float strafe;
    public bool bHoldSprint = false;

    Vector3 dashVelocity;
    private float oldMovementSpeed;
    

    void Awake()
    {
        //pCon = GetComponentInChildren<InputSystem_PlayerController>();
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
        playerStats = GetComponent<PlayerStatsScript>();


    }

    // Start is called before the first frame update
    void Start()
    {
        oldMovementSpeed = MovementSpeed;
        playerStats.currentSpecialAbility = PlayerStatsScript.ESpecialAbility.Dash;
    }

    // Update is called once per frame
    void Update()
    {
        bIsGounded = Physics.CheckSphere(groundChecker.position, GroundDistance, GroundLayer, QueryTriggerInteraction.Ignore);

        if (bIsGounded && CurrentJumpCount >= 1)
        {
            CurrentJumpCount = 0;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(strafe, 0, translation);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                {
                    MovementSpeed = SprintSpeed;
                }
                break;

            case InputActionPhase.Started:
                {
                    if (context.interaction is HoldInteraction)
                    {
                        if (bHoldSprint)
                        {
                            MovementSpeed = SprintSpeed;
                        }
                    }
                }
                break;
            case InputActionPhase.Canceled:
                {
                    MovementSpeed = oldMovementSpeed;
                }
                break;
        }
    }

    public void OnSpecialAbility(InputAction.CallbackContext context)
    {
        if (playerStats.currentSpecialAbility == PlayerStatsScript.ESpecialAbility.Dash)
                {
                    dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
                    rb.AddForce(dashVelocity, ForceMode.VelocityChange);
                }
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        CurrentJumpCount++;
        if (CurrentJumpCount <= MaxJumpCount)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
    public void OnMoveUp(InputAction.CallbackContext context)
    {
        var yValue = context.ReadValue<float>();
        translation = yValue * MovementSpeed * Time.deltaTime;

    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        var xValue = context.ReadValue<float>();
        strafe = xValue * MovementSpeed * Time.deltaTime;

    }


    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && Application.isEditor)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, GroundDistance);
        }

    }
}