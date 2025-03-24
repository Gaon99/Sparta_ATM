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

   private void Awake()
   {
      GM = GameManager.instance;
   }
   
   public void UpdateUI()
   {
      if (GM == null || GM.usersDataList == null || GM.usersDataList.Count == 0)
      {
         Debug.LogError("데이터가 로드되지 않았습니다!");
         return;
      }

      string currentUserId = UIManager.instance.currentUserId;
      if (string.IsNullOrEmpty(currentUserId))
      {
         Debug.LogError("currentUserId가 설정되지 않았습니다!");
         return;
      }

      UsersData currentUser = GM.usersDataList.Find(user => 
         user.userId.Equals(currentUserId, StringComparison.OrdinalIgnoreCase));

      if (currentUser != null)
      {
         userNametxt.text = currentUser.userName;
         cashtxt.text = currentUser.money.ToString("N0");
         balancetxt.text = $"balance : {currentUser.balance:N0}";
      }
   }
}

