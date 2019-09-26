using System.Collections;
using System.Collections.Generic;
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

    private Rigidbody rb;
    private Vector3 inputMovement;

    // [SerializeField]
    // private bool bIsJumping = false;

    [SerializeField]
    private bool bIsGounded = true;

    [SerializeField]
    private int CurrentJumpCount = 0;
    [SerializeField]
    private int MaxJumpCount = 2;
    public Transform groundChecker;
    float translation;
    float strafe;

    Vector3 dashVelocity;
    private float oldMovementSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        oldMovementSpeed = MovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bIsGounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        if (bIsGounded && CurrentJumpCount >= 1)
        {
            CurrentJumpCount = 0;
        }


        translation = Input.GetAxis("Vertical") * MovementSpeed;
        strafe = Input.GetAxis("Horizontal") * MovementSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

    if(Input.GetButtonDown("Sprint"))
    {
        MovementSpeed = SprintSpeed;
    }
    if(Input.GetButtonUp("Sprint"))
    {
        MovementSpeed = oldMovementSpeed;
    }

       
    }

    void FixedUpdate()
    {
        transform.Translate(strafe, 0, translation);
        if (Input.GetButtonDown("Jump"))
        {
            CurrentJumpCount++;
            if (CurrentJumpCount <= MaxJumpCount)
            {
                rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);
            }
        }
        if (Input.GetButtonDown("Dash"))
        {
            dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
            rb.AddForce(dashVelocity, ForceMode.VelocityChange);
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
}
