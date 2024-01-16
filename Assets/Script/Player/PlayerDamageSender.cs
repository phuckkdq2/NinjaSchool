using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField] protected PlayerCtrl playerCtrl;                       // chứa coponent quản lí các component khác

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();

    }

    private void Start()
    {
        this.damage = UserData.instance.damage;
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
    }

}
