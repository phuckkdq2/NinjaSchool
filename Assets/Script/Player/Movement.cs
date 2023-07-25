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
        if(InputManager.Instance.IsAttack) return;
        this.Moving();          // gọi hàm di chuyển
        this.AnimationRun();    // gọi hàm animation chạy
    }

    // hàm di chuyển
    protected virtual void Moving()
    {
        if(InputManager.Instance.MoveLeft ){
            if(is_ground){
                moveDir = Vector3.left;
                transform.parent.position += moveDir * moveSpeed * Time.deltaTime ;
            }
            else{
                moveDir = Vector3.left;
                transform.parent.position += moveDir * 5 * Time.deltaTime ;
            }    
            transform.parent.localScale = new Vector3(-1, transform.parent.localScale.y, transform.parent.localScale.z);
        }
        else if (InputManager.Instance.MoveRight){
            if(is_ground){
                moveDir = Vector3.right;
                transform.parent.position += moveDir * moveSpeed * Time.deltaTime ;
            }
            else{
                moveDir = Vector3.right;
                transform.parent.position += moveDir * 5 * Time.deltaTime ;
            }      
            transform.parent.localScale = new Vector3(1, transform.parent.localScale.y, transform.parent.localScale.z);
        }
        else if (InputManager.Instance.IsJump && this.is_ground){
            playerCtrl.Mvrigidbody2D.AddForce(Vector2.up* forceJump);
            // rb.velocity = Vector2.up * forceJump;
            this.is_ground = false; 
        }
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Ground")){
            this.is_ground = true;
        }  
    }

    protected virtual void AnimationRun()
    {
        if((InputManager.Instance.MoveLeft && is_ground) || (InputManager.Instance.MoveRight && is_ground))
        {
            playerCtrl.Animator.SetBool("isRunning", true);
        }
        else
        {
            playerCtrl.Animator.SetBool("isRunning", false);
        }
    }
}
