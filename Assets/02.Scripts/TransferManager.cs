using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransferManager : Singleton<TransferManager>
{
   [SerializeField] private TMP_InputField receiverField;
   [SerializeField] private TMP_InputField amountField;

   public GameObject PopupPanel;

   private void Start()
   {
      PopupPanel.SetActive(false);
   }

   public void Transfer()
   {
      string senderId = UIManager.instance.currentUserId;
      string receiverId = receiverField.text;

      int amount = 0;
      
      if(string.IsNullOrEmpty(receiverId)|| !int.TryParse(amountField.text, out amount) || amount <= 0)
      {
         PopupPanel.SetActive(true);
         return;
      }
      
      UsersData sender = GameManager.instance.usersDataList.Find(user => user.userId == senderId);
      UsersData receiver = GameManager.instance.usersDataList.Find(user => user.userId == receiverId);

      if (sender == null || receiver == null)
      {
         PopupPanel.SetActive(true); // 유저 찾지 못함
         return;
      }

      if (sender.balance < amount)
      {
         PopupPanel.SetActive(true);//잔액 부족
         return;
      }
      
      sender.balance -= amount;
      receiver.balance += amount;
      GameManager.instance.SaveUserData(GameManager.instance.usersDataList);
      
      PopupPanel.SetActive(true);
      UIManager.instance.uiText.UpdateUI();
   }
   
}
