using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameCtrl : MonoBehaviour
{
    [SerializeField] public Slider timeRateFilled;
    [SerializeField] public Transform btnPlay;
    [SerializeField] public Transform shuriken;
    [SerializeField] Transform HomeUI;
    [SerializeField] Transform GameUI;
    public AnimationCurve moveCurve;
    public float extendDuration;
    public Tween tween;

    void Start()
    {
        RotateShuriken();
    }

    public void RotateShuriken()
    {
        tween = shuriken.DORotate(new Vector3(0, 0, -360), 0.1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    public void OnClickPlayGame()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        btnPlay.gameObject.SetActive(false);
        timeRateFilled.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("School",LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            timeRateFilled.value = operation.progress * 0.2f;
            yield return null;
        }
        DOTween.To(() => timeRateFilled.value, x => timeRateFilled.value = x, 1f, extendDuration).SetEase(moveCurve)
        .OnUpdate(() =>
        {

        })
        .OnComplete(() =>
        {
            HomeUI.gameObject.SetActive(false);
            GameUI.gameObject.SetActive(true);
            SceneManager.UnloadScene("Home");
        });

    }


}
