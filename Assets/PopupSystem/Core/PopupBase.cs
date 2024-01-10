using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Popup
{
    public class PopupBase : MonoBehaviour
    {
        public Action PostAnimateShowEvent;

        public Action PreAnimateHideEvent;

        public Action PostAnimateHideEvent;

        public Action<object> AcceptEvent;

        public Action<object> DenyEvent;

        protected Transform cachedTransform;

        protected CanvasGroup canvasGroup;

        protected bool canClose;

        protected internal PopupType type;

        void Awake()
        {
            cachedTransform = transform;
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual bool CanClose()
        {
            return canClose;
        }

        public virtual void Show()
        {
        }

        public virtual void Close(bool forceDestroying = true)
        {
            TerminateInternal(forceDestroying);
        }

        protected void TerminateInternal(bool forceDestroying = true)
        {
            if (forceDestroying)
                Destroy(gameObject);
            else
                gameObject.SetActive(false);

            PopupSystem.Instance.OnPopupTerminate();
        }

        public void CloseInternal()
        {
            PopupSystem.Instance.ClosePopup();
        }

        private IEnumerator delayDo(YieldInstruction instruction, UnityAction unityAction)
        {
            yield return instruction;
            if (unityAction != null)
            {
                unityAction();
            }
            yield break;
        }

        private IEnumerator delayDo(CustomYieldInstruction instruction, UnityAction unityAction)
        {
            yield return instruction;
            if (unityAction != null)
            {
                unityAction();
            }
            yield break;
        }

        private IEnumerator loopDelayDo(Func<bool> func, UnityAction unityAction)
        {
            while (func())
            {
                yield return PopupBase.waitForEndOfFrame;
            }
            if (unityAction != null)
            {
                unityAction();
            }
            yield break;
        }

        protected IEnumerator StartUnityWeb(UnityWebRequest unityWebRequest, UnityAction<DownloadHandler> unityAction)
        {
            yield return unityWebRequest.SendWebRequest();
            if (unityAction != null)
            {
                unityAction(unityWebRequest.downloadHandler);
            }
            yield break;
        }

        protected IEnumerator StartUnityWeb(UnityWebRequest unityWebRequest, UnityAction<UnityWebRequest> unityAction)
        {
            yield return unityWebRequest.SendWebRequest();
            if (unityAction != null)
            {
                unityAction(unityWebRequest);
            }
            yield break;
        }

        protected void DelayDo(UnityAction unityAction)
        {
            if (base.gameObject.activeSelf)
            {
                base.StartCoroutine(this.delayDo(PopupBase.waitForEndOfFrame, unityAction));
            }
        }

        protected void LoopDelayDo(Func<bool> func, UnityAction unityAction)
        {
            if (base.gameObject.activeSelf)
            {
                base.StartCoroutine(this.loopDelayDo(func, unityAction));
            }
        }

        protected void DelayDo(YieldInstruction instruction, UnityAction unityAction)
        {
            if (base.gameObject.activeSelf)
            {
                base.StartCoroutine(this.delayDo(instruction, unityAction));
            }
        }

        protected void DelayDo(CustomYieldInstruction instruction, UnityAction unityAction)
        {
            if (base.gameObject.activeSelf)
            {
                base.StartCoroutine(this.delayDo(instruction, unityAction));
            }
        }

        private static WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
    }
}
