using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : Spawner
{
    private static FxSpawner instance;
    public static FxSpawner Instance { get => instance; }

    public static string smokeOne = "Smoke_1";
    public static string blood = "Blood";

    protected override void Awake()
    {
        base.Awake();
        FxSpawner.instance = this;
    }

    private void Start()
    {
        if (this.poolObjs == null)
        {
            for (int i = 0; i < 100; i++)
            {
                Transform smokeClone = Spawn(smokeOne, Vector3.zero, Quaternion.identity);
            }
            for (int i = 0; i < 100; i++)
            {
                Transform bloodClone = Spawn(blood, Vector3.zero, Quaternion.identity);
            }
        }
    }

}
