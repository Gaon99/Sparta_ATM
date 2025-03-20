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
    private Action<int>[] intActions;
    
    private void Start()
    {
        actions = new Action[buttons.Count];
        intActions = new Action<int>[buttons.Count];
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        if (index < intActions.Length && intActions[index] != null)
        {
            intActions[index]?.Invoke(index);
        }
        else if (index < actions.Length)
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

    public void SetButtonAction(int index, Action<int> action)
    {
        if (index >= 0 && index < intActions.Length)
        {
            intActions[index] = action;
        }
    }
}
