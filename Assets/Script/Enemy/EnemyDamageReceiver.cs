using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        enemyCtrl.EnemyDespawn.DespawnEnemy();              // Despawn enemy 
    }

    public override void ReBorn()
    {
        this.hpMax = this.enemyCtrl.EnemySO.hpMax;
        base.ReBorn();
    }

 
}
