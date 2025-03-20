using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMUI : MonoBehaviour
{
    [SerializeField]private TMP_InputField inputField;
    [SerializeField]private Button EnterBtn;

    private void EnterInput()
    {
        EnterBtn.onClick.Invoke();
    }
}
