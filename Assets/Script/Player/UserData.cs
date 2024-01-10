using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public static UserData instance;
    public float coin;                        // tiền của user 
    public float level;
    public bool musicState;                 // trạng thái nhạc
    public bool soundState;                 // trạng thái âm thanh
    public float health;
    public float damage;
    public float expCount;
    public float expPool;

    public UserData()
    {
        musicState = true;                 // trạng thái nhạc
        soundState = true;                 // trạng thái âm thanh
        coin = 0;                          // tiền của user 
        level = 1;
        health = 100;
        damage = 15;
        expCount = 0;
        expPool = 1000;
    }

    public void AddCoin(float count)          // lưu tiền user 
    {
        this.coin += count;
        SavingData.Instance.SaveData();
    }

    public void LevelUp()
    {
        level++;
        expPool += expPool * 50 / 100;
        expCount = 0;
        health += health * 20 / 100;
        damage += damage * 20 / 100;
        GameUICtrl.Instance.UpdateLevel();
        SavingData.Instance.SaveData();
    }

    public void AddExp(float count)
    {
        this.expCount += count;
        GameUICtrl.Instance.UpdateExpBar(expCount / expPool);
        if (expCount >= expPool)
        {
            LevelUp();
            expCount = 0;
        }
        SavingData.Instance.SaveData();
    }

}
