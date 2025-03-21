using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class UsersDataListWrapper
{
    public List<UsersData> usersDatalist;
}

public class GameManager : Singleton<GameManager>
{
    public List<UsersData> usersDataList = new List<UsersData>();
    //private UserData userData;

    // [SerializeField] private int index;  

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        usersDataList = LoadUserData();

        if (usersDataList == null)
        {
            usersDataList = new List<UsersData>();
        }
    }

    public void SaveUserData(List<UsersData> users)
    {

        UsersDataListWrapper wrapper = new UsersDataListWrapper();
        wrapper.usersDatalist = users;

        string jsonString = JsonUtility.ToJson(users);
        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
        try
        {
            File.WriteAllText(filePath, jsonString);
        }
        catch (Exception ex)
        {
            Debug.LogError("Fail" + ex.Message);
        }
    }

    public List<UsersData> LoadUserData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            UsersDataListWrapper wrapper = JsonUtility.FromJson<UsersDataListWrapper>(jsonString);

            return wrapper.usersDatalist;
        }
        else
        {
            return null;
        }
    }
}
