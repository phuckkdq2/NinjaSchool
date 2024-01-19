using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Threading.Tasks;

public class SavingData : MonoSingleton<SavingData>
{
    public UserData userData;
    [SerializeField] private Transform player;

    public override async void Awake()
    {
        base.Awake();
        await LoadData();
        player.gameObject.SetActive(true);
        GameUICtrl.Instance.UpdateLevel();
        GameUICtrl.Instance.UpdateHp(userData.health);
        GameUICtrl.Instance.UpdateExpBar(UserData.instance.expCount / UserData.instance.expPool);
        GameUICtrl.Instance.UpdateItemHp();
        AudioManager.Instance.SetEffectEnable(UserData.instance.soundState);
        AudioManager.Instance.SetMusicEnable(UserData.instance.musicState);
        AudioManager.Instance.PlayMusic(AudioClipId.BG);
    }

    private void Start()
    {

    }

    public async Task LoadData()
    {
        string file = "saveData.json";
        string dataFolder = Path.Combine(Application.persistentDataPath, "UserData");

        if (!Directory.Exists(dataFolder))
        {
            Directory.CreateDirectory(dataFolder);
        }

        string filePath = Path.Combine(dataFolder, file);

        if (!File.Exists(filePath))
        {
            userData = new UserData();
            SaveData();
            userData = JsonUtility.FromJson<UserData>(await File.ReadAllTextAsync(filePath));
            UserData.instance = userData;
        }
        else
        {
            userData = JsonUtility.FromJson<UserData>(await File.ReadAllTextAsync(filePath));
            UserData.instance = userData;
        }

        Debug.LogError(filePath);
    }

    public void SaveData()
    {
        string file = "saveData.json";                                                  // tên file 
        string dataFolder = Path.Combine(Application.persistentDataPath, "UserData");
        if (!Directory.Exists(dataFolder))
        {
            Directory.CreateDirectory(dataFolder);
        }
        string filePath = Path.Combine(dataFolder, file);       //  đường dẫn file

        string userJson = JsonUtility.ToJson(userData, true);
        File.WriteAllText(filePath, userJson);
    }

}






