using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

    private UnityAction someListener;
    private UnityAction DamageListener;

    void Awake ()
    {
        someListener = new UnityAction (SomeFunction);
        DamageListener = new UnityAction(AIDamageFunction);

    }

    void OnEnable ()
    {
        AIEventManager.StartListening ("test", someListener);
        AIEventManager.StartListening ("Spawn", SomeOtherFunction);
        AIEventManager.StartListening ("Destroy", SomeThirdFunction);
        AIEventManager.StartListening("Damage",DamageListener);
    }

    void OnDisable ()
    {
        AIEventManager.StopListening ("test", someListener);
        AIEventManager.StopListening ("Spawn", SomeOtherFunction);
        AIEventManager.StopListening ("Destroy", SomeThirdFunction);
        AIEventManager.StopListening("Damage",DamageListener);
    }

    void SomeFunction ()
    {
        Debug.Log ("Some Function was called!");
    }

    void AIDamageFunction()
    {
        Debug.Log("This Character has taken damage!");
    }


    void SomeOtherFunction ()
    {
        Debug.Log ("Some Other Function was called!");
    }

    void SomeThirdFunction ()
    {
        Debug.Log ("Some Third Function was called!");
    }
}