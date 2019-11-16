using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class UnityEventWithFloat : UnityEvent<float>
{
}

public interface IKillable
{
    void OnDeath();
}

public interface IDamageable<T>
{
    void OnDamageApplied(T damageTaken);

    
}

public interface ITracker
{
    void OnTrackTarget();
}


