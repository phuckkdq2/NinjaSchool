using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        FxSpawner.Instance.Despawn(transform.parent);
    }
}
