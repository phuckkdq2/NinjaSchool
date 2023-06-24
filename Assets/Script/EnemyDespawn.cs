using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Darwin
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DespawnEnemy()
    {
        EnemySpawn.Instance.Despawn(transform.parent);
    }
}
