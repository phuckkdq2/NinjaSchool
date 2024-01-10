using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerAbstract
{
    [SerializeField] private Animator animator;                                 // biến hứng animation tấn công
    [SerializeField] protected float distancee = 1f;                            // khoảng cách của tia raycast bắn (khoảng cách tấn công)
    [SerializeField] protected LayerMask layerMask;                             // layer check va chạm
    protected RaycastHit2D hit;                                                // biến hứng raycast
    public RaycastHit2D Hit { get => hit; set => hit = value; }


    void Update()
    {
        if (InputManager.Instance.IsAttack)
        {
            animator.SetInteger("State", (int)StateAnimation.Attack);
            this.Attacking();
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = FindObjectOfType<Animator>();
    }

    protected virtual void Attacking()
    {
        hit = Physics2D.Raycast(transform.position, playerCtrl.Movement.MoveDir * distancee, distancee, layerMask);   // tạo tia raycast
        if (hit.collider != null)
        {
            // Debug.Log(hit.collider.name);                                                                         // debug ra tên object mà nó bắn trúng       
            playerCtrl.PlayerDamageSender.Send(hit.collider.transform);                                 // gọi hàm send dame để trừ máu 
            this.CreateFxBlood(hit.collider);
        }
        else
        {
            Debug.DrawRay(transform.position, playerCtrl.Movement.MoveDir * distancee, Color.green);                 // debug tia raycast màu xanh
        }
    }

    protected virtual void CreateFxBlood(Collider2D other)
    {
        string FxName = this.GetFxBlood();
        Transform fxBlood = FxSpawner.Instance.Spawn(FxName, other.transform.position, other.transform.rotation);
        fxBlood.gameObject.SetActive(true);
    }

    protected virtual string GetFxBlood()
    {
        return FxSpawner.blood;
    }
}
