using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMUI : MonoBehaviour
{
    [SerializeField]private TMP_InputField inputField;
    [SerializeField]private Button button1;
    [SerializeField]private Button button2;
    [SerializeField]private Button button3;
    [SerializeField]private Button EnterBtn;
    
    [SerializeField]private TextMeshProUGUI Header;


    private void EnterInput()
    {
        EnterBtn.onClick.Invoke();
    }
}
