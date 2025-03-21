using System;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UsersData usersData;
    //private UserData userData;

    // [SerializeField] private int index;  

    private void Start()
    {
        usersData = LoadUserData();

        if (usersData == null)
        {
            usersData = new UsersData();
        }
    }

    public void SaveUserData(UsersData user)
        {
            string jsonString = JsonUtility.ToJson(user);
            string filePath = Path.Combine(Application.persistentDataPath, "userData.json");
            File.WriteAllText(filePath, jsonString);
        }

        public UsersData LoadUserData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, "userData.json");
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                UsersData user = JsonUtility.FromJson<UsersData>(jsonString);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
