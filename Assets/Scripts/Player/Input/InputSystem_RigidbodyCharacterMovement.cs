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
    private bool bCanJump = false;

    [SerializeField]
    private int CurrentJumpCount = 0;
    [SerializeField]
    private int MaxJumpCount = 2;

    [SerializeField]
    private int CurrentDashCount = 0;
    [SerializeField]
    private int MaxDashCount = 2;
    public Transform groundChecker;
    private float translation = 0.0f;
    private Vector2 moveVector = new Vector2(0.0f, 0.0f);
    private float strafe = 0.0f;
    private float xValue = 0.0f;
    private float yValue = 0.0f;
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
        playerStats.currentCharacterAction = PlayerStatsScript.ECharacterActions.Dash;
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
        if (CurrentJumpCount <= MaxJumpCount)
        {
            bCanJump = true;
        }
        else
        {
            bCanJump = false;
        }

    }

    void FixedUpdate()
    {
        transform.Translate(strafe, 0, translation);
        if (bIsInAir)
        {
            rb.AddForce(Vector3.down * 25.0f, ForceMode.Acceleration);
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
        if (playerStats.currentCharacterAction == PlayerStatsScript.ECharacterActions.Dash)
        {
            CurrentDashCount += 1;
        }


    }

    void ActivateSpecialAbility()
    {
        if (playerStats.currentCharacterAction == PlayerStatsScript.ECharacterActions.Dash)
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
        moveVector = context.ReadValue<Vector2>();
        MoveRight(moveVector.x);
        MoveUp(moveVector.y);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void OnMoveUp(InputAction.CallbackContext context)
    {
        yValue = context.ReadValue<float>();
        MoveUp(yValue);

    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        xValue = context.ReadValue<float>();
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
        float nextJump = 0.0f;
        float jumpRate = 0.25f;
        if (Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;
            ++CurrentJumpCount;
            if (bCanJump)
            {
                rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);
            }
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
        if (bEnable)
        {
            ToggleCollider(true);
        }
        else
        {
            ToggleCollider(false);
        }

    }


}