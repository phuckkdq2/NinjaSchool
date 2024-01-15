using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : Darwin
{
    [SerializeField] protected float damage;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        if(damageReceiver.isDead) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)             // hàm truyền damage với tham số là DamageReceiver
    {
        damageReceiver.Deduct(damage);                                  // gọi hàm trừ máu trong DamageReceiver
    }

}
