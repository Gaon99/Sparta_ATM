using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
        string jsonString = JsonUtility.ToJson(wrapper, prettyPrint: true);
        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
        File.WriteAllText(filePath, jsonString);

    }

    public List<UsersData> LoadUserData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
        if (File.Exists(filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                UsersDataListWrapper wrapper = JsonUtility.FromJson<UsersDataListWrapper>(jsonString);

                if (wrapper != null && wrapper.usersDatalist != null)
                {
                    return wrapper.usersDatalist;
                }
                return new List<UsersData>();
            }
            catch (Exception ex)
            {
                return new List<UsersData>();
            }
        }
        return new List<UsersData>();
    }
}
