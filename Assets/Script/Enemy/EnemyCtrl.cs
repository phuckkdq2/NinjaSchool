using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : Darwin
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get => enemySO;}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
        this.LoadEnemySO();
    }

    protected virtual void LoadEnemyDespawn()
    {
        if(this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
    }

    protected virtual void LoadEnemySO()
    {
        if(this.enemySO != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
    }
}
