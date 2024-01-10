using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUICtrl : MonoBehaviour
{
    [SerializeField] private static GameUICtrl instance;
    [SerializeField] public static GameUICtrl Instance { get => instance;}
    [SerializeField] public Slider hpSlider;
    [SerializeField] public Text level;

    void Awake()
    {
        GameUICtrl.instance = this;
    }

    private void Start() {
        UpdateLevel();
    }

    public void UpdateHealthBar(float rate)
    {
        if(hpSlider)
        {
            hpSlider.value = rate;
        }
    }

    public void UpdateLevel()
    {
        level.text = UserData.instance.level.ToString(); 
    }

}