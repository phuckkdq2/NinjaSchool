using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        this.OnDeadFx();
        enemyCtrl.EnemyDespawn.DespawnEnemy();              // Despawn enemy 
    }

    protected virtual void OnDeadFx()
    {
        string fxName = this.GetFxName();
        Transform fxOnDead = FxSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetFxName()
    {
        return FxSpawner.smokeOne;
    }

    public override void ReBorn()
    {
        this.hpMax = this.enemyCtrl.EnemySO.hpMax;
        base.ReBorn();
    }

 
}
