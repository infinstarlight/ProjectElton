using UnityEngine.Events;
using UnityEngine;
[System.Serializable]
public class UnityIntEvent : UnityEvent<int>
{
}

[System.Serializable]
public class UnityFloatEvent : UnityEvent<float>
{
}
[System.Serializable]
public class UnityEAmmoEvent : UnityEvent<EAmmoType>
{

}

[System.Serializable]
public class UnityRigidbodyEvent :UnityEvent<Rigidbody>
{

}

public interface IKillable
{
    void OnDeath();
    
}

public interface IDamageable<T>
{
    void OnDamageApplied(T damageTaken);
    void DamageProcessor(EAmmoType damageType);
}

public interface ITracker
{
    void OnTrackTarget();
}


