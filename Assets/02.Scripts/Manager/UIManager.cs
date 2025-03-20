using System;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject atmPanel;
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private UserData userData;

    private bool isDeposit = false;
    protected int currentuserIndex = 0;
    
    private void Start()
    {
        atmPanel.SetActive(false);
        ButtonManager.instance.SetButtonAction(0, OnDepositButtonClickAction);
        ButtonManager.instance.SetButtonAction(1, OnWithdrawButtonClickAction);
        ButtonManager.instance.SetButtonAction(2, OnGobackAction);
        
        ButtonManager.instance.SetButtonAction(3, () => OnMoneyButtonClickAction(10000));
        ButtonManager.instance.SetButtonAction(4, () => OnMoneyButtonClickAction(30000));
        ButtonManager.instance.SetButtonAction(5, () => OnMoneyButtonClickAction(50000));
        
        ButtonManager.instance.SetButtonAction(6, OnConfirmButtonClickAction);

        //ButtonManager.instance.SetButtonAction(3, () => OnMoneyButtonClickAction(10000, "USER01", TransactionType.Deposit));
    }

    public void OnConfirmButtonClickAction()
    {
        if (int.TryParse(inputField.text, out int amount))
        {
            OnMoneyButtonClickAction(amount);
            inputField.text = String.Empty;
        }
    }
    public void OnDepositButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "입금";
        isDeposit = true;
    }

    public void OnWithdrawButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "출금";
        isDeposit = false;
    }

    public void OnGobackAction()
    {
        atmPanel.SetActive(false);
        selectPanel.SetActive(true);
    }

    public void SetCurrentUserIndex(int index)
    {
        currentuserIndex = index;
    }

    public void OnMoneyButtonClickAction(int money)
    {
        if (currentuserIndex >= 0 && currentuserIndex < userData.UserInfo.Count)
        {
            var user = userData.UserInfo[GameManager.instance.index];

            if (isDeposit)
            {
                if (user.cash >= money)
                {
                    user.cash -= money;
                    user.balance += money;
                }
            }
            else
            {
                if (user.balance >= money)
                {
                    user.cash += money;
                    user.balance -= money;
                }
            }
        }
    }
}

    /*
    public void OnMoneyButtonClickAction(int money, string userId, TransactionType transactionType)
    {
        var user = userData.UserInfo.FirstOrDefault(u => u.userId == userId);

        if (transactionType == TransactionType.Deposit)
        {
            user.cash -= money;
            user.balance += money;
        }
        else if (transactionType == TransactionType.Withdraw)
        {
            user.cash += money;
            user.balance -= money;
        }
    }
*/

