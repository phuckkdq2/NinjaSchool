using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciever : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;                       // chứa coponent quản lí các component khác

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected override void OnDead()
    {
        Debug.LogError("GameOver");
    }

    public override void ReBorn()
    {
        this.hpMax = UserData.instance.health;
        base.ReBorn();
    }

    public override void Deduct(float dame)
    {
        GameUICtrl.Instance.UpdateHealthBar(hp/hpMax);
        base.Deduct(dame);
    }
}
