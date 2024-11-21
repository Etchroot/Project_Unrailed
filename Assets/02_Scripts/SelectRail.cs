using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SelectRail : MonoBehaviour
{
    public GameObject[] buttons; // Button1, Button2, Button3
    public InputActionReference navigateAction; // 오른쪽 스틱 입력을 받는 액션
    public InputActionReference selectAction;   // 선택 버튼 입력을 받는 액션
    private int currentIndex = 0; // 현재 선택된 버튼 인덱스
    private bool isdelay = false; // 스틱 움직임 딜레이 확인용

    void OnEnable()
    {
        // 입력 액션 등록
        navigateAction.action.performed += OnNavigate;
        selectAction.action.performed += OnSelect;
    }

    void OnDisable()
    {
        // 입력 액션 해제
        navigateAction.action.performed -= OnNavigate;
        selectAction.action.performed -= OnSelect;
    }

    // 스틱으로 버튼을 이동
    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        //Debug.Log("" + input.x);
        if (!isdelay)
        {
            if (input.x > 0.8f) // 스틱을 오른쪽으로 움직였을 때
            {
                UpdateSelection(1); // 오른쪽으로 이동

            }
            else if (input.x < -0.8f) // 스틱을 왼쪽으로 움직였을 때
            {
                UpdateSelection(-1); // 왼쪽으로 이동

            }


        }
    }

    // 선택된 버튼 업데이트
    private void UpdateSelection(int direction)
    {
        isdelay = true;
        // 이전 선택된 버튼 색상 초기화
        buttons[currentIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        // 인덱스 업데이트, 범위 제한
        currentIndex = Mathf.Clamp(currentIndex + direction, 0, buttons.Length - 1);
        // 새로운 선택된 버튼 색상 변경
        buttons[currentIndex].GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
        StartCoroutine(DelayCRT());
    }

    // 선택 버튼 클릭
    private void OnSelect(InputAction.CallbackContext context)
    {
        buttons[currentIndex].GetComponent<Button>().onClick.Invoke(); // 버튼 클릭
    }

    IEnumerator DelayCRT()
    {
        yield return new WaitForSeconds(0.5f);
        isdelay = false;
    }
}


