using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : Darwin
{  

    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if(this.holder != null) return;             // nếu Holder được gắn vào thì thôi
        this.holder = transform.Find("Holder");     // nếu chưa thì tìm obj có tên holder rồi gán nó vào 
    }

    void Update()
    {
        
    }
    public virtual Transform Spawn( Transform prefab, Vector3 spawnpos, Quaternion rotation)            // truyền vào 1 object , vị trí , góc quay
    {
        Transform newPrefabs = Instantiate(prefab);                                                     // spawn object 
        newPrefabs.SetPositionAndRotation(spawnpos, rotation);                                          // set góc quay và vị trí bằng góc quay và vị trí đc truyền vào
        newPrefabs.name = prefab.name;                                                                  // set tên object spawn bằng tên object truyền vào cho dễ xử lí
        newPrefabs.parent = this.holder;                                                                // thêm nó vào object holder
        return newPrefabs;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);                     // thêm vào pool
        obj.gameObject.SetActive(false);            // off nó đi
    }

}
