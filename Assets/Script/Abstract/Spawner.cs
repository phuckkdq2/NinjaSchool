using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : Darwin
{  

    [SerializeField] protected List<Transform> poolObjs;            // list chứa các thằng bị despawn 
    [SerializeField] protected List<Transform> prefabs;             // list chứa các thằng obj trong prefab
    [SerializeField] protected Transform Holder;     

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()                // them các obj trong prefabs vào list prefabs để quản lí
    {
        if(this.prefabs.Count > 0 ) return;             
        Transform prefabsObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabsObj)
        {
            prefabs.Add(prefab);
        }
        this.HidePrefabs();                             // ẩn các thằng đã Add
    }

    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)       // duyệt qua cac enemy trong thằng list prefabs
        {
            prefab.gameObject.SetActive(false);         // ẩn nó đi 
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawPos, Quaternion rotation)   // Spawn với tham số truyền vào là string
    {
        Transform prefab = this.GetPrefabByName(prefabName);            // lấy tên prefab 
        if(prefab == null)                                              // nếu không có prefab thì không trả về gì 
        {                                             
            Debug.LogWarning("prefab not found !" + prefabName);
            return null;
        }
        return Spawn(prefab, spawPos, rotation);                        // spawn thằng prefab được xử lí ở hàm Spawn() bên dưới
    }

    public virtual Transform Spawn( Transform prefab, Vector3 spawnpos, Quaternion rotation)            // truyền vào 1 object , vị trí , góc quay
    {
        Transform newPrefabs = GetObjectformPool(prefab);                                               // spawn object 
        newPrefabs.SetPositionAndRotation(spawnpos, rotation);                                          // set góc quay và vị trí bằng góc quay và vị trí đc truyền vào
        newPrefabs.name = prefab.name;                                                                  // set tên object spawn bằng tên object truyền vào cho dễ xử lí
        newPrefabs.parent = this.Holder;
        return newPrefabs;
    }

    protected virtual Transform GetObjectformPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)        // lặp qua list poolObjs 
        {
            if(poolObj.name == prefab.name){                // kiểm tra xem trong poolObjs có obj nào giống tên (có bản sao) hay chưa
                this.poolObjs.Remove(poolObj);              // bỏ objs đó ra khỏi list poolObjs
                return poolObj;                             // trả về obj đó để chuẩn bị tái sử dụng(spawn)  
            }
        }
        // nếu duyệt qua hết trong list poolObjs mà không còn nữa
        Transform newPerfab = Instantiate(prefab);          // tạo mới obj
        newPerfab.name = prefab.name;                       // set tên của thằng prefab vừa tạo bằng tên của thằng prefab truyền vào (có sẵn) để đồng bộ
        return newPerfab;                                   // trả về thằng vừa được tạo để mang đi spawn
    }

    protected virtual Transform GetPrefabByName(string prefabName){
        foreach(Transform prefab in this.prefabs){          // duyejt qua list prefabs
            if(prefabName == prefab.name) return prefab;    // nếu tên prefabs truyền vào trùng tên frebas trong list thì trả về nó
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);                     // thêm vào pool
        obj.gameObject.SetActive(false);            // off nó đi
    }
}
