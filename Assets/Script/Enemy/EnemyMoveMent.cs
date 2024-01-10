using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMoveMent : Darwin
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float moveSpeed;
    [SerializeField] public Vector3 dirMove;
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

    void Start()
    {
        spawnPoint = enemyCtrl.transform.parent;
        SetMoveDir();
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        enemyCtrl.enemyState = StateAnimation.Run;
        StartCoroutine(MoveEnemy());
        moveSpeed = 4f;
    }

    void MoveEnemy2()
    {
        if (enemyCtrl.DamageReceiver.isDead || enemyCtrl.EnemyAttack.canAttack)
            return;
        else
        {
            transform.parent.position += dirMove * moveSpeed * Time.fixedDeltaTime;
            if (transform.parent.position.x > spawnPoint.position.x + 1)
            {
                transform.parent.localScale = transform.parent.localScale = new Vector3(-1, 1, 1);
                dirMove = Vector3.left;
            }
            else if (transform.parent.position.x < spawnPoint.position.x + -1)
            {
                transform.parent.localScale = transform.parent.localScale = new Vector3(1, 1, 1);
                dirMove = Vector3.right;
            }
        }
    }

    public IEnumerator MoveEnemy()
    {
        while (!enemyCtrl.DamageReceiver.isDead && !enemyCtrl.EnemyAttack.canAttack)
        {
            int rand = Random.Range(1, 40);
            if (rand == 1) yield return new WaitForSeconds(2f);
            else yield return new WaitForSeconds(0.15f);
            transform.parent.localScale = new Vector3(dirMove.x, 1, 1);
            hpBar.localScale = new Vector3(dirMove.x, 1, 1);
            transform.parent.position += dirMove * moveSpeed * Time.fixedDeltaTime;
            if (transform.parent.position.x > spawnPoint.position.x + 1)
            {
                dirMove.x = -1f;
            }
            else if (transform.parent.position.x < spawnPoint.position.x + -1)
            {
                dirMove.x = 1f;
            }
        }
    }
    public void SetMoveDir()
    {
        dirMove = Vector3.right;
        int rand = Random.Range(1, 3);
        if (rand == 1) dirMove.x = 1;
        else dirMove.x = -1;
    }
}
