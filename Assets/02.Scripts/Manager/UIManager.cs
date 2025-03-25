using System;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Setting")]
    [SerializeField] private GameObject transferPanel;
    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject atmPanel;
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private UserData userData;

    private bool isDeposit;
    
    [Header("System")]
    public GameObject loginUI;
    public GameObject popupBankUI;

    private ButtonManager BM;
    private GameManager GM;
    public UIText uiText;

    public string currentUserId;

    private void Start()
    {
        BM = ButtonManager.instance;
        GM = GameManager.instance;
        InitPanel();
        ButtonAction();
    }

    private void ButtonAction()
    {
        BM.SetButtonAction(0, OnDepositButtonClickAction);
        BM.SetButtonAction(1, OnWithdrawButtonClickAction);
        BM.SetButtonAction(2, OnGobackAction);

        BM.SetButtonAction(3, () => OnMoneyButtonClickAction(10000));
        BM.SetButtonAction(4, () => OnMoneyButtonClickAction(30000));
        BM.SetButtonAction(5, () => OnMoneyButtonClickAction(50000));

        BM.SetButtonAction(6, OnConfirmButtonClickAction);

        BM.SetButtonAction(7, OnSignUpButtonClickAction);
        BM.SetButtonAction(8,OnCancelButtonClickAction);

        BM.SetButtonAction(9, Register.instance.RegisterUser);
        BM.SetButtonAction(10, OnLoginButtonClickAction);
        BM.SetButtonAction(11, PopupManager.instance.ClosePopup);
        BM.SetButtonAction(12, OnBackButtonClickAction);
        BM.SetButtonAction(13,OnTransferPanelButtonClickAction);
        BM.SetButtonAction(14, TransferManager.instance.Transfer); 
    }

    private void InitPanel()
    {
        transferPanel.SetActive(false);
        atmPanel.SetActive(false);
        popupBankUI.SetActive(false);
    }
    
    private void OnTransferPanelButtonClickAction()
    {
     transferPanel.SetActive(true);
     selectPanel.SetActive(false);
    }
    
    private void OnBackButtonClickAction()
    {
        transferPanel.SetActive(false);
        selectPanel.SetActive(true);
    }
    
    private void OnLoginButtonClickAction()
    {
        LoginManager.instance.Login();
    }
    
    private void OnSignUpButtonClickAction()
    {
        LoginManager.instance.RegisterBtnClickAction();
    }

    private void OnCancelButtonClickAction()
    {
        LoginManager.instance.InitPanel();
    }

    private void OnConfirmButtonClickAction()
    {
        if (int.TryParse(inputField.text, out int amount))
        {
            OnMoneyButtonClickAction(amount);
            inputField.text = String.Empty;
        }
    }

    private void OnDepositButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "입금";
        isDeposit = true;
    }

    private void OnWithdrawButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "출금";
        isDeposit = false;
    }
    
    private void OnGobackAction()
    {
        atmPanel.SetActive(false);
        selectPanel.SetActive(true);
    }

    private void OnMoneyButtonClickAction(int money)
    {
        UsersData currentUser = GM.usersDataList.Find(user => user.userId == currentUserId);

        if (currentUser != null)
        {
            if (isDeposit)
            {
                if (currentUser.money >= money)
                {
                    currentUser.money -= money;
                    currentUser.balance += money;
                    GM.SaveUserData(GM.usersDataList);
                }
                else
                {    Debug.Log("Insufficient Balance!");

                    PopupManager.instance.ShowPopup(PopupType.InsufficientBalance);
                    return;
                }
            }
            else
            {
                if (currentUser.balance >= money)
                {
                    currentUser.money += money;
                    currentUser.balance -= money;
                    GM.SaveUserData(GM.usersDataList);
                }
                else
                {    Debug.Log("Insufficient Balance!");

                    PopupManager.instance.ShowPopup(PopupType.InsufficientBalance);
                    return;
                }
            }
            GM.SaveUserData(GM.usersDataList);
            uiText.UpdateUI();
        }
    }

    public void SetCurrentUserId(string userId)
    {
        currentUserId = userId;
    }

    public void LoginUI()
    {
        loginUI.SetActive(false);
        popupBankUI.SetActive(true); 
        uiText.UpdateUI();
    }
}

