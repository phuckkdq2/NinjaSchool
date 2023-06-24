using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Darwin
{
    [SerializeField] private Animator animator;             // biến hứng animation tấn công
    protected Animator Animator { get => animator;}
    [SerializeField] protected PlayerCtrl playerCtrl;       // biến hứng componment playerCtrl để lấy mấy thằng playerCtrl load được 
    protected float distancee = 1f;                         // khoảng cách của tia raycast bắn (khoảng cách tấn công)
    public LayerMask layerMask;                             // layer check va chạm
    RaycastHit2D hit ;                                      // biến hứng raycast
    public RaycastHit2D Hit { get => hit; set => hit = value; } 


    void Update()
    {
              
        if(InputManager.Instance.IsAttack)
        {
            animator.SetBool("isAttack", true); 
            this.Attacking();
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadPlayerCtrl();
        // this.LoadEnemyDespawn();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if(this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = FindObjectOfType<Animator>(); 
    }

    protected virtual void Attacking()
    {
       hit = Physics2D.Raycast (transform.position, playerCtrl.Movement.MoveDir*distancee, distancee, layerMask);   // tạo tia raycast
        if (hit.collider != null) 
        {
            Debug.Log(hit.collider.name);                                                                           // debug ra tên object mà nó bắn trúng
            EnemyDespawn enemyDespawn = hit.collider.GetComponent<EnemyDespawn>();                                  // lấy thằng component EnemyDespawn trong thằng object bị bắn trúng
            if(enemyDespawn != null)                                                                                // kiểm tra nếu có EnemyDespawn
            {
                Debug.DrawRay (transform.position, playerCtrl.Movement.MoveDir* hit.distance , Color.red);          // debug tia ray cast màu đỏ
                enemyDespawn.DespawnEnemy();                                                                        // gọi hàm Despawn object
            }
                
        }
        else {   
            Debug.DrawRay (transform.position, playerCtrl.Movement.MoveDir* distancee, Color.green);                // debug tia raycast màu xanh
        }
    }
}
