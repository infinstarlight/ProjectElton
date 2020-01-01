using UnityEngine.InputSystem;
using UnityEngine;


public class InputSystemPlayerMovement : MonoBehaviour
{
    public float myWalkSpeed = 4.0f;
    public float myRunSpeed = 8.0f;
    public float mySlideSpeed = 10.0f;
    public float myCrouchSpeed = 2f;
    [SerializeField]
    private float myJumpSpeed = 8.0f;
    [SerializeField]
    private float isGravity = 20.0f;
    [SerializeField]
    private float isAntiBumpFactor = .75f;
    [HideInInspector]
    public Vector3 myMoveDirection = Vector3.zero;
    [HideInInspector]
    public Vector3 myContactPoint;
    [HideInInspector]
    public CharacterController IS_Controller;
    [HideInInspector]
    public bool bPlayerControl = false;

    public bool bIsGrounded = false;
    public Vector3 myJump = Vector3.zero;

    private RaycastHit myHit;
    private Vector3 myForce;
    private bool myForceGravity;
    private float myForceTime = 0;
    private void Awake()
    {
        // Saving component references to improve performance.
        IS_Controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (myForceTime > 0)
            myForceTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (myForceTime > 0)
        {
            if (myForceGravity)
                myMoveDirection.y -= isGravity * Time.deltaTime;
            bIsGrounded = (IS_Controller.Move(myMoveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        }
    }

    public void LateFixedUpdate()
    {

    }

    public void Move(Vector2 input, bool sprint, bool crouching)
    {
        if (myForceTime > 0)
            return;

        float speed = (!sprint) ? myWalkSpeed : myRunSpeed;
        if (crouching) speed = myCrouchSpeed;

        if (bIsGrounded)
        {
            myMoveDirection = new Vector3(input.x, -isAntiBumpFactor, input.y);
            myMoveDirection = transform.TransformDirection(myMoveDirection) * speed;
            UpdateJump();
        }

        // Apply gravity
        myMoveDirection.y -= isGravity * Time.deltaTime;
        // Move the controller, and set grounded true or false depending on whether we're standing on something
        bIsGrounded = (IS_Controller.Move(myMoveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
    }

    public void Move(Vector3 direction, float speed, float appliedGravity)
    {
        if (myForceTime > 0)
            return;

        Vector3 move = direction * speed;
        if (appliedGravity > 0)
        {
            myMoveDirection.x = move.x;
            myMoveDirection.y -= isGravity * Time.deltaTime * appliedGravity;
            myMoveDirection.z = move.z;
        }
        else
            myMoveDirection = move;

        UpdateJump();

        bIsGrounded = (IS_Controller.Move(myMoveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
    }

    public void Jump(Vector3 dir, float mult)
    {
        myJump = dir * mult;
    }

    public void UpdateJump()
    {
        if (myJump != Vector3.zero)
        {
            Vector3 dir = (myJump * myJumpSpeed);
            if (dir.x != 0) myMoveDirection.x = dir.x;
            if (dir.y != 0) myMoveDirection.y = dir.y;
            if (dir.z != 0) myMoveDirection.z = dir.z;
        }
        myJump = Vector3.zero;
    }

    public void ForceMove(Vector3 direction, float speed, float time, bool applyGravity)
    {
        myForceTime = time;
        myForceGravity = applyGravity;
        myMoveDirection = direction * speed;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        myContactPoint = hit.point;
    }
}
