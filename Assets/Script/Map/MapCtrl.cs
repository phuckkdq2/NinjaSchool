using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] List<SpawnPoints> spawnPoints;
    [SerializeField] List<Transform> Enemies;
    [SerializeField] public CinemachineVirtualCamera vcCamera;
    [SerializeField] public PlayerCtrl player;

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            EnemySpawner.Instance.SpawnEnemy(spawnPoints[i].points, Enemies[i]);
        }
    }

    private void OnEnable()
    {
        player = Transform.FindObjectOfType<PlayerCtrl>();
        vcCamera.Follow = player.transform;
    }
}

[Serializable]
public class SpawnPoints
{
    public List<Transform> points;
}
