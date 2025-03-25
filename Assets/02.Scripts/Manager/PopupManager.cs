using TMPro;
using UnityEngine;

public enum PopupType
{
    EmptyRegiInput,
    EmptyTransInput,
    InsufficientBalance,
    InvalidUserId,
    SelfTransfer
}

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupText;
    
    private void Start()
    {
        popup.SetActive(false);
    }

    public void ShowPopup(PopupType type)
    {
        switch (type)
        {
            case PopupType.EmptyRegiInput: popupText.text = "정보를 확인해주세요"; break;
            case PopupType.EmptyTransInput: popupText.text = "입력 정보를 확인해주세요"; break;
            case PopupType.InsufficientBalance: popupText.text = "잔액이 부족합니다"; break;
            case PopupType.InvalidUserId: popupText.text = "대상이 없습니다."; break;
            case PopupType.SelfTransfer : popupText.text = "본인에겐 송금할 수 없습니다"; break;
        }
        popup.SetActive(true);
    }

    public void ClosePopup()
    {
        popup.SetActive(false);
    }
}
