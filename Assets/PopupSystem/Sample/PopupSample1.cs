using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Popup;
using UnityEngine;
using System;

public class PopupSample1 : PopupBase
{
    public Action Test;

    public override void Show()
    {
        canClose = false;
        PopupAnimationUtility.AnimateScale(this.transform, Ease.OutBack, 0.25f, 1f, 0.25f, 0f)
            .OnComplete((() => {
                canClose = true;
            }));
    }

    public override void Close(bool forceDestroying = true)
    {
        PreAnimateHideEvent?.Invoke();
        base.Close(forceDestroying);
        PostAnimateHideEvent?.Invoke();
    }
}
