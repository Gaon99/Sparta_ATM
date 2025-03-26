using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class EncryptedDataWrapper 
{
    public string encryptedText;
    public string iv;
}
[Serializable]
public class UsersDataListWrapper
{
    public List<UsersData> usersDatalist = new List<UsersData>();
}

public class GameManager : Singleton<GameManager>
{
    public List<UsersData> usersDataList = new List<UsersData>();
    //private UserData userData;

    // [SerializeField] private int index;  

    private void Start()
    {
        usersDataList = LoadUserData() ?? new List<UsersData>(); // null 체크 강화
    }


    public void SaveUserData(List<UsersData> users)
    {
        UsersDataListWrapper wrapper = new UsersDataListWrapper();
        wrapper.usersDatalist = users;
        string jsonString = JsonUtility.ToJson(wrapper, true);

        string key = "z7QpL0V3n9X5a1dF2g4H8jK1m0qW3e6R";
        var (encryptedText, iv) = JsonEncrypt.Encrypt(jsonString, key);

        EncryptedDataWrapper dataWrapper = new EncryptedDataWrapper
        {
            encryptedText = encryptedText,
            iv = iv
        };

        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
        string finalJson = JsonUtility.ToJson(dataWrapper, true);
        File.WriteAllText(filePath, finalJson);
    }


    private List<UsersData> LoadUserData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");

        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string fileContent = File.ReadAllText(filePath);

            EncryptedDataWrapper dataWrapper = JsonUtility.FromJson<EncryptedDataWrapper>(fileContent);
            if (dataWrapper == null) throw new Exception("EncryptedDataWrapper 파싱 실패");

            string key = "z7QpL0V3n9X5a1dF2g4H8jK1m0qW3e6R";
            string decryptedJson = JsonEncrypt.Decrypt(dataWrapper.encryptedText, key, dataWrapper.iv);

            UsersDataListWrapper wrapper = JsonUtility.FromJson<UsersDataListWrapper>(decryptedJson);
            if (wrapper == null) throw new Exception("UsersDataListWrapper 파싱 실패");

            return wrapper.usersDatalist ?? new List<UsersData>();
        }
        catch (Exception)
        {
            return null;
        }
    }
}