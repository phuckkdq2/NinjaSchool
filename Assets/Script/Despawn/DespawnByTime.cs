using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected float timer = 0 ;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }
    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }
    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer > timeDelay) return true;
        return false;
    }
}
