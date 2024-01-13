using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.SearchService;
using UnityEngine;
using System.Linq;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] List<SpawnPoints> spawnPoints;
    [SerializeField] List<Transform> Enemies;
    [SerializeField] public CinemachineVirtualCamera vcCamera;
    [SerializeField] public PlayerCtrl player; 
    [SerializeField] public List<PointTrans> checkPoints;

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
        GetPosPlayer();
        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void GetPosPlayer()
    {
        for(int i = 0; i< checkPoints.Count; i++)
        {
            if(checkPoints[i].intersection == player.point)
            {
                player.transform.position = checkPoints[i].PlayerPoint.position;
                Debug.LogError(checkPoints[i].PlayerPoint.position);
            }
        }
    }

}

[Serializable]
public class SpawnPoints
{
    public List<Transform> points;
}
