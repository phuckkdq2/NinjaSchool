using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : Darwin
{
    [SerializeField] protected float damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if(damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)             // hàm truyền damage với tham số là DamageReceiver
    {
        damageReceiver.Deduct(this.damage);                             // gọi hàm trừ máu trong DamageReceiver
    }

}
