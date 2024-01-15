using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReciever : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;                       // chứa coponent quản lí các component khác
    [SerializeField] public Transform alive;
    [SerializeField] public Transform die;
    [SerializeField] public Transform btnBackHome;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected override void OnDead()
    {
        Debug.LogError("GameOver");
        GameUICtrl.Instance.hpSlider.value = 0;
        alive.gameObject.SetActive(false);
        die.gameObject.SetActive(true);
        btnBackHome.gameObject.SetActive(true);
    }

    public void OnClickBackHomeOnDead()
    {
        playerCtrl.LoadNextScene("School");
        ReBorn();
        alive.gameObject.SetActive(true);
        die.gameObject.SetActive(false);
        btnBackHome.gameObject.SetActive(false);
    }

    public override void ReBorn()
    {
        this.hpMax = UserData.instance.health;
        GameUICtrl.Instance.hpSlider.value = 1;
        base.ReBorn();
    }

    public override void Deduct(float dame)
    {
        base.Deduct(dame);
        GameUICtrl.Instance.UpdateHealthBar(hp / hpMax);
        playerCtrl.Animator.SetInteger("State", (int)StateAnimation.Hurt);
    }
}
