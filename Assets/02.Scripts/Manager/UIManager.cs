using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject atmPanel;
    [SerializeField] private TextMeshProUGUI header;
    private void Start()
    {
        atmPanel.SetActive(false);  
        ButtonManager.instance.SetButtonAction(0, OnDepositButtonClickAction);
        ButtonManager.instance.SetButtonAction(1, OnWithdrawalButtonClickAction);
        ButtonManager.instance.SetButtonAction(2, OnGobackAction);
    }

    public void OnDepositButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "입금";
    }
    public void OnWithdrawalButtonClickAction()
    {
        selectPanel.SetActive(false);
        atmPanel.SetActive(true);
        header.text = "출금";
    }
    
    public void OnGobackAction()
    {
        atmPanel.SetActive(false);
        selectPanel.SetActive(true);
    }
}
