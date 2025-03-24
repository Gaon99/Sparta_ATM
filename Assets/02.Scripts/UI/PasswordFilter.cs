    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassWordFilter : TMP_InputField
{
    protected override void Start()
    {
        base.Start();
        inputType = InputType.Password;
        onValueChanged.AddListener(OnInputValueChanged);
    }

    protected virtual void OnInputValueChanged(string text)
    {
        string filtertext = "";
        foreach (char c in text)
        {
            if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            {
                filtertext += c;
            }
        }
        this.text = filtertext;
    }
}
