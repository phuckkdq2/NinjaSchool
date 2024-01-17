using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] List<SpawnPoints> spawnPoints;
    [SerializeField] List<Transform> Enemies;
    [SerializeField] public CinemachineVirtualCamera vcCamera;
    [SerializeField] public PlayerCtrl player;
    [SerializeField] public List<PointTrans> checkPoints;

    private void Start()
    {
        InputManager.Instance.StopOnLoadMAp();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            EnemySpawner.Instance.SpawnEnemy(spawnPoints[i].points, Enemies[i]);
        }
    }

    private void OnEnable()
    {

    }

    private void Awake()
    {
        player = Transform.FindObjectOfType<PlayerCtrl>();
        vcCamera.Follow = player.transform;
        if (player.PlayerDamageReciever.isDead)
        {
            player.transform.position = Vector3.zero;
        }
        else player.transform.position = GetPosPlayer();
        player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private Vector3 GetPosPlayer()
    {
        for (int i = 0; i < checkPoints.Count; i++)
        {
            if (checkPoints[i].intersection == player.point)
            {
                return checkPoints[i].PlayerPoint.position;
            }
        }
        return Vector3.zero;
    }

}

[Serializable]
public class SpawnPoints
{
    public List<Transform> points;
}
