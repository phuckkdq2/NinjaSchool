using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Popup;

public class GameUICtrl : MonoBehaviour
{
    [SerializeField] private static GameUICtrl instance;
    [SerializeField] public static GameUICtrl Instance { get => instance; }
    [SerializeField] public Slider hpSlider;
    [SerializeField] public Slider expSlider;
    [SerializeField] public Text level;
    [SerializeField] public Text hp;
    [SerializeField] public Text itemHpCount;
    [SerializeField] public Transform holder;
    [SerializeField] public NPCManager npc;
    [SerializeField] public BoxNpc boxNpc;
    [SerializeField] public bool takeMisson = false;
    [SerializeField] public Text misson;


    void Awake()
    {
        GameUICtrl.instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);    

    }

    public void UpdateHealthBar(float rate)
    {
        if (hpSlider)
        {
            hpSlider.value = rate;
        }
    }

    public void UpdateExpBar(float rate)
    {
        if (expSlider)
        {
            expSlider.value = rate;
        }
    }

    public void UpdateLevel()
    {
        level.text = UserData.instance.level.ToString();
    }

    public void UpdateHp(float hp)
    {
        this.hp.text = hp.ToString();
    }

    public void UpdateItemHp()
    {
        itemHpCount.text = UserData.instance.hpCount.ToString();
    }

    public void ClearSelectionView()
    {
        foreach (Transform i in holder)
        {
            Destroy(i.gameObject);
        }
    }

    public void NpcInterRact()
    {
        ClearSelectionView();
        for (int i = 0; i < npc.npcData.nPCFunctions.Count; i++)
        {
            var boxClone = Instantiate(boxNpc, holder);
            boxClone.Innit(npc.npcData.nPCFunctions[i], npc);
        }
    }

    public void UpdateMisson()
    {
        if(takeMisson)
        {
            misson.text = "thỏ: " + UserData.instance.countMisson + "/20";
        }
    }

    public void OnClickSetting()
    {
        Popup.PopupSystem.GetOpenBuilder().SetType(PopupType.popupSetting)                                              // show game win
                    .SetCurrentPopupBehaviour(CurrentPopupBehaviour.Close)
                    .Open();
    }

}
