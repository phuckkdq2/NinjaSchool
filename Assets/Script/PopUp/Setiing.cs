using System.Collections;
using System.Collections.Generic;
using Popup;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Setiing : PopupBase
{
    [Header("Sound Settings")]
    [SerializeField] Image imageSound;
    [SerializeField] List<Sprite> imgBtnSound;

    [Header("Music Settings")]
    [SerializeField] Image imageMusic;
    [SerializeField] List<Sprite> imgBtnMusic;

    private bool turnSound ;
    private bool turnMusic ;

    private void Start()
    {
        imageSound.sprite= UserData.instance.soundState?imgBtnSound[0]:imgBtnSound[1];
        imageMusic.sprite = UserData.instance.musicState?imgBtnMusic[0]:imgBtnMusic[1];
    }
    public override void Show()
    {
        PopupAnimationUtility.AnimateScale(transform, Ease.Linear , 0.1f , 1f, 0.2f, 0f);
        canClose= true;
    }

    public override void Close(bool forceDestroying = true)
    {
        PreAnimateHideEvent?.Invoke();
        base.Close(forceDestroying);
        PostAnimateHideEvent?.Invoke();
    }

    public virtual void OnClickBtnSound()
    {
        var userData = UserData.instance;
        userData.soundState = ! userData.soundState;
        imageSound.sprite= userData.soundState?imgBtnSound[0]:imgBtnSound[1];
        AudioManager.Instance.SetEffectEnable(userData.soundState);
        SavingData.Instance.SaveData();
    }

    public virtual void OnClickBtnMusic()
    {
        var userData = UserData.instance;
        userData.musicState = ! userData.musicState;
        imageMusic.sprite = userData.musicState?imgBtnMusic[0]:imgBtnMusic[1];
        AudioManager.Instance.SetMusicEnable(userData.musicState);
        SavingData.Instance.SaveData();
    }
    
}
