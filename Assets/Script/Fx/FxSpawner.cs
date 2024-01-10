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

}
