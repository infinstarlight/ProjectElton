using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 10.0f;
    public float SprintSpeed = 20.0f;

    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;
    private GameInputControls myControls;

    private Rigidbody rb;
    private PlayerController pCon;
    private PlayerStatsScript playerStats;
    private Vector3 inputMovement;

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
    private float MoveX;
    private float MoveY;

    Vector3 dashVelocity;
    private float oldMovementSpeed;


    public void OnEnable()
    {

    }

    public void OnDisable()
    {

    }


    void Awake()
    {
        pCon = GetComponentInChildren<PlayerController>();
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
        playerStats = GetComponent<PlayerStatsScript>();
        myControls = new GameInputControls();
        var moveUpAction = new InputAction("MoveUp");
        moveUpAction.AddCompositeBinding("Axis").With("Positive","<Keyboard>/w").With("Negative","<Keyboard>/s");
       



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
        bIsGounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        if (bIsGounded && CurrentJumpCount >= 1)
        {
            CurrentJumpCount = 0;
        }

        MoveX = Keyboard.current.dKey.ReadValue();

        MoveY = Keyboard.current.wKey.ReadValue();
        OnMoveRight(MoveX);
        OnMoveUp(MoveY);


    }

    void FixedUpdate()
    {
        if (pCon.bEnableInput)
        {

            if (Input.GetButtonDown("Jump"))
            {
                CurrentJumpCount++;
                if (CurrentJumpCount <= MaxJumpCount)
                {
                    rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);
                }
            }
            if (Input.GetButtonDown("Special Ability"))
            {
                if (playerStats.currentSpecialAbility == PlayerStatsScript.ESpecialAbility.Dash)
                {
                    dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
                    rb.AddForce(dashVelocity, ForceMode.VelocityChange);
                }

            }
        }

    }

    public void PlayerMoveRight(InputAction.CallbackContext context)
    {
        OnMoveRight(MoveX);
    }

    public void PlayerMoveUp(InputAction.CallbackContext context)
    {
        OnMoveRight(MoveY);
    }

    public void OnMoveUp(float moveY)
    {
        strafe = moveY * MovementSpeed;
        strafe *= Time.deltaTime;
    }

    public void OnMoveRight(float moveX)
    {
        translation = moveX * MovementSpeed;
        translation *= Time.deltaTime;
    }

    public void IS_Move(float moveX, float moveY)
    {
        transform.Translate(strafe, 0, translation);
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
