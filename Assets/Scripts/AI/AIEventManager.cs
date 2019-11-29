using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;



public class AIEventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> eventDictionary;
    //private Dictionary<string,MyFloatEvent> floateventDictionary;

   
    private static AIEventManager AIManager;

    public static AIEventManager instance
    {
        get
        {
            if (!AIManager)
            {
                AIManager = FindObjectOfType(typeof(AIEventManager)) as AIEventManager;

                if (!AIManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    AIManager.Init();
                }
            }

            return AIManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
        // if(floateventDictionary == null)
        // {
        //     floateventDictionary = new Dictionary<string, MyFloatEvent>();
        // }
    }


    // public static void StartListeningFloat(string eventName, MyFloatEvent floatListener)
    // {
    //      if (AIManager == null) return;
    //     MyFloatEvent thisFloatEvent = null;
    //     if(instance.floateventDictionary.TryGetValue(eventName,out thisFloatEvent))
    //     {
    //         thisFloatEvent.AddListener(floatListener);
    //     }
    //     else
    //     {
    //         thisFloatEvent = new MyFloatEvent();
    //         thisFloatEvent.AddListener(floatListener);
    //         instance.floateventDictionary.Add(eventName,thisFloatEvent);
    //     }
    // }
    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (AIManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent (string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.Invoke ();
        }
    }
}
