using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameCtrl : MonoBehaviour
{
    [SerializeField] public Slider timeRateFilled;
    [SerializeField] public float curTime;
    [SerializeField] public float timeRate;
    [SerializeField] public Transform btnPlay;
    [SerializeField] public Transform shuriken;
    public Tween tween;

    void Start()
    {
        Loading();
        RotateShuriken();
    }

    public void RotateShuriken()
    {
        tween = shuriken.DORotate(new Vector3(0,0,-360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    public void Loading()
    {
        btnPlay.gameObject.SetActive(false);
        tween = DOTween.To(() => curTime, x => curTime = x, timeRate, timeRate - curTime).SetEase(Ease.Linear)              // tăng dần thời gian
        .OnStart(() =>
        {

        })
        .OnUpdate(() =>
        {
            UpdateTimeRate(curTime / timeRate);                                                                             // chạy loading time
        })
        .OnComplete(() =>                                                                                                   // khi loading time chạy xong
        {
            btnPlay.gameObject.SetActive(true);
            timeRateFilled.gameObject.SetActive(false);
        });
    }

    public void UpdateTimeRate(float rate)
    {
        if (timeRateFilled)
        {
            timeRateFilled.value = rate;
        }
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
