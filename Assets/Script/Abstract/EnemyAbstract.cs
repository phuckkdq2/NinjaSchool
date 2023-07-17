using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : Darwin
{
    
    [Header ("Enemy Abstract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl { get => enemyCtrl;}

    protected override void LoadComponent()
    {
        base.LoadComponent();      
        this.LoadEnemyCtrl();          // load component <BulletCtrl>
    }

    protected virtual void LoadEnemyCtrl()                            
    {
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();      // load component <BulletCtrl> từ thằng cha (obj Bullet_1)
    }
}
