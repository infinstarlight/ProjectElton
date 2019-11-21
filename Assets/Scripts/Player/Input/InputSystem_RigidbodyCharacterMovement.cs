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


    private Rigidbody rb;
    private PlayerStatsScript playerStats;

    [SerializeField]
    private bool bIsGounded = true;

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


    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying && Application.isEditor)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, GroundDistance);
        }

    }
    public static void ToggleCollider(bool bEnable)
    {
        bEnable = !bEnable;
        if (!bEnable)
        {
            myCollider.enabled = false;
        }
        else
        {
            myCollider.enabled = true;
        }
    }
    [Command("noclip")]
    public static void ToggleNoClip()
    {
        bool bEnable = false;
        bEnable = !bEnable;
        ToggleCollider(bEnable);
    }


}