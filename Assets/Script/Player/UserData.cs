using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public static UserData instance;
    public int coin;                        // tiền của user 
    public int level;
    public bool musicState;                 // trạng thái nhạc
    public bool soundState;                 // trạng thái âm thanh
    public int health;
    public int damage;
    public int expCount;
    public int expPool;

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

    public void AddCoin(int count)          // lưu tiền user 
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

        SavingData.Instance.SaveData();
    }

    public void AddExp(int count)
    {
        this.expCount += count;
        SavingData.Instance.SaveData();
    }

}
