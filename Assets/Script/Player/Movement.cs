using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Darwin
{
    [SerializeField] protected float moveSpeed = 10f;           // biến quản lí tốc độ chạy
    [SerializeField] protected float forceJump = 10f;          // biến quản lí lực nhảy   
    [SerializeField] protected PlayerCtrl playerCtrl;           // chứa coponent quản lí các component khác
    private Vector3 moveDir;
    public Vector3 MoveDir { get => moveDir; set => moveDir = value; }
    [SerializeField] protected Animator animator;
    [SerializeField] protected StateMovement stateMovement;
    float xDir;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D coll;
    [SerializeField] LayerMask jumableGround;
    [SerializeField] LayerMask collisonGround;
    [SerializeField] private bool isRunning;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
        rb = playerCtrl.Mvrigidbody2D;
        coll = GetComponent<BoxCollider2D>();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    void Update()
    {
        this.Moving();          // gọi hàm di chuyển
        Jumping();
        UpdateAnimation();
    }

    // hàm di chuyển
    protected virtual void Moving()
    {
        if (InputManager.Instance.MoveRight)
        {
            isRunning = true;
            transform.parent.localScale = new Vector3(1, 1, 1);
            moveDir = Vector3.right;
            if (IsCompartagWall())
            {
                return;
            }
            if (IsGrounded())
            {
                transform.parent.position += moveDir * moveSpeed * Time.deltaTime;
            }
            else
                transform.parent.position += moveDir * 5 * Time.deltaTime;
        }
        else if (InputManager.Instance.MoveLeft)
        {
            isRunning = true;
            transform.parent.localScale = new Vector3(-1, 1, 1);
            moveDir = Vector3.left;
            if (IsCompartagWall())
            {
                return;
            }
            if (IsGrounded())
            {
                transform.parent.position += moveDir * moveSpeed * Time.deltaTime;
            }
            else
                transform.parent.position += moveDir * 5 * Time.deltaTime;
        }
        else
        {
            isRunning = false;
        }
    }

    protected virtual void Jumping()
    {
        if (InputManager.Instance.IsJump && IsGrounded() && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, forceJump);
        }
    }

    protected virtual void UpdateAnimation()
    {
        if (isRunning && IsGrounded())
        {
            stateMovement = StateMovement.Run;
        }
        else stateMovement = StateMovement.Idle;

        if (rb.velocity.y > .1f)
        {
            stateMovement = StateMovement.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            stateMovement = StateMovement.Falling;
        }
        animator.SetInteger("State", (int)stateMovement);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);
    }

    private bool IsCompartagWall()
    {
        return Physics2D.BoxCast(coll.bounds.center + transform.right * .1f * transform.parent.localScale.x, new Vector3(coll.bounds.size.x, coll.bounds.size.y, coll.bounds.size.z), 0f, Vector2.right, 0f, collisonGround);
    }

}

public enum StateMovement
{
    Idle,
    Run,
    Attack,
    Jump,
    Falling
}
