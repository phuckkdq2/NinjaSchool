using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Popup;
using UnityEngine;

public class PopupBtnBackHome : PopupBase
{
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

    public void OnClickClose()
    {
        
    }
}
