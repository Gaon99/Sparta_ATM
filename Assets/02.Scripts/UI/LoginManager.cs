using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class LoginManager : Singleton<LoginManager> 
{
    [Header("InputField")] 
    [SerializeField] private TMP_InputField idInputField;
    [SerializeField] private PassWordFilter pwInputField;

    [Header("Panel")] [SerializeField] private GameObject loginPanel;
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

        if (GameManager.instance.usersDataList == null)
        {
            statusText.text = "Loading data...";
            return;
        }

        // 1. 사용자 존재 여부 확인
        UsersData usersData = GameManager.instance.usersDataList.Find(user =>
            user.userId.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (usersData == null)
        {
            statusText.text = "존재하지 않는 아이디입니다.";
            return;
        }

        // 2. 비밀번호 검증
        if (!VerifyPassword(password, usersData.hashedPassword))
        {
            statusText.text = "비밀번호가 틀렸습니다.";
            return;
        }

        // 3. 로그인 성공 처리 (여기서 한 번만 호출)
        UIManager.instance.SetCurrentUserId(usersData.userId);
        Debug.Log($"로그인 성공: ID={usersData.userId}, Name={usersData.userName}");
        UIManager.instance.LoginUI();
        statusText.text = "로그인 성공!";
        
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
