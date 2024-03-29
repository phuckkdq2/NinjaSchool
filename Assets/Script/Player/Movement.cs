using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : Darwin
{
    [SerializeField] protected float moveSpeed = 7f;           // biến quản lí tốc độ chạy
    [SerializeField] protected float forceJump = 11.2f;          // biến quản lí lực nhảy   
    [SerializeField] protected PlayerCtrl playerCtrl;           // chứa coponent quản lí các component khác
    private Vector3 moveDir;
    public Vector3 MoveDir { get => moveDir; set => moveDir = value; }
    [SerializeField] protected Animator animator;
    [SerializeField] protected StateAnimation playerState;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D coll;
    [SerializeField] LayerMask jumableGround;
    [SerializeField] LayerMask jumableUnderWater;
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

    private void FixedUpdate()
    {
        Jumping();
        this.Moving();          // gọi hàm di chuyển
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
                transform.parent.position = transform.parent.position;
            }
            else
            {
                transform.parent.position += moveDir * moveSpeed * Time.fixedDeltaTime;
            }

        }
        else if (InputManager.Instance.MoveLeft)
        {
            isRunning = true;
            transform.parent.localScale = new Vector3(-1, 1, 1);
            moveDir = Vector3.left;
            if (IsCompartagWall())
            {
                transform.parent.position = transform.parent.position;
            }
            else
            {
                transform.parent.position += moveDir * moveSpeed * Time.fixedDeltaTime;
            }
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
        if (IsGrounded())
        {
            if (isRunning)
            {
                playerState = StateAnimation.Run;
            }
            else if (playerCtrl.PlayerDamageReciever.isDead)
            {
                playerState = StateAnimation.Death;
            }
            else
                playerState = StateAnimation.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            playerState = StateAnimation.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            playerState = StateAnimation.Falling;
        }
        animator.SetInteger("State", (int)playerState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableGround);
    }

    private bool IsCompartagWall()
    {
        return Physics2D.BoxCast(coll.bounds.center + transform.right * .1f * transform.parent.localScale.x, new Vector3(coll.bounds.size.x, coll.bounds.size.y, coll.bounds.size.z), 0f, Vector2.right, 0f, collisonGround);
    }
    private bool IsCompartagUnderWater()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumableUnderWater);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            playerCtrl.point = other.transform.GetComponent<PointTrans>().intersection;
            playerCtrl.LoadNextScene(other.transform.GetComponent<PointTrans>().name);
        }
        if (other.CompareTag("NPC"))
        {
            playerCtrl.interactNPC = true;
            playerCtrl.npc = other.transform.GetComponent<NPCManager>();
            playerCtrl.arrow = playerCtrl.npc.transform.GetChild(0);
            playerCtrl.arrow.gameObject.SetActive(true);
            GameUICtrl.Instance.npc = playerCtrl.npc;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Item"))
        {
            var item = other.transform.parent.GetComponent<ItemCtrl>();
            switch (item.item.itemCode)
            {
                case ItemCode.Hp:
                    UserData.instance.AddHp(1);
                    break;
                case ItemCode.Coin:
                    UserData.instance.AddCoin(50);
                    break;
            }
            ItemDropSpawner.Instance.Despawn(other.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            playerCtrl.interactNPC = false;
            playerCtrl.npc = null;
            playerCtrl.arrow.gameObject.SetActive(false);
            GameUICtrl.Instance.ClearSelectionView();
        }
    }

}

public enum StateAnimation
{
    Idle,
    Run,
    Attack,
    Jump,
    Falling,
    Hurt,
    Death
}
