using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem_CameraLook : MonoBehaviour
{

    public Vector2 mouseLook;
    //Ensures smooth motion
    Vector2 smoothingVector;
    //How sensitive should the change be
    public float LookSensitivity = 5.0f;
    public float SmoothingRate = 2.0f;

    private GameObject PlayerCharacter;
    private InputSystem_PlayerController pCon;
    private Camera PlayerCamera;
    private bool bStartLockOn = false;
    Vector2 LookDirection;
    private Vector2 lookInput;

    public RaycastHit LockOnHit;
    public float lockOnRange = 200f;
    Ray lockOnRay;
    private Enemy currentEnemy;
    public float DefaultFOV = 90.0f;
    public float ZoomFOV = 65.0f;
    float newFOV;
    public float lockOnRadius = 24f;
    private PlayerConfig GetPlayerConfig;


    void Awake()
    {
        GetPlayerConfig = FindObjectOfType<PlayerConfig>();
        pCon = GetComponentInParent<InputSystem_PlayerController>();
        PlayerCamera = gameObject.GetComponent<Camera>();
        PlayerCharacter = FindObjectOfType<Player>().gameObject;

        if (LookSensitivity <= 0.0f)
        {
            LookSensitivity = 5.0f;
        }
        // else
        // {
        //     LookSensitivity = GetPlayerConfig.currentMouseSensitivity;
        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerCamera)
        {
            PlayerCamera = Camera.main;
        }
        // if (pCon.bEnableInput)
        // {
        ///Commenting this line causes right angle turns, almost like Time Crisis
        PlayerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, PlayerCharacter.transform.up);
        //}
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        var lookValue = context.ReadValue<Vector2>();
        lookInput = lookValue;

    }

    public void OnLockOn(InputAction.CallbackContext context)
    {
        bStartLockOn = !bStartLockOn;

    }
    public void OnLockOnStop(InputAction.CallbackContext context)
    {
        bStartLockOn = false;
        if (currentEnemy)
        {
            currentEnemy.enemyUIController.bIsTargeted = false;
            currentEnemy = null;
        }
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        var zoomValue = context.ReadValue<float>();
        newFOV = zoomValue * 10.0f;
    }



    private void LateUpdate()
    {
        if (pCon.bEnableGameInput)
        {
            //This section of code was originally done by someone(s) else, I cannot find where at this time, will update when found
            LookDirection = new Vector2(lookInput.x, lookInput.y);
            PlayerCamera.transform.localEulerAngles = new Vector3(LookDirection.x, PlayerCamera.transform.localEulerAngles.y, PlayerCamera.transform.localEulerAngles.z);

            //Debug.Log(LookDirection);

            LookDirection = Vector2.Scale(LookDirection, new Vector2(LookSensitivity * SmoothingRate, LookSensitivity * SmoothingRate));
            smoothingVector.x = Mathf.Lerp(smoothingVector.x, LookDirection.x, 1f / SmoothingRate);
            smoothingVector.y = Mathf.Lerp(smoothingVector.y, LookDirection.y, 1f / SmoothingRate);
            mouseLook += smoothingVector;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

            LockOn();
            PlayerCamera.fieldOfView += newFOV;
            PlayerCamera.fieldOfView = Mathf.Clamp(PlayerCamera.fieldOfView, ZoomFOV, DefaultFOV);

        }
    }

    void LockOn()
    {
        if (bStartLockOn)
        {
            Debug.DrawRay(lockOnRay.origin, lockOnRay.direction * lockOnRange, Color.blue);

            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
            lockOnRay = PlayerCamera.ViewportPointToRay(rayOrigin);
            // actual Ray

            // if (Physics.Raycast(lockOnRay, out LockOnHit, lockOnRange))
            // {
            //     if (LockOnHit.collider)
            //     {
            //         currentEnemy = LockOnHit.collider.gameObject.GetComponent<Enemy>();
            //         if (currentEnemy)
            //         {
            //             transform.LookAt(currentEnemy.gameObject.transform);
            //             currentEnemy.enemyUIController.bIsTargeted = true;
            //             Debug.Log("Hit: " + currentEnemy.name);
            //         }
            //     }
            // }
            if (Physics.SphereCast(lockOnRay.origin, lockOnRadius, lockOnRay.direction, out LockOnHit, lockOnRange))
            {
                if (LockOnHit.collider)
                {
                    currentEnemy = LockOnHit.collider.gameObject.GetComponent<Enemy>();
                    if (currentEnemy)
                    {
                        transform.LookAt(currentEnemy.gameObject.transform);
                        currentEnemy.enemyUIController.bIsTargeted = true;
                        Debug.Log("Hit: " + currentEnemy.name);
                    }
                }
            }
        }

    }
    void OnDrawGizmos()
    {
        if (bStartLockOn)
        {
            if (LockOnHit.collider)
            {
                //Draw a Ray forward from GameObject toward the hit
                Gizmos.DrawRay(transform.position, transform.forward * LockOnHit.distance);
                //Draw a cube that extends to where the hit exists
                Gizmos.DrawWireSphere(transform.position + transform.forward * LockOnHit.distance, lockOnRadius);
            }
            //If there hasn't been a hit yet, draw the ray at the maximum distance
            else
            {
                //Draw a Ray forward from GameObject toward the maximum distance
                Gizmos.DrawRay(transform.position, transform.forward * lockOnRange);
                //Draw a cube at the maximum distance
                Gizmos.DrawWireSphere(transform.position + transform.forward * lockOnRange, lockOnRadius);
            }
        }

    }

}
