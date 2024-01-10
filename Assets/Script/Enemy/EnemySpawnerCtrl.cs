using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : Darwin
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.Log(enemySpawner);
    }

}
