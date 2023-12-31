using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] List<SpawnPoints> spawnPoints;
    [SerializeField] List<Transform> Enemies;

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            EnemySpawner.Instance.SpawnEnemy(spawnPoints[i].points, Enemies[i]);
        }
    }
}

[Serializable]
public class SpawnPoints
{
    public List<Transform> points;
}
