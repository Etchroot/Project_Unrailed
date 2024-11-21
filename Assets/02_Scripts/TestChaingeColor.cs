using UnityEngine;
using UnityEngine.UI;

public class MultiButtonColorChangerSimple : MonoBehaviour
{
    public Button redButton;    // 빨강 버튼
    public Button blueButton;   // 파랑 버튼
    public Button yellowButton; // 노랑 버튼
    public Image targetImage;   // 색상을 변경할 대상 Image

    private void Start()
    {
        // 버튼 클릭 시 각 메서드 연결
        if (redButton != null)
            redButton.onClick.AddListener(SetRedColor);

        if (blueButton != null)
            blueButton.onClick.AddListener(SetBlueColor);

        if (yellowButton != null)
            yellowButton.onClick.AddListener(SetYellowColor);
    }

    private void SetRedColor()
    {
        if (targetImage != null)
        {
            targetImage.color = Color.red;
            Debug.Log("Image color changed to Red");
        }
    }

    private void SetBlueColor()
    {
        if (targetImage != null)
        {
            targetImage.color = Color.blue;
            Debug.Log("Image color changed to Blue");
        }
    }

    private void SetYellowColor()
    {
        if (targetImage != null)
        {
            targetImage.color = Color.yellow;
            Debug.Log("Image color changed to Yellow");
        }
    }
}
