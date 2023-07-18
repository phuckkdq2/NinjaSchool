using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerAbstract
{
    [SerializeField] private Animator animator;                                 // biến hứng animation tấn công
    [SerializeField] protected float distancee = 1f;                            // khoảng cách của tia raycast bắn (khoảng cách tấn công)
    [SerializeField] protected LayerMask layerMask;                             // layer check va chạm
    protected RaycastHit2D hit ;                                                // biến hứng raycast
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
            // Debug.Log(hit.collider.name);                 // debug ra tên object mà nó bắn trúng       
            playerCtrl.DamageSender.Send(hit.collider.transform);           // gọi hàm send dame để trừ máu 
        }
        else {   
            Debug.DrawRay (transform.position, playerCtrl.Movement.MoveDir* distancee, Color.green);                // debug tia raycast màu xanh
        }
    }
}
