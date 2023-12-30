using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance;}

    public static string worm = "Hedgehog";
    public static string wolf = "Rabbit";

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }

    public override void Despawn(Transform obj)
    {
        base.Despawn(obj);
        StartCoroutine(ReSpawn(obj));               // Gọi hàm Respawn sau khoảng thời gian
    }

    protected virtual IEnumerator ReSpawn( Transform obj)
    {
        yield return new WaitForSeconds(5f);                    // đợi sau 5s
        Transform point = getSpawnpoint(obj);                   // lấy ra điểm để respawn 
        this.Spawn(obj, point.position, point.rotation);        // spawn lại nó 
        obj.gameObject.SetActive(true);                         // bật nó lên
    }

    protected virtual Transform getSpawnpoint (Transform obj)   // hàm trả về Spawn point 
    {
        return obj.transform.parent;
    }

    public virtual void SpawnWormAtPoint(Transform point, string enemy)         // spawn enemy tại điểm truyền vào
    {
        Transform obj = Spawn(enemy, point.position, point.rotation);
        obj.gameObject.SetActive(true);
        obj.parent = point;
    }

}
