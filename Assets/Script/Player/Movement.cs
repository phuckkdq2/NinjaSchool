using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Darwin
{
    [SerializeField] protected float moveSpeed = 10f;           // biến quản lí tốc độ chạy
    [SerializeField] protected float forceJump = 500f;          // biến quản lí lực nhảy
    [SerializeField] private bool is_ground;                    // quản lí trạng thái đang ở trên mặt đất không?      
    [SerializeField] protected PlayerCtrl playerCtrl;           // chứa coponent quản lí các component khác
    private Vector3 moveDir;
    public Vector3 MoveDir { get => moveDir; set => moveDir = value; }
    [SerializeField] protected Animator animator;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();              
    }

    protected virtual void LoadPlayerCtrl()
    {
        if(this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    void Update()
    {
        this.Moving();          // gọi hàm di chuyển
        Jumping();
    }

    // hàm di chuyển
    protected virtual void Moving()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if(is_ground)playerCtrl.Mvrigidbody2D.velocity = new Vector2(moveSpeed * xDir , playerCtrl.Mvrigidbody2D.velocity.y);
        else playerCtrl.Mvrigidbody2D.velocity = new Vector2(moveSpeed/2 * xDir , playerCtrl.Mvrigidbody2D.velocity.y);
        if(playerCtrl.Mvrigidbody2D.velocity.x > 0)
        {
            transform.parent.localScale = new Vector3(1,1,1);
            moveDir = Vector3.right;
        } 
        if(playerCtrl.Mvrigidbody2D.velocity.x < 0)
        {
            transform.parent.localScale = new Vector3(-1,1,1);
            moveDir = Vector3.left;
        } 
        if(is_ground)   animator.SetFloat("Running", Mathf.Abs(xDir));
    }

    protected virtual void Jumping()
    {
        if (InputManager.Instance.IsJump && this.is_ground)
        {
            playerCtrl.Mvrigidbody2D.AddForce(Vector2.up* forceJump);
            animator.SetBool("Jump", true);
            this.is_ground = false; 
        }
        animator.SetFloat("Yveloc", playerCtrl.Mvrigidbody2D.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            this.is_ground = true;
            animator.SetBool("Jump", !is_ground);
        }  
    }
}
