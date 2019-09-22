using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 10.0f;

    float translation;
    float strafe;

    // Start is called before the first frame update
    void Start()
    {
        if(Cursor.lockState != CursorLockMode.Locked);
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * MovementSpeed;
        strafe = Input.GetAxis("Horizontal") * MovementSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe,0,translation);

     if(Input.GetButtonDown("Pause"))
     {
         Cursor.lockState = CursorLockMode.None;
     }
    }
}
