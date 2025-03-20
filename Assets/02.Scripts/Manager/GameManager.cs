using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UserData userData;
    [SerializeField] public int index;
    private void Start()
    {
       userData = ScriptableObject.CreateInstance<UserData>();
    }
}
