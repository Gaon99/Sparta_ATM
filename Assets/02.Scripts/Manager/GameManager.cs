using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UsersData usersData{get;set;}
    public UserData userData;
    [SerializeField] public int index;
    private void Start()
    {
       userData = ScriptableObject.CreateInstance<UserData>();
       usersData = new UsersData("르탄이",50000,100000);
    }
}
