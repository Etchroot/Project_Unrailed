using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;

public class RaytoTile_N_InstantRail : MonoBehaviour
{
    [SerializeField] private Transform Controller; // 레이 발사 지점
    [SerializeField] private float rayLength = 10f; // 레이 길이
    [SerializeField] private InputActionProperty triggerAction; // 트리거 버튼 액션
    [SerializeField] private Button[] railButtons; // 3개의 버튼 배열
    [SerializeField] private GameObject[] railPrefabs; // 레일 프리팹 배열
    private int selectedRailIndex = -1; // 선택된 레일 종류 (-1은 선택되지 않음을 의미)

    void Start()
    {
        // 초기 버튼 클릭 이벤트 설정
        SetButtonListeners();
    }

    void OnEnable()
    {
        // triggerAction이 활성화될 때 이벤트 등록
        triggerAction.action.performed += OnTriggerActivated;
    }

    void OnDisable()
    {
        // triggerAction 비활성화 시 이벤트 해제
        triggerAction.action.performed -= OnTriggerActivated;
    }

    void Update()
    {
        // 트리거 버튼 입력에 따라 레일 설치 시도
        TryPlaceRail();
    }

    /// <summary>
    /// 트리거가 활성화될 때 호출되는 메서드
    /// </summary>
    private void OnTriggerActivated(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger activated. Updating button listeners.");
        UpdateButtonListeners();
    }

    /// <summary>
    /// 각 버튼 클릭 시 선택된 레일 인덱스를 설정
    /// </summary>
    private void SetButtonListeners()
    {
        for (int i = 0; i < railButtons.Length; i++)
        {
            int index = i; // 람다 캡처 문제 방지
            railButtons[i].onClick.AddListener(() => SelectRail(index));
        }
    }

    /// <summary>
    /// 버튼 리스너를 업데이트
    /// </summary>
    private void UpdateButtonListeners()
    {
        // 기존 리스너 제거
        foreach (var button in railButtons)
        {
            if (button != null)
                button.onClick.RemoveAllListeners();
        }

        // 새로운 리스너 추가
        SetButtonListeners();
        Debug.Log("Button listeners updated.");
    }

    /// <summary>
    /// 선택된 레일 인덱스 설정
    /// </summary>
    private void SelectRail(int index)
    {
        selectedRailIndex = index;
        Debug.Log($"레일 {index} 선택됨");
    }

    /// <summary>
    /// 트리거 버튼을 눌렀을 때 레일 설치
    /// </summary>
    private void TryPlaceRail()
    {
        if (triggerAction.action.WasPerformedThisFrame() && selectedRailIndex != -1)
        {

            Ray ray = new Ray(Controller.transform.position, Controller.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red, 2f);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
            {
                if (hitInfo.collider.CompareTag("EMPTY"))
                {
                    Debug.Log("타일이 EMPTY 상태입니다.");
                    PlaceRail(hitInfo.collider.gameObject, hitInfo.collider.bounds.center);
                }
                else
                {
                    Debug.Log("설치할 수 없는 타일입니다.");
                }
            }
        }
    }

    /// <summary>
    /// 레일 설치 로직
    /// </summary>
    private void PlaceRail(GameObject tile, Vector3 position)
    {
        if (selectedRailIndex >= 0 && selectedRailIndex < railPrefabs.Length && railPrefabs[selectedRailIndex] != null)
        {
            Instantiate(railPrefabs[selectedRailIndex], position, Quaternion.identity);
            tile.tag = "INSTALL"; // 타일 상태를 INSTALL로 변경
            Debug.Log($"레일 {selectedRailIndex} 설치 완료.");
        }
        else
        {
            Debug.Log("선택된 레일 프리팹이 존재하지 않음");
        }
    }
}
