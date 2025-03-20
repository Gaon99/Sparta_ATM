using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserBase
{
    public string userName;
    public string userId;
    public int cash;
    public int balance;
}

[CreateAssetMenu(fileName = "NewUser", menuName = "UserData")]
public class UserData : ScriptableObject
{
    [SerializeField] private List<UserBase> userInfo;

    public List<UserBase> UserInfo => userInfo;
}
