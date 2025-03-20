using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserBase
{
    public string userName;
    public int cash;
    public int balance;
}
[CreateAssetMenu(fileName = "NewUser", menuName = "UserData")]
public class UserData : ScriptableObject
{
    [SerializeField] private List<UserBase> userInfo = new List<UserBase>();

    public List<UserBase> UserInfo => userInfo;
}
