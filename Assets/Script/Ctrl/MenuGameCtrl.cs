using System.Collections;
using System.Threading.Tasks;
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
    [SerializeField] Transform HomeUI;
    [SerializeField] Transform GameUI;
    public Tween tween;

    void Start()
    {
        RotateShuriken();
    }

    public void RotateShuriken()
    {
        tween = shuriken.DORotate(new Vector3(0, 0, -360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    public void UpdateTimeRate(float rate)
    {
        if (timeRateFilled)
        {
            timeRateFilled.value = rate;
        }
    }

    public void OnClickPlayGame()
    {
        PlayGame();

    }

    async void PlayGame()
    {
        btnPlay.gameObject.SetActive(false);
        timeRateFilled.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(UserData.instance.stateSceneId);
        while (operation.progress < 0.9f)
        {
            await Task.Delay(100);
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            timeRateFilled.value = progressValue;
        }
        await Task.Delay(1000);
        HomeUI.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);

    }


}
