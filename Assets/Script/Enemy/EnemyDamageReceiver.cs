using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{

    protected override void OnDead()
    {
        enemyCtrl.EnemyDespawn.DespawnEnemy();
    }

   
}
