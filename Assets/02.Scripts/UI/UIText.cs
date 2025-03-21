using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class UIText : MonoBehaviour
{
   //[SerializeField] private UserData userData;
   [SerializeField] private TextMeshProUGUI userNametxt;
   [SerializeField] private TextMeshProUGUI cashtxt;
   [SerializeField] private TextMeshProUGUI balancetxt;

   private GameManager GM;
   private string currentUserId;

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

   public void UpdateUI()
   {
      currentUserId = UIManager.instance.GetCurrentUserId();
      if (GM.usersDataList != null && !string.IsNullOrEmpty(currentUserId))
      {
         UsersData currentUserData = GM.usersDataList.Find(user => user.userId == currentUserId);

         userNametxt.text = currentUserData.userName + "\n";
         cashtxt.text = currentUserData.money.ToString("N0") + "\n";
         balancetxt.text = "Balance : " + currentUserData.balance.ToString("N0") + "\n";
      }
   }
}

