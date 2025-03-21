using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.UIElements;

public class LoginManager : Singleton<LoginManager>
{
    [Header("InputField")] 
    [SerializeField] private TMP_InputField idInputField;
    [SerializeField] private TMP_InputField pwInputField;

    [Header("Panel")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject registerPanel;
    
    [SerializeField] private TextMeshProUGUI statusText;


    private void Start()
    {
        registerPanel.SetActive(false);
    }

    public void InitPanel()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
    }

    public void RegisterBtnClickAction()
    {
        registerPanel.SetActive(true);
    }

    public void Login()
    {
        string username = idInputField.text;
        string password = pwInputField.text;

        List<UsersData> usersDataList = GameManager.instance.usersDataList;

        if (usersDataList != null)
        {
            UsersData usersData = GameManager.instance.usersDataList.Find(user => user.userId ==username);
            
            if (VerifyPassword(password, usersData.hashedPassword))
            {
                UIManager.instance.SetCurrentUserId(usersData.userId);
                UIManager.instance.loginUI.SetActive(true);
                UIManager.instance.popupBankUI.SetActive(false);
            }
            else
            {
                statusText.text = ""; // 델리게이트 사용하여 팝업 창 내용과 register창 Text 관리
                //failPopup.SetActive(true); // 로그인에 실패했습니다.
            }
        }
        else
        {
            //failpopup.SetActive(true); // txt : 유저를 찾을 수 없습니다.
        } 
    }
    
    public bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInputPassword = HashedPassword(password);
        return hashedInputPassword == hashedPassword;
    }

    public string HashedPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
