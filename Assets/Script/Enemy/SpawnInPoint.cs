using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInPoint : Darwin
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;

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
        List<Transform> wormPoints = enemySpawnerCtrl.WormSpawnPoint.GetSpawnPoint();
        this.SpawnEnemy(wormPoints, EnemySpawner.worm);
        List<Transform> wolfPoints = enemySpawnerCtrl.WolfSpawnPoint.GetSpawnPoint();
        this.SpawnEnemy(wolfPoints,EnemySpawner.wolf);
    }

    protected virtual void SpawnEnemy(List<Transform> points, string e)
    {
        foreach(Transform point in points)                          // duyệt qua list điểm 
        {
            EnemySpawner.Instance.SpawnWormAtPoint(point, e);       // spawn enemy tại điểm đó với tham sô truyền vao flaf tên enemy 
        }
    }

}
