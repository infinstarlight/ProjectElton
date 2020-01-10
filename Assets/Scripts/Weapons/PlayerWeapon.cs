using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerWeapon : Weapon
{

    private Camera PlayerCamera;
    private GameObject cameraGO;
    public int CurrentLevel = 1;
    private int MaxLevel = 5;



    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main;
        cameraGO = PlayerCamera.gameObject;

        aimGO = cameraGO;
        aimGO = cameraGO;
        bIsPlayerWeapon = true;
    }

    void Update()
    {
        if (!PlayerCamera)
        {
            PlayerCamera = Camera.main;
        }
        if (bIsChargeWeapon)
        {
            if (Gamepad.current != null)
            {
                GamepadChargeMod = Gamepad.current.rightTrigger.ReadValue();
            }

        }

    }




}
