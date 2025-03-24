using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Register : Singleton<Register>
{
    [Header("InputField")]
    [SerializeField] private TMP_InputField userId;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField userPassword;
    [SerializeField] private TMP_InputField passwordConfirm;
    
    [Header("Popup")]
    [SerializeField] private TextMeshProUGUI failText;

    public delegate void PopupDelegate(string message);
    public PopupDelegate ShowPopup;

    private void Start()
    {
        userPassword.characterLimit = 16;
        passwordConfirm.characterLimit = 16;
    }

    public void RegisterUser()
    {
        string userid = userId.text;
        string username = userName.text;
        string userpassword = userPassword.text;
        string confirmpassword = passwordConfirm.text;
        List<UsersData> userlist = GameManager.instance.usersDataList;

        if (userpassword != confirmpassword)
        {
            failText.text = "비밀번호가 다릅니다";
            return;
        }
        
        if (userlist.Exists(user => user.userId == userid))
        {
            failText.text = "이미 존재하는 아이디입니다";
            return;
        }
        string hashedPassword = LoginManager.instance.HashedPassword(confirmpassword);

        UsersData newUser = new UsersData();
        newUser.userId  = userid;
        newUser.userName = username;
        newUser.hashedPassword = hashedPassword;

        userlist.Add(newUser);
        
        GameManager.instance.SaveUserData(userlist);
        
        LoginManager.instance.InitPanel();
        
    }

    public void Popup()
    {
        //델리게이트 사용해서 제작
    }
}
