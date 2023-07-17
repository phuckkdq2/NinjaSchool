using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : Darwin
{    
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner;}

    [SerializeField] protected WormSpawnPoint wormSpawnPoint;
    public WormSpawnPoint WormSpawnPoint { get => wormSpawnPoint;}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadSpawnPoint()
    {
        if(this.wormSpawnPoint != null) return;
        this.wormSpawnPoint = Transform.FindObjectOfType<WormSpawnPoint>();
    }

    protected virtual void LoadEnemySpawner()
    {
        if(this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponent<EnemySpawner>();
        Debug.Log(enemySpawner);
    }

}
