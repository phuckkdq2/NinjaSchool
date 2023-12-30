using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : Darwin
{    
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner;}

    // [SerializeField] protected WormSpawnPoint wormSpawnPoint;
    // public WormSpawnPoint WormSpawnPoint { get => wormSpawnPoint;}

    // [SerializeField] protected WolfSpawnPoint wolfSpawnPoint;
    // public WolfSpawnPoint WolfSpawnPoint { get => wolfSpawnPoint;}


    protected override void LoadComponent()
    {
        base.LoadComponent();
        // this.LoadWormSpawnPoint();
        // this.LoadWolfSpawnPoint();
        this.LoadEnemySpawner();

    }

    // protected virtual void LoadWormSpawnPoint()
    // {
    //     if(this.wormSpawnPoint != null) return;
    //     this.wormSpawnPoint = Transform.FindObjectOfType<WormSpawnPoint>();
    // }
    
    // protected virtual void LoadWolfSpawnPoint()
    // {
    //     if(this.wolfSpawnPoint != null) return;
    //     this.wolfSpawnPoint = Transform.FindObjectOfType<WolfSpawnPoint>();
    // }

    protected virtual void LoadEnemySpawner()
    {
        if(this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.Log(enemySpawner);
    }


}
