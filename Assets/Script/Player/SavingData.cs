using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SavingData : MonoSingleton<SavingData>
{
    public UserData userData;

    public override void Awake()
    {
        base.Awake();
        LoadData();
    }

    private void Start()
    {

    }

    public void LoadData()
    {
        string file = "saveData.json";                                                  // tên file 

        string dataFolder = Path.Combine(Application.persistentDataPath, "UserData");
        if (!Directory.Exists(dataFolder))
        {
            Directory.CreateDirectory(dataFolder);
        }
        string filePath = Path.Combine(dataFolder, file);           //  đường dẫn file

        if (!File.Exists(filePath))
        {
            userData = new UserData();
            SaveData();
        }
        userData = JsonUtility.FromJson<UserData>(File.ReadAllText(filePath));
        UserData.instance = userData;
        Debug.Log(filePath);
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






