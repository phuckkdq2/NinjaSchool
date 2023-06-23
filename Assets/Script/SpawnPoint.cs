using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Darwin
{
    [SerializeField] protected List<Transform> points ;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawn();
    }

    protected virtual void LoadPointSpawn()
    {
        if(this.points.Count > 0) return;
        foreach(Transform point in transform)       // duyệt qua các thằng point trong obj SpawnPointCtrl
        {
            this.points.Add(point);
        }
    }

    public List<Transform> GetSpawnPoint()
    {
        List<Transform> spawnPoint = new List<Transform>();

        foreach (Transform point in this.points)
        {
            spawnPoint.Add(point);
        }
        return spawnPoint;
    }

    public List<Vector3> GetSpawnPositions()
    {
        List<Vector3> spawnPositions = new List<Vector3>();

        foreach (Transform point in this.points)
        {
            spawnPositions.Add(point.position);
        }
        return spawnPositions;
    }

}
