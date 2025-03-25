using System;
using TMPro;
using UnityEngine;

public class TransferManager : Singleton<TransferManager>
{
   [SerializeField] private TMP_InputField receiverField;
   [SerializeField] private TMP_InputField amountField;

   private PopupManager PM;

   private void Start()
   {
      PM = PopupManager.instance;
   }

   public void Transfer()
   {
      string senderId = UIManager.instance.currentUserId;
      string receiverInput = receiverField.text.Trim();

      int amount;
      
      if(string.IsNullOrEmpty(receiverInput) || !int.TryParse(amountField.text, out amount) || amount <= 0)
      {
         PM.ShowPopup(PopupType.EmptyTransInput);
         return;
      }
      
      UsersData sender = GameManager.instance.usersDataList.Find(user => user.userId == senderId);
      UsersData receiver;
      
      receiver = GameManager.instance.usersDataList.Find(user => user.userId == receiverInput);
      
      if (receiver == null)
      {
         receiver = GameManager.instance.usersDataList.Find(user => 
            user.userName.Equals(receiverInput, StringComparison.OrdinalIgnoreCase));
      }
      
      if (sender == receiver) 
      { 
         PM.ShowPopup(PopupType.SelfTransfer);
         return;
      }
      
      if (sender == null || receiver == null)
      {
         PM.ShowPopup(PopupType.InvalidUserId);
         return;
      }

      if (sender.balance < amount)
      {
         PM.ShowPopup(PopupType.InsufficientBalance);
         return;
      }
      
      sender.balance -= amount;
      receiver.balance += amount;
      GameManager.instance.SaveUserData(GameManager.instance.usersDataList);
      UIManager.instance.uiText.UpdateUI();

      receiverField.text = "";
      amountField.text = "";
   }
   
}
