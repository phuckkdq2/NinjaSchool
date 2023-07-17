using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected int hp ;
    [SerializeField] protected int hpMax = 4;
    [SerializeField] public bool isDead ;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if(this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
    }
      
    public virtual void OnDead()
    {
        
    }

}
