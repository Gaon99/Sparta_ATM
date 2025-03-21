using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIText : MonoBehaviour
{
   //[SerializeField] private UserData userData;
   [SerializeField] private TextMeshProUGUI userNametxt;
   [SerializeField] private TextMeshProUGUI cashtxt;
   [SerializeField] private TextMeshProUGUI balancetxt;

   private GameManager GM;

   private void Awake()
   {
      GM = GameManager.instance;
   }

   private void Start()
   {
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

   public void UpdateUI()
   {
      userNametxt.text = GM.usersData.userName + "\n";
      cashtxt.text = GM.usersData.money.ToString("N0") + "\n";
      balancetxt.text = "Balance : " + GM.usersData.balance.ToString("N0") + "\n";
   }
}

