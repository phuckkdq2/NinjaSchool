using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected bool moveLeft;
    public bool MoveLeft { get => moveLeft; }

    [SerializeField] protected bool moveRight;
    public bool MoveRight { get => moveRight; }

    [SerializeField] protected bool isJump;
    public bool IsJump { get => isJump; }

    [SerializeField] protected bool isAttack;
    public bool IsAttack { get => isAttack; }

    private void Awake()
    {
        InputManager.instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    // void Update()
    // {
    //     this.getInputkey();
    // }

    // public void getInputkey()
    // {
    //     this.moveLeft = Input.GetKey(KeyCode.LeftArrow);
    //     this.moveRight = Input.GetKey(KeyCode.RightArrow);
    //     this.isJump = Input.GetKey(KeyCode.UpArrow);
    //     this.isAttack = Input.GetKeyDown(KeyCode.Space);
    // }

    public void CanMoveRight(bool isMoveRight)
    {
        moveRight = isMoveRight;
    }

    public void CanMoveLeft(bool isMoveLeft)
    {
        moveLeft = isMoveLeft;
    }

    public void CanJump(bool isJump)
    {
        this.isJump = isJump;
    }

}


