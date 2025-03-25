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
        try
        {
            UsersDataListWrapper wrapper = new UsersDataListWrapper();
            wrapper.usersDatalist = users;
            string jsonString = JsonUtility.ToJson(wrapper, prettyPrint: true); // 가독성 개선
            string filePath = Path.Combine(Application.persistentDataPath, "usersData.json");
            File.WriteAllText(filePath, jsonString);

            Debug.Log("저장 완료: " + jsonString); // 저장된 JSON 확인
        }
        catch (Exception ex)
        {
            Debug.LogError("저장 실패: " + ex.Message);
        }
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
                else
                {
                    Debug.LogError("JSON 데이터 구조 불일치");
                    return new List<UsersData>();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("데이터 로드 실패: " + ex.Message);
                return new List<UsersData>();
            }
        }
        return new List<UsersData>();
    }
}
