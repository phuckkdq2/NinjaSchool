using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInPoint : Darwin
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    [SerializeField] protected List<Transform> enemySpawnPoint1;
    [SerializeField] protected List<Transform> enemySpawnPoint2;

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
        this.SpawnEnemy(enemySpawnPoint1, EnemySpawner.worm);
        this.SpawnEnemy(enemySpawnPoint2,EnemySpawner.wolf);
    }

    protected virtual void SpawnEnemy(List<Transform> points, string e)
    {
        foreach(Transform point in points)                          // duyệt qua list điểm 
        {
            EnemySpawner.Instance.SpawnWormAtPoint(point, e);       // spawn enemy tại điểm đó với tham sô truyền vào là tên enemy 
        }
    }

}
