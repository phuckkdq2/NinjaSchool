using System.Collections;
using System.Collections.Generic;
using Popup;
using UnityEngine;
using UnityEngine.UI;

public class BoxNpc : MonoBehaviour
{
    [SerializeField] public Text selection;
    [SerializeField] public NPCFunction function;
    [SerializeField] public NPCManager npc;

    public void Innit(NPCFunction npcFunc, NPCManager npc)
    {
        this.function = npcFunc;
        this.npc = npc;
        switch (npcFunc)
        {
            case NPCFunction.talk:
                selection.text = "Nói Chuyện";
                break;
            case NPCFunction.shop:
                selection.text = "Mua đồ";
                break;
            case NPCFunction.misson:
                selection.text = "Nhận nhiệm vụ";
                break;
        }
    }

    public void OnClickSelection()
    {
        GameUICtrl.Instance.ClearSelectionView();
        switch (function)
        {
            case NPCFunction.talk:
                npc.Talking();
                break;
            case NPCFunction.shop:
                npc.OpenShop();
                break;
            case NPCFunction.misson:
            npc.TakeMisson();
                break;
        }
    }
}
