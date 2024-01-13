using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerCtrl : Darwin           // load các componet cho dễ quản lí
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; }
    [SerializeField] protected Rigidbody2D mvrigidbody2D;
    public Rigidbody2D Mvrigidbody2D { get => mvrigidbody2D; }
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }
    [SerializeField] protected Movement movement;
    public Movement Movement { get => movement; }
    [SerializeField] protected PlayerDamageSender playerDamageSender;
    public PlayerDamageSender PlayerDamageSender { get => playerDamageSender; }
    [SerializeField] protected PlayerDamageReciever playerDamageReciever;
    public PlayerDamageReciever PlayerDamageReciever { get => playerDamageReciever; }
    [SerializeField] public Intersection point;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxColider();
        this.LoadBoxRigidbody();
        this.LoadAnimator();
        this.LoadMovement();
        this.LoadDamageSender();
        this.LoadDamageReciever();
        DontDestroyOnLoad(gameObject);
    }
    protected virtual void LoadBoxColider()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponentInChildren<BoxCollider2D>();
    }

    protected virtual void LoadBoxRigidbody()
    {
        if (this.mvrigidbody2D != null) return;
        this.mvrigidbody2D = transform.GetComponentInChildren<Rigidbody2D>();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<Movement>();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.playerDamageSender != null) return;
        this.playerDamageSender = transform.GetComponentInChildren<PlayerDamageSender>();
    }

    protected virtual void LoadDamageReciever()
    {
        if (this.playerDamageReciever != null) return;
        this.playerDamageReciever = transform.GetComponentInChildren<PlayerDamageReciever>();
    }

}
