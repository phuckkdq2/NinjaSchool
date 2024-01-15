using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] public Transform hpBar;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected override void OnDead()
    {
        this.OnDeadFx();
        enemyCtrl.EnemyDespawn.DespawnEnemy();              // Despawn enemy 
        this.DropOnDead();
    }

    protected virtual void DropOnDead()
    {
        ItemDropSpawner.Instance.Drop(enemyCtrl.EnemySO.dropList, transform.position, transform.rotation);
    }

    protected virtual void OnDeadFx()
    {
        string fxName = this.GetFxName();
        Transform fxOnDead = FxSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetFxName()
    {
        return FxSpawner.smokeOne;
    }

    public override void ReBorn()
    {
        hpBar.localScale = new Vector3(1, 1, 1);
        this.hpMax = this.enemyCtrl.EnemySO.hpMax;
        base.ReBorn();
    }

    public override void Deduct(float dame)
    {
        base.Deduct(dame);
        if (hp > UserData.instance.damage / 10)
        {
            UserData.instance.AddExp(UserData.instance.damage / 10);
        }
        else UserData.instance.AddExp(hp);
        enemyCtrl.enemyState = StateAnimation.Hurt;
        hpBar.localScale = new Vector3(hp / hpMax, 1f, 1f);
    }
}
