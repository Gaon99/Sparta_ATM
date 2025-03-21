using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
            string jsonString = JsonUtility.ToJson(users);
            string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
            File.WriteAllText(filePath, jsonString);
        }

        public List<UsersData> LoadUserData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                List<UsersData> users = JsonUtility.FromJson<List<UsersData>>(jsonString);
                return users;
            }
            else
            {
                return null;
            }
        }
    }
