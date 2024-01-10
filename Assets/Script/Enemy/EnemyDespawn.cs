using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Darwin
{
    public void DespawnEnemy()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

}
