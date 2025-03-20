using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIText : MonoBehaviour
{
   //[SerializeField] private UserData userData;
   [SerializeField] private TextMeshProUGUI UserName;
   [SerializeField] private TextMeshProUGUI cash;
   [SerializeField] private TextMeshProUGUI balance;
   private string userNames;
   private string cashValues;
   private string balanceValues;

   private GameManager GM;

   private void Start()
   {
      GM = GameManager.instance;
      //SetInitText();
      UpdateUI();
   }

   private void Update()
   {
      UpdateUI();
   }

// private void SetInitText()
// {
//    userNames = String.Empty;
//    cashValues = String.Empty;
//    balanceValues = String.Empty;
// }

   private void UpdateUI()
   {
      UserName.text = GM.usersData.userName + "\n";
      cash.text = GM.usersData.money.ToString("N0") + "\n";
      balance.text = "Balance : " + GM.usersData.balance.ToString("N0") + "\n";
   }
}

