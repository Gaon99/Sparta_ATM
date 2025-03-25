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
      string receiverId = receiverField.text;
      string receiverName = receiverField.text;
      
      int amount = 0;
      
      if(string.IsNullOrEmpty(receiverId)||string.IsNullOrEmpty(receiverName) || !int.TryParse(amountField.text, out amount) || amount <= 0)
      {
         PM.ShowPopup(PopupType.EmptyTransInput);
         return;
      }
      
      UsersData sender = GameManager.instance.usersDataList.Find(user => user.userId == senderId);
      UsersData receiver = GameManager.instance.usersDataList.Find(user => user.userId == receiverId);

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
   }
   
}
