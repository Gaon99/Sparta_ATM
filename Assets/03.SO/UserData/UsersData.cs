using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class UsersData : MonoBehaviour
{
   public string userName;
   public int money;
   public int balance;

   public UsersData(string userName, int money, int balance)
   {
      this.userName = userName;
      this.money = money;
      this.balance = balance;
   }
}