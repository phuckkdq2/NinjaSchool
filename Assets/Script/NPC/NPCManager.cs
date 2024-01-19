using System.Collections;
using System.Collections.Generic;
using Popup;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] public NPCSO npcData;
    [SerializeField] public TextMeshPro textMeshPro;
    [SerializeField] public Transform boxChat;

    private void OnEnable()
    {
        textMeshPro.text = npcData.conversation[0];
    }

    public void Talking()
    {
        textMeshPro.text = npcData.conversation[0];
        StartCoroutine(ShowChat());
    }

    IEnumerator ShowChat()
    {
        boxChat.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        boxChat.gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        Popup.PopupSystem.GetOpenBuilder().SetType(PopupType.popupShop)                                              // show game win
                    .SetCurrentPopupBehaviour(CurrentPopupBehaviour.Close)
                    .Open();
    }

    public void TakeMisson()
    {
        GameUICtrl.Instance.takeMisson = true;
        GameUICtrl.Instance.misson.gameObject.SetActive(true);
        GameUICtrl.Instance.UpdateMisson();
        textMeshPro.text = npcData.conversation[1];
        StartCoroutine(ShowChat());
    }
}
