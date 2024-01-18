using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] public NPCSO npcData;
    [SerializeField] public TextMeshPro textMeshPro;
    [SerializeField] public Transform boxChat;

    private void OnEnable() {
        textMeshPro.text = npcData.conversation[0];
    }

    public void Talking()
    {
        StartCoroutine(ShowChat());
    }

    IEnumerator ShowChat()
    {
        boxChat.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        boxChat.gameObject.SetActive(false);
    }
}
