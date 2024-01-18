using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReciever : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;                       // chứa coponent quản lí các component khác
    [SerializeField] public Transform btnBackHome;
    [SerializeField] public Transform Button;

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
        Button.gameObject.SetActive(false);
        GameUICtrl.Instance.hpSlider.value = 0;
        btnBackHome.gameObject.SetActive(true);
    }

    public void OnClickBackHomeOnDead()
    {
        playerCtrl.LoadNextScene("School");
        ReBorn();
        btnBackHome.gameObject.SetActive(false);
        Button.gameObject.SetActive(true);
    }

    public override void ReBorn()
    {
        this.hpMax = UserData.instance.health;
        GameUICtrl.Instance.hpSlider.value = 1;
        base.ReBorn();
        playerCtrl.Animator.SetInteger("State", (int)StateAnimation.Idle);
        playerCtrl.transform.position = Vector3.zero;
        GameUICtrl.Instance.UpdateHp(hp);
    }

    public override void Deduct(float dame)
    {
        base.Deduct(dame);
        GameUICtrl.Instance.UpdateHealthBar(hp / hpMax);
        GameUICtrl.Instance.UpdateHp(hp);
        if (hp > 0) playerCtrl.Animator.SetInteger("State", (int)StateAnimation.Hurt);
    }
}
