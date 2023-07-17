using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance;}

    public static string Worm = "Worm";

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }

    public virtual void SpawnEnemyAtPoint(Transform point)
    {
        Transform obj = Spawn(EnemySpawner.Worm, point.position, point.rotation);
        obj.gameObject.SetActive(true);
        obj.parent = point;
    }

}
