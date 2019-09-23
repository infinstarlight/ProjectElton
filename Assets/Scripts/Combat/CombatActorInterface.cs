using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable
{
    void OnDeath();
}

public interface IDamageable<T>
{
    void OnDamageApplied(T damageTaken);
}
