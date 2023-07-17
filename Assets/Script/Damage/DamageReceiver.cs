using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected float hp ;
    [SerializeField] protected float hpMax = 4;
    [SerializeField] public bool isDead ;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if(this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector2(1f, 0.8f);
        this.boxCollider.offset = new Vector2(0f, -0.05f);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReBorn();
    }

    public virtual void ReBorn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Deduct(float dame)
    {
        if(this.isDead) return;
        this.hp -= dame;
        if(this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }   

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if(!isDead) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
