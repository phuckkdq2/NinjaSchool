using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner
{
    [SerializeField] protected Transform enemy;
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;

    // [SerializeField] private SpawnPoint spawnPoint;

    // public SpawnPoint SpawnPoint { get => spawnPoint; }

    void Start()
    {
        this.SpawnEnemies();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnerCtrl();
        this.LoadEnemy();
        // this.LoadSpawnPoint();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if(this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = transform.GetComponent<EnemySpawnerCtrl>();
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = transform.Find("Enemy");
    }

    // protected virtual void LoadSpawnPoint()
    // {
    //     if(this.spawnPoint != null) return;
    //     this.spawnPoint = FindObjectOfType<SpawnPoint>();
    // }

    public void SpawnEnemies()
    {
        List<Vector3> listPos = enemySpawnerCtrl.SpawnPoint.GetSpawnPositions();
        foreach(Vector3 pos in listPos)
        {
            Spawn(enemy, pos, Quaternion.identity);
            
        }

        
    }

    
}
