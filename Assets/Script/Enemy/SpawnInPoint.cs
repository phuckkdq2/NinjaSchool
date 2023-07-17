using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInPoint : Darwin
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    [SerializeField] protected bool isDead;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnerCtrl();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if(this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = transform.GetComponent<EnemySpawnerCtrl>();
    }

    protected virtual void Start() {
        this.SpawnWormInpoint();
    }

    protected virtual void SpawnWormInpoint()
    {
        List<Transform> points = enemySpawnerCtrl.WormSpawnPoint.GetSpawnPoint();
        for(int i = 0 ; i< points.Count; i++)
        {
            EnemySpawner.Instance.SpawnEnemyAtPoint(points[i]);
            enemySpawnerCtrl.WormSpawnPoint.SetSpawnedStatus();
        }
    }

}
