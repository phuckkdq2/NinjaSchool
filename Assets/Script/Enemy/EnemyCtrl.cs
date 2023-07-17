using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : Darwin
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
    }

    protected virtual void LoadEnemyDespawn()
    {
        if(this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
    }
}
