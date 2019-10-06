using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    Vector2 mouseLook;
    //Ensures smooth motion
    Vector2 smoothingVector;
    //How sensitive should the change be
    public float LookSensitivity = 5.0f;
    public float SmoothingRate = 2.0f;

    private GameObject PlayerCharacter;
    private PlayerController pCon;
    private Camera PlayerCamera;
    private bool bStartLockOn = false;
    Vector2 LookDirection;
    Vector2 GamepadDirection;

    public RaycastHit LockOnHit;
    public float lockOnRange = 200f;
    //Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
    Ray lockOnRay;
    private Enemy currentEnemy;

    void Awake()
    {
        pCon = GetComponentInParent<PlayerController>();
        PlayerCamera = Camera.main;
        PlayerCharacter = FindObjectOfType<Player>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pCon.bEnableInput)
        {
            ///Commenting this line causes right angle turns, almost like Time Crisis
            PlayerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, PlayerCharacter.transform.up);
        }
        if (Input.GetButtonDown("AltAttack"))
        {
            bStartLockOn = true;
        }
        if (Input.GetButtonUp("AltAttack"))
        {
            bStartLockOn = false;
            if (currentEnemy)
            {
                currentEnemy.enemyUIController.bIsTargeted = false;
                currentEnemy = null;
            }
        }



    }

    private void LateUpdate()
    {
        if (pCon.bEnableInput)
        {
            //This section of code was originally done by someone(s) else, I cannot find where at this time, will update when found
            LookDirection = new Vector2(Input.GetAxisRaw("LookRight"), Input.GetAxisRaw("LookUp"));
            PlayerCamera.transform.localEulerAngles = new Vector3(LookDirection.x, PlayerCamera.transform.localEulerAngles.y, PlayerCamera.transform.localEulerAngles.z);

            LookDirection = Vector2.Scale(LookDirection, new Vector2(LookSensitivity * SmoothingRate, LookSensitivity * SmoothingRate));
            smoothingVector.x = Mathf.Lerp(smoothingVector.x, LookDirection.x, 1f / SmoothingRate);
            smoothingVector.y = Mathf.Lerp(smoothingVector.y, LookDirection.y, 1f / SmoothingRate);
            mouseLook += smoothingVector;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            //}
            LockOn();

        }
    }

    void LockOn()
    {
        int layerMask = 1 << 11;



        if (bStartLockOn)
        {
            Debug.DrawRay(lockOnRay.origin, lockOnRay.direction * lockOnRange, Color.blue);

            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
            lockOnRay = PlayerCamera.ViewportPointToRay(rayOrigin);
            // actual Ray

            if (Physics.SphereCast(lockOnRay, 24f, out LockOnHit, lockOnRange, layerMask, QueryTriggerInteraction.Collide))
            {

                if (LockOnHit.collider)
                {
                    currentEnemy = LockOnHit.collider.gameObject.GetComponent<Enemy>();
                    if (currentEnemy)
                    {
                        transform.LookAt(currentEnemy.gameObject.transform);
                        currentEnemy.enemyUIController.bIsTargeted = true;
                    }
                }
            }
            // if (Physics.Raycast(lockOnRay, out LockOnHit, lockOnRange))
            // {
            //     if (LockOnHit.collider)
            //     {
            //         currentEnemy = LockOnHit.collider.gameObject.GetComponent<Enemy>();
            //         if (currentEnemy)
            //         {
            //             transform.LookAt(currentEnemy.gameObject.transform);
            //             currentEnemy.enemyUIController.bIsTargeted = true;
            //         }
            //     }
            // }
        }

    }

}
