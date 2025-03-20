using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIText : MonoBehaviour
{
   [SerializeField] private UserData userData;
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
      SetInitText();
      UpdateUI(GM.index);
   }

   private void Update()
   {
      UpdateUI(GM.index);
   }

   private void SetInitText()
   {
      userNames = String.Empty;
      cashValues = String.Empty;
      balanceValues = String.Empty;
   }

   private void UpdateUI(int index)
   {
      if (index >= 0 && index < userData.UserInfo.Count)    
      {
         UserBase user = userData.UserInfo[index];
         UserName.text = user.userName + "\n";
         cash.text = user.cash.ToString("N0") + "\n";
         balance.text = "Balance : "+user.balance.ToString("N0") + "\n";
      }
   }
}

