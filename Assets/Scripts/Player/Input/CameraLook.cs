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

    GameObject PlayerCharacter;

    void Awake()
    {
        PlayerCharacter = FindObjectOfType<Player>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var MouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        MouseDirection = Vector2.Scale(MouseDirection, new Vector2(LookSensitivity * SmoothingRate,LookSensitivity * SmoothingRate));
        smoothingVector.x = Mathf.Lerp(smoothingVector.x,MouseDirection.x, 1f/SmoothingRate);
        smoothingVector.y = Mathf.Lerp(smoothingVector.y,MouseDirection.y, 1f/SmoothingRate);
        mouseLook += smoothingVector;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y,Vector3.right);
        ///Commenting this line causes right angle turns, almost like Time Crisis
        PlayerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x,PlayerCharacter.transform.up);
    }
}
