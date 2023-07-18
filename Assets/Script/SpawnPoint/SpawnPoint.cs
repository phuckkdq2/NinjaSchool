using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Darwin
{
    [SerializeField] protected List<Transform> points ;
    [SerializeField] protected List<bool> isSpawnedStatus ; 

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

    public virtual List<Transform> GetSpawnPoint()                  // lấy ra các point trong list points
    {
        List<Transform> spawnPoint = new List<Transform>();

        foreach (Transform point in this.points)
        {
            spawnPoint.Add(point);
        }
        return spawnPoint;
    }

}
