using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    [SerializeField] private List<Button> buttons;
    private Action[] actions;
    
    private void Start()
    {
        actions = new Action[buttons.Count];
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        if (index < actions.Length)
        {
            actions[index]?.Invoke();
        }
    }

    public void SetButtonAction(int index, Action action)
    {
        if (index >= 0 && index < actions.Length)
        {
            actions[index] = action;
        }
    }
}
