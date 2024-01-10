using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : Darwin
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }
    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get => enemySO; }
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver { get => damageReceiver; }
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }
    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack { get => enemyAttack; }
    public EnemyMoveMent enemyMoveMent;
    [SerializeField] public StateAnimation enemyState;
    [SerializeField] public int damage;
    [SerializeField] public int hp;

    private void Start()
    {
        this.damage = enemySO.dame;
        this.hp = enemySO.hpMax;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
        this.LoadEnemySO();
        this.LoadEnemyDameReceivier();
        this.LoadAnimator();
        this.LoadEnemyAttack();
        this.LoadEnemyMoveMent();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
    }

    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
    }
    protected virtual void LoadEnemyDameReceivier()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = Transform.FindObjectOfType<DamageReceiver>();
        Debug.Log(damageReceiver);
    }

    protected virtual void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = Transform.FindObjectOfType<EnemyAttack>();
    }

    protected virtual void LoadEnemyMoveMent()
    {
        if (this.enemyMoveMent != null) return;
        this.enemyMoveMent = Transform.FindObjectOfType<EnemyMoveMent>();
    }

    private void Update()
    {
        animator.SetInteger("state", (int)enemyState);
    }

}
