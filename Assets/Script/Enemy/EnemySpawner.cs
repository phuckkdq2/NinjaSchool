using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnpos, Quaternion rotation)
    {
        Transform newPrefabs = GetObjectformPool(prefab);                                               // spawn object 
        newPrefabs.SetPositionAndRotation(spawnpos, rotation);                                          // set góc quay và vị trí bằng góc quay và vị trí đc truyền vào
        newPrefabs.name = prefab.name;                                                                  // set tên object spawn bằng tên object truyền vào cho dễ xử lí
        return newPrefabs;
    }

    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        StartCoroutine(ReSpawn(obj));               // Gọi hàm Respawn sau khoảng thời gian
    }

    protected virtual IEnumerator ReSpawn(Transform obj)
    {
        yield return new WaitForSeconds(5f);                    // đợi sau 5s
        Transform point = getSpawnpoint(obj);                   // lấy ra điểm để respawn 
        this.Spawn(obj, point.position, point.rotation);        // spawn lại nó 
        obj.gameObject.SetActive(true);                         // bật nó lên
    }

    protected virtual Transform getSpawnpoint(Transform obj)   // hàm trả về Spawn point 
    {
        return obj.transform.parent;
    }

    public virtual void SpawnAtPoint(Transform point, Transform prefab)         // spawn enemy tại điểm truyền vào
    {
        Transform obj = Spawn(prefab, point.position, point.rotation);
        obj.parent = point;
    }

    public void SpawnEnemy(List<Transform> points, Transform prefab)
    {
        foreach (Transform point in points)                          // duyệt qua list điểm 
        {
            EnemySpawner.Instance.SpawnAtPoint(point, prefab);       // spawn enemy tại điểm đó với tham sô truyền vào là tên enemy 
        }
    }

}
