using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : Darwin
{
    private void FixedUpdate() {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if(!CanDespawn()) return;
        DespawnObject();
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    
    protected abstract bool CanDespawn();
}
