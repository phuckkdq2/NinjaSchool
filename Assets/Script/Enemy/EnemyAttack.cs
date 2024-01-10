using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : DamageSender
{
    [SerializeField] public bool canAttack;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float hitDelay = 2f;
    [SerializeField] protected float hitTimer = 0f;
    [SerializeField] private Transform targetAttack;

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
    void Start()
    {
        damage = enemyCtrl.EnemySO.dame;
        canAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        targetAttack = other.transform;
        canAttack = true;
        enemyCtrl.enemyState = StateAnimation.Attack;
    }

    private void FixedUpdate()
    {
        Attack();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetAttack = null;
        canAttack = false;
        if (!enemyCtrl.DamageReceiver.isDead) StartCoroutine(enemyCtrl.enemyMoveMent.MoveEnemy());
    }

    protected virtual void Attack()
    {
        if (!canAttack) return;
        else
        {
            this.hitTimer += Time.fixedDeltaTime;               // tăng dần thời gian đánh 
            if (this.hitTimer < this.hitDelay)
            {
                enemyCtrl.enemyState = StateAnimation.Run;
                return;                                         // nếu thời gian đánh < thời gian delay => không chạy             
            }
            this.hitTimer = 0;                                  // ngược lại set shootimer = 0 và chạy lệnh dưới (cho phép đánh)
            enemyCtrl.enemyState = StateAnimation.Attack;
            Send(targetAttack);
        }
    }


    public override void Send(Transform obj)
    {
        base.Send(obj);
        if (obj.position.x < transform.parent.position.x)
        {
            enemyCtrl.enemyMoveMent.dirMove.x = -1;
        }
        else
        {
            enemyCtrl.enemyMoveMent.dirMove.x = 1;
        }
        transform.parent.localScale = new Vector3(enemyCtrl.enemyMoveMent.dirMove.x, 1, 1);
        enemyCtrl.enemyMoveMent.hpBar.localScale = new Vector3(enemyCtrl.enemyMoveMent.dirMove.x, 1, 1);
    }

}
