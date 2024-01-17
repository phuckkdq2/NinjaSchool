using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] public bool isDead;
    [SerializeField] public Transform shuriken;
    [SerializeField] public Transform loadMap;
    [SerializeField] public AnimationCurve moveCurve;
    [SerializeField] public bool interactNPC = false;
    [SerializeField] public NPCManager npc;
    [SerializeField] public Transform arrow;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxColider();
        this.LoadBoxRigidbody();
        this.LoadAnimator();
        this.LoadMovement();
        this.LoadDamageSender();
        this.LoadDamageReciever();
        GameUICtrl.Instance.UpdateLevel();
        GameUICtrl.Instance.UpdateExpBar(UserData.instance.expCount / UserData.instance.expPool);
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

    public IEnumerator LoadScene(string sceneName)
    {
        //loadMap.gameObject.SetActive(true);
        //float valueRate;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            //valueRate = operation.progress * 0.3f;
            yield return null;
        }
        // shuriken.DORotate(new Vector3(0, 0, -360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        // DOTween.To(() => 0, x => valueRate = x, 1f, 3f).SetEase(moveCurve)
        // .OnUpdate(() =>
        // {

        // })
        // .OnComplete(() =>
        // {
        //     loadMap.gameObject.SetActive(false);
        //     SceneManager.UnloadScene(sceneName);
        // });
    }

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

}
