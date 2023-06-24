using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner
{
    [SerializeField] protected Transform enemy;                         // biến hứng enemy để spawn
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;

    private static EnemySpawn instance;
    public static EnemySpawn Instance { get => instance;}

    void Start()
    {
        this.SpawnEnemies();
    }

    protected override void Awake()
    {
        base.Awake();
        EnemySpawn.instance = this;
    }

    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnerCtrl();
        this.LoadEnemy();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if(this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = transform.GetComponent<EnemySpawnerCtrl>();
    }

    protected virtual void LoadEnemy()
    {
        if(this.enemy != null) return;
        this.enemy = transform.Find("Prefabs");
        enemy.gameObject.SetActive(false);
    }

    public void SpawnEnemies()
    {
        List<Vector3> listPos = enemySpawnerCtrl.SpawnPoint.GetSpawnPositions();        // duyệt qua các điểm để spawn
        foreach(Vector3 pos in listPos)                                                 // lấy ra các điểm 
        {
           Transform objs = Spawn(enemy, pos, Quaternion.identity);                     
           objs.gameObject.SetActive(true);
        }
    }

    
}
