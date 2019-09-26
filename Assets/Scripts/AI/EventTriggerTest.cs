using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
       void Update () {
        if (Input.GetKeyDown ("q"))
        {
            AIEventManager.TriggerEvent ("test");
        }

        if (Input.GetKeyDown ("o"))
        {
            AIEventManager.TriggerEvent ("Spawn");
        }

        if (Input.GetKeyDown ("p"))
        {
            AIEventManager.TriggerEvent ("Destroy");
        }

        if (Input.GetKeyDown ("x"))
        {
            AIEventManager.TriggerEvent ("Junk");
        }
    }
}
