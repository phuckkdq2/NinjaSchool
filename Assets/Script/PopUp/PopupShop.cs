using System.Collections;
using System.Collections.Generic;
using Popup;
using UnityEngine;
using UnityEngine.UI;

public class PopupShop : PopupBase
{
    [SerializeField] public ItemSO item;
    [SerializeField] public Text cost;
    [SerializeField] public Text description;
    [SerializeField] public Text coinUser;
    public override void Show()
    {
        canClose = true;
        base.Show();
        UpdateCoin();;
    }

    public override void Close(bool forceDestroying = true)
    {
        PreAnimateHideEvent?.Invoke();
        base.Close(forceDestroying);
        PostAnimateHideEvent?.Invoke();
    }

    public void UpdateCoin()
    {
        coinUser.text = UserData.instance.coin.ToString();
    }

    public void OnClickBuyItem()
    {
        if (UserData.instance.coin > item.value)
        {
            UserData.instance.AddCoin(-item.value);
            UserData.instance.AddHp(1);
            UpdateCoin();
        }
        else
        {
            Debug.LogError("het tien");
        }
    }

    public void OnClickShowInfor()
    {
        cost.text = "Giá bán : " + item.value;
        description.text = "Công dụng : " + item.infor;
    }

    public void OnClickClose()
    {
        CloseInternal();
    }

}
