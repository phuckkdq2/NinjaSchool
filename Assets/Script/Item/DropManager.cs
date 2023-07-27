using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : Darwin
{
    private static DropManager instance;
    public static DropManager Instance { get => instance;}
    
    protected override void Awake()
    {
        base.Awake();
        DropManager.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }

}
