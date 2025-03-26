using System;
using TMPro;
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
         return;
      }

      string currentUserId = UIManager.instance.currentUserId;
      if (string.IsNullOrEmpty(currentUserId))
      {
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

