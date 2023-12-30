using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMoveMent : Darwin
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float moveSpeed;
    Vector3 dirMove;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl { get => enemyCtrl; }

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
        dirMove = Vector3.right;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(MoveEnemy());
    }

    void MoveEnemy2()
    {
        transform.parent.DOMoveX(transform.position.x + 2f, 2f)
            .SetEase(Ease.Linear)
            .OnStart(() =>
            {
                transform.parent.localScale = new Vector3(1, 1, 1);
            })
            .OnComplete(() =>
            {
                transform.parent.localScale = new Vector3(-1, 1, 1);
                transform.parent.DOMoveX(transform.position.x + -2f, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    MoveEnemy2();
                });
            });
    }

    IEnumerator MoveEnemy()
    {
        while (!enemyCtrl.DamageReceiver.isDead)
        {
            int rand = Random.Range(1, 30);
            if (rand == 1) yield return new WaitForSeconds(2f);
            else yield return new WaitForSeconds(0.2f);
            transform.parent.position += dirMove * moveSpeed * Time.deltaTime;
            moveSpeed = 10f;
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
}
