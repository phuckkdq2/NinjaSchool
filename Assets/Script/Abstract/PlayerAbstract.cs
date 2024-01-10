using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : Darwin
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl { get => playerCtrl; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
}
