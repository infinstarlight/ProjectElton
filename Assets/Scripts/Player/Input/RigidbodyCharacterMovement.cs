using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 10.0f;

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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetButtonDown("Jump"))
        {
              CurrentJumpCount = CurrentJumpCount + 1;
                if(CurrentJumpCount <= MaxJumpCount)
                {
                     rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2 * Physics.gravity.y),ForceMode.VelocityChange);  
                }
        }
        if(CurrentJumpCount >= MaxJumpCount && bIsGounded)
        {
            CurrentJumpCount = 0;
        }

        if(Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
            rb.AddForce(dashVelocity,ForceMode.VelocityChange);
        }
        translation = Input.GetAxis("Vertical") * MovementSpeed;
        strafe = Input.GetAxis("Horizontal") * MovementSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        

     if(Input.GetButtonDown("Pause"))
     {
         Cursor.lockState = CursorLockMode.None;
     }
    }

    void FixedUpdate()
    {
        transform.Translate(strafe,0,translation);
         bIsGounded = Physics.CheckSphere(groundChecker.position,GroundDistance,Ground,QueryTriggerInteraction.Ignore);
        //rb.MovePosition(rb.position + inputMovement * MovementSpeed * Time.fixedDeltaTime);
    }
}
