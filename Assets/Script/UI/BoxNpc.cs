using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxNpc : MonoBehaviour
{
    [SerializeField] public Text selection;
    [SerializeField] public NPCFunction function;

    public void Innit(string selection , NPCFunction npcFunc)
    {
        this.selection.text = selection;
        this.function = npcFunc;
    }

    public void OnClickSelection()
    {
        switch (function)
        {
            case NPCFunction.talk:
            break;
            case NPCFunction.shop:
            break;
            case NPCFunction.misson:
            break;
        }
    }
}
