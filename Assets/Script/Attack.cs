using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Darwin
{
    [SerializeField] private Animator animator;
    protected Animator Animator { get => animator;}
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected float distancee = 1f;
    public LayerMask layerMask;
    RaycastHit2D hit ;
    public RaycastHit2D Hit { get => hit; set => hit = value; } 

    void Update()
    {
        
        
        if(InputManager.Instance.IsAttack)
        {
            animator.SetBool("isAttack", true); 
            
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
        this.Attacking();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadPlayerCtrl();
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
       hit = Physics2D.Raycast (transform.position, playerCtrl.Movement.MoveDir*distancee, distancee, layerMask);
        if (hit.collider != null) 
        {
            Debug.DrawRay (transform.position, playerCtrl.Movement.MoveDir* hit.distance , Color.red);
            if(hit.collider.CompareTag("Enemy")){
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.DEstroyEnemy();
                }
            }      
        }
        else {
            
            Debug.DrawRay (transform.position, playerCtrl.Movement.MoveDir* distancee, Color.green);
        }
    }
}
