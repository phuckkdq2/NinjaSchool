using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Darwin
{  
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Spawn( Transform prefab, Vector3 spawnpos, Quaternion rotation)
    {
        Transform newPrefabs = Instantiate(prefab);
        newPrefabs.SetPositionAndRotation(spawnpos, rotation);
        newPrefabs.transform.gameObject.SetActive(true);
        
    }
}
