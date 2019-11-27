using System.Collections;
using Popcron.Console;
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


    public static Rigidbody rb;
    private PlayerStatsScript playerStats;

    [SerializeField]
    private bool bIsGounded = true;
    private bool bIsInAir = false;

    [SerializeField]
    private int CurrentJumpCount = 0;
    [SerializeField]
    private int MaxJumpCount = 2;

    [SerializeField]
    private int CurrentDashCount = 0;
    [SerializeField]
    private int MaxDashCount = 2;
    public Transform groundChecker;
    float translation = 0.0f;
    private Vector2 moveVector = new Vector2(0.0f, 0.0f);
    float strafe = 0.0f;
    public bool bHoldSprint = false;
    [SerializeField]
    private float DashWaitPeriod = 3.0f;

    Vector3 dashVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    private float oldMovementSpeed = 0.0f;
    private bool bIsDashCooldownRunning = false;
    public static CapsuleCollider myCollider;


    void Awake()
    {
        //pCon = GetComponentInChildren<InputSystem_PlayerController>();
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
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
        bIsInAir = !bIsGounded;
        if (bIsGounded && CurrentJumpCount >= 1)
        {
            CurrentJumpCount = 0;
        }

    }

    void FixedUpdate()
    {
        transform.Translate(strafe, 0, translation);
        if(bIsInAir)
        {
            rb.AddForce(Vector3.down * 50.0f,ForceMode.Acceleration);
        }
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
                    // if (context.interaction is HoldInteraction)
                    // {
                    //     MovementSpeed = SprintSpeed;
                    // }
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
        ActivateSpecialAbility();
        if (playerStats.currentSpecialAbility == PlayerStatsScript.ESpecialAbility.Dash)
        {
            CurrentDashCount += 1;
        }


    }

    void ActivateSpecialAbility()
    {
        if (playerStats.currentSpecialAbility == PlayerStatsScript.ESpecialAbility.Dash)
        {

            if (CurrentDashCount <= MaxDashCount)
            {
                bIsDashCooldownRunning = false;
                dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
                rb.AddForce(dashVelocity, ForceMode.VelocityChange);
                if (bIsDashCooldownRunning)
                {
                    StopCoroutine(StartDashCooldown());
                }

            }
            else
            {
                bIsDashCooldownRunning = false;
                StartCoroutine(StartDashCooldown());
            }

        }
    }

    public void OnMoveUpdate(InputAction.CallbackContext context)
    {
        var moveValue = context.ReadValue<Vector2>();
        MoveRight(moveValue.x);
        MoveUp(moveValue.y);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void OnMoveUp(InputAction.CallbackContext context)
    {
        var yValue = context.ReadValue<float>();
        MoveUp(yValue);

    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        var xValue = context.ReadValue<float>();
        MoveRight(xValue);

    }

    IEnumerator StartDashCooldown()
    {
        if (!bIsDashCooldownRunning)
        {
            bIsDashCooldownRunning = true;
            yield return new WaitForSeconds(DashWaitPeriod);
            if (CurrentDashCount >= MaxDashCount)
            {
                CurrentDashCount = 0;
                bIsDashCooldownRunning = false;
            }
        }

    }

    public void Jump()
    {
        CurrentJumpCount++;
        if (CurrentJumpCount <= MaxJumpCount)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    public void MoveRight(float inputValue)
    {
        strafe = inputValue * MovementSpeed * Time.deltaTime;
    }

    public void MoveUp(float inputValue)
    {
        translation = inputValue * MovementSpeed * Time.deltaTime;
    }


    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && Application.isEditor)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, GroundDistance);
        }

    }
    public static void ToggleCollider(bool bEnableFunc)
    {
        bEnableFunc = !bEnableFunc;
        if (!bEnableFunc)
        {
            myCollider.enabled = false;
            rb.isKinematic = true;
        }
        else
        {
            myCollider.enabled = true;
            rb.isKinematic = false;
        }
    }
    [Command("noclip")]
    public static void ToggleNoClip()
    {
        bool bEnable = false;
        bEnable = !bEnable;
        if(bEnable)
        {
            ToggleCollider(true);
        }
        else
        {
            ToggleCollider(false);
        }
        
    }


}