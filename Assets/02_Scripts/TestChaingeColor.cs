using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiButtonColorChangerSimple : MonoBehaviour
{
    public Button ForwardButton;    // 직선 레일 버튼
    public Button LeftButton;   // 좌회전 레일 버튼
    public Button RightButton; // 우회전 레일 버튼
    public TMP_Text TargetText;   // 색상을 변경할 대상 Text

    private void Start()
    {
        // 버튼 클릭 시 각 메서드 연결
        // if (ForwardButton != null)
        // {
        //ForwardButton.onClick.RemoveAllListeners();
        ForwardButton?.onClick.AddListener(SetForward);
        //}

        //if (LeftButton != null)
        //{
        //LeftButton.onClick.RemoveAllListeners();
        LeftButton?.onClick.AddListener(SetLeft);
        //}

        //if (RightButton != null)
        //{
        //RightButton.onClick.RemoveAllListeners();
        RightButton?.onClick.AddListener(SetRight);
        //}
    }

    private void SetForward()
    {
        if (TargetText != null)
        {
            TargetText.text = "Select : Straight";
            Debug.Log("직선레일 선택");
        }
    }

    private void SetLeft()
    {
        if (TargetText != null)
        {
            TargetText.text = "Select : Left";
            Debug.Log("좌회전레일 선택");
        }
    }

    private void SetRight()
    {
        if (TargetText != null)
        {
            TargetText.text = "Select : Right";
            Debug.Log("우회전레일 선택");
        }
    }
}
