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
    [SerializeField] private GameObject failPopup;
    [SerializeField] private TextMeshProUGUI failText;

    public delegate void PopupDelegate(string message);
    public PopupDelegate ShowPopup;
    
    public void RegisterUser()
    {
        string userid = userId.text;
        string username = userName.text;
        string userpassword = userPassword.text;
        string password = passwordConfirm.text;

        if (userpassword != password)
        {
            Popup();
            return;
        }

        string hashedPassword = LoginManager.instance.HashedPassword(password);

        UsersData newUser = new UsersData();
        newUser.userId  = userid;
        newUser.userName = username;
        newUser.hashedPassword = hashedPassword;

        List<UsersData> userlist = GameManager.instance.usersDataList;
        if (userlist.Exists(user => user.userId == userid))
        {
            //이미 존재하는 아이디입니다.
            return;
        }

        userlist.Add(newUser);
        GameManager.instance.SaveUserData(userlist);
        
    }

    public void Popup()
    {
        //델리게이트 사용해서 제작
    }
}
