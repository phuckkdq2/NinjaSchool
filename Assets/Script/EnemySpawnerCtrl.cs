using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : Darwin
{
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint { get => spawnPoint;}
    
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn;}


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
        // this.LoadDespawn();
    }

    protected virtual void LoadSpawnPoint()
    {
        if(this.spawnPoint != null) return;
        this.spawnPoint = transform.GetComponentInChildren<SpawnPoint>();
    }

    // protected virtual void LoadDespawn()
    // {
    //     if(this.enemyDespawn != null) return;
    //     this.enemyDespawn = transform.GetChild(0).GetComponentInChildren<EnemyDespawn>();
    // }

}
