using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance;}

    public static string worm = "worm";
    public static string wolf = "wolf";

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }

    public virtual void SpawnWormAtPoint(Transform point, string enemy)         // spawn enemy tại điểm truyền vào
    {
        Transform obj = Spawn(enemy, point.position, point.rotation);
        obj.gameObject.SetActive(true);
        obj.parent = point;
    }

}
